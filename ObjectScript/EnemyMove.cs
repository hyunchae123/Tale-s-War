using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] EnemyBullet bulletPrefab;

    Rigidbody2D myRigid;
    SpriteRenderer mySprite;

    public float moveSpeed;
    public float damage;

    public Vector3 dir;

    [Header("Role")]
    public bool MiddleAttack;

    [Header("Position")]
    public bool LongDi;
    public bool ShortDi;


    int lastTail;

    float curveConstant = 7.0f;

    float bulletCoolTime;
    public float bulletCoolTimelimit;
    public bool isStage7M;
    bool OnDebuff;
    float DebuffTime;
    int bulletCount;

    Transform friend;

    EnemyBullet bullet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player" && MiddleAttack == true) || (collision.gameObject.tag == "Enemy" && MiddleAttack == true))
        {
            curveConstant = 7.0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DebuffPad")
        {
            damage -= 1f;
            OnDebuff = true;
        }
    }

    private void Start()
    {
        bulletCoolTime = 0.0f;
        lastTail = -1;
        bulletCount = 0;

        myRigid = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (OnDebuff)
        {
            DebuffTime += Time.deltaTime;
            mySprite.color = new Color(0, 0, 1, 1);
        }

        if (DebuffTime >= 4.0f)
        {
            damage += 1f;
            OnDebuff = false;
        }

        if (PlayerMove.Instance.OnPause)
        {
            myRigid.velocity = new Vector2(0f, 0f);
            return;
        }
        
        CheckLastTail();
            
        if (MiddleAttack)
        {
            moveSpeed = 13f;
            MiddleAttacking();
        }
        else if (LongDi)
        {
            bulletCoolTime += Time.deltaTime;
            moveSpeed = 3.0f;
            LongDiAttacking();
        }

        else
        {
            GeneralAttacking();
        }


    }

    void GeneralAttacking()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        Collider2D[] friends = Physics2D.OverlapCircleAll(transform.position, 20.0f, 1 << 14);
        if (friends.Length > 0)
        {
            friend = friends[0].transform;
            float dis = (transform.position - friends[0].transform.position).sqrMagnitude;

            for (int i = 1; i < friends.Length; i++)
            {
                float dis2 = (transform.position - friends[i].transform.position).sqrMagnitude;
                if (dis > dis2)
                {
                    dis = dis2;
                    friend = friends[i].transform;
                }
            }

        }
        else
            friend = null;


        if (friend != null)
        {
            Movement(friend.position);

        }
        else
        {
            Movement(PlayerMove.Instance.transform.position);
        }

        
    }

    void MiddleAttacking()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        switch (lastTail)
        {
            case 0:
                CurveMovement(PlayerMove.Instance.transform.GetChild(0).position);
                break;
            case 1:
                CurveMovement(PlayerMove.Instance.transform.GetChild(1).position);
                break;
            case 2:
                CurveMovement(PlayerMove.Instance.transform.GetChild(1).position);
                break;
            case 3:
                CurveMovement(PlayerMove.Instance.transform.GetChild(2).position);
                break;
            case 4:
                CurveMovement(PlayerMove.Instance.transform.GetChild(2).position);
                break;
            default:
                break;

        }
    }


    void LongDiAttacking()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        Collider2D[] friends = Physics2D.OverlapCircleAll(transform.position, 20.0f, 1 << 14);
        if (friends.Length > 0)
        {
            friend = friends[0].transform;
            float dis = (transform.position - friends[0].transform.position).sqrMagnitude;

            for (int i = 1; i < friends.Length; i++)
            {
                float dis2 = (transform.position - friends[i].transform.position).sqrMagnitude;
                if (dis > dis2)
                {
                    dis = dis2;
                    friend = friends[i].transform;
                }
            }

        }
        else
            friend = null;

        if (friend != null)
        {
            Movement(friend.position);

        }
        else
        {
            Movement(PlayerMove.Instance.transform.position);
        }

        if (bulletCoolTime > bulletCoolTimelimit && friend != null && bulletPrefab != null)
        {
            bulletCount++;
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            if(bulletCount > 0 && (bulletCount % 3) == 0 && isStage7M == true)
            {
                bullet.transform.localScale = new Vector3(1.8f, 1.8f);
            }
            else
            {
                bullet.transform.localScale = new Vector3(1.2f, 1.2f);
            }
            bullet.LoadDamage(damage);
            bulletCoolTime = 0.0f;
        }
    }


    void CheckLastTail()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        int[] tails = BringIntArry("Tails");

        for (int i = 0; i < tails.Length; i++) 
        {
            if (tails[i] == 0 && this.gameObject.tag == "CuttingEnemy")
            {
                if (i == 0)
                {
                    lastTail = i -1;
                    moveSpeed = 4.9f;
                    MiddleAttack = false;
                    break;
                }
                else
                {
                    lastTail = i - 1;
                    moveSpeed = 13f;
                    MiddleAttack = true;
                    break;
                }
                
            }

            if (i == 4 && tails[i] != 0 && this.gameObject.tag == "CuttingEnemy")
                lastTail = 4;
        }
    }

    void Movement(Vector3 destination)
    {
        if (PlayerMove.Instance.OnPause)
            return;

        dir = destination - transform.position;
        dir = dir.normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion angleToQua = Quaternion.AngleAxis((angle - 90), Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);

        myRigid.velocity = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);
    }

    void CurveMovement(Vector3 destination) 
    {
        if (PlayerMove.Instance.OnPause)
            return;

        dir = destination - transform.position;
        dir += curveConstant * (new Vector3(dir.y, -dir.x, 0f));
        dir = dir.normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion angleToQua = Quaternion.AngleAxis((angle - 90), Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);

        myRigid.velocity = new Vector2 (dir.x * moveSpeed, dir.y * moveSpeed);

        curveConstant -= Time.deltaTime;

        if (curveConstant < 0f)
            curveConstant = 0f;


    }

    private int[] BringIntArry(string keyName)
    {
        string[] tempArry = PlayerPrefs.GetString(keyName).Split(',');
        int[] intArry = new int[tempArry.Length];
        for (int i = 0; i < intArry.Length; i++)
        {
            intArry[i] = System.Convert.ToInt32(tempArry[i]);
        }

        return intArry;
    }
}
