using UnityEditor;
using UnityEngine;

public class PlayerMove : Singleton<PlayerMove>
{
    private float fov = 120f;
    private float radius = 10f;

    private Color color = new Color(0, 1, 0, 0.3f);
    private float alertThreshold;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject Dust;

    [Header("Weapons")]
    [SerializeField] GameObject[] weapons;

    public bool[] isTails = new bool[5];
    public Tail[] followTails = new Tail[5];
    public GameObject tailPos;

    public float moveSpeed;
    public float hp;
    public float damage;

    Transform enemy;
    GameObject bullet;
    public Rigidbody2D myRigid;
    SpriteRenderer mySprite;
    AudioSource myAudio;

    float bulletCoolTime;

    public float x;
    public float y;

    public int enemyCount;

    public bool OnPause;
    public bool OnBuff;

    private bool OnDamage;
    private float OnDamageTime;
    private float BuffTime;
    private float ReduceSpeedTime;
    private float ReduceDamageTime;


    private void Start()
    {
        if (isTails[4] == true)
        {
            Instantiate(Dust, transform.GetChild(4).position + new Vector3(0f, 3.5f, 0f), Quaternion.identity);
        }
        else
        {
            for (int i = 0; i < isTails.Length; i++)
            {
                if (isTails[i] == false)
                {
                    Instantiate(Dust, transform.GetChild(i).position, Quaternion.identity);
                    break;
                }
            }
        }

        bulletCoolTime = 0.0f;
        alertThreshold = Mathf.Cos(fov / 2 * Mathf.Deg2Rad);
        enemyCount = 0;

        myRigid = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(OnBuff)
        {
            damage += 3f;
            BuffTime += Time.deltaTime;
        }
        
        if(BuffTime >= 5.0f)
        {
            damage -= 3f;
            OnBuff = false;
            BuffTime = 0.0f;
        }

        if (OnPause)
        {
            myRigid.velocity = new Vector2(0f, 0f);
            return;
        }

        if(hp <= 0f)
        {
            mySprite.color = new Color(1, 1, 1, 0);
            PlayerPrefs.Save();
        }

        bulletCoolTime += Time.deltaTime;

        Movement();
        Direction();

        if (bulletCoolTime > 2.0f)
        {
            MakingBullet();
            bulletCoolTime = 0.0f;
        }
        
        if (OnDamage)
        {
            OnDamageTime += Time.deltaTime;
            transform.GetChild(7).transform.localPosition = new Vector3(transform.GetChild(7).transform.localPosition.x, transform.GetChild(7).transform.localPosition.y + 0.15f, 0f);
        }

        if (OnDamageTime > 0.3f)
        {
            OnDamageTime = 0.0f;
            mySprite.color = new Color(1, 1, 1, 1);
            OnDamage = false;
            transform.GetChild(7).transform.localPosition = Vector3.zero;
        }

        if (ReduceSpeedTime > 0f)
        {
            ReduceSpeedTime -= Time.deltaTime;
        }
        if (ReduceSpeedTime < 0f)
        {
            ReduceSpeedTime = 0f;
            moveSpeed = 10f;
            mySprite.color = new Color(1, 1, 1, 1);
        }

        if(ReduceDamageTime > 0f)
        {
            ReduceDamageTime -= Time.deltaTime;
        }
        if (ReduceDamageTime < 0f)
        {
            ReduceDamageTime = 0f;
            damage = 5;
            mySprite.color = new Color(1, 1, 1, 1);
        }

    }

    private void Movement()
    {
        if (OnPause)
        {
            myRigid.velocity = new Vector2(0f, 0f);
            return;
        }
            
        Vector3 dir = new Vector3(x, y, 0);
        dir = dir.normalized;

        myRigid.velocity = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);
    }

    private void MakingBullet()
    {
        if (OnPause)
            return;

        Collider2D[] monsters = Physics2D.OverlapCircleAll(transform.position, 10.0f, 1 << 7);
        if (monsters.Length > 0)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                Vector2 targetDir = monsters[i].transform.position - transform.position;
                float dot = Vector2.Dot(transform.up * (-1), targetDir.normalized);
                if (targetDir.magnitude <= radius && dot >= alertThreshold)
                {
                    continue;
                }
                else
                {
                    monsters[i] = null;
                }
            }

            for (int j = 0; j < monsters.Length; j++)
            {
                if (monsters[j] == null)
                {
                    for (int k = j; k < monsters.Length; k++)
                    {
                        if (monsters[k] != null)
                        {
                            monsters[j] = monsters[k];
                            monsters[k] = null;
                            break;
                        }
                    }
                }
            }

            if (monsters[0] != null)
            {
                enemy = monsters[0].transform;
                float dis = (transform.position - monsters[0].transform.position).sqrMagnitude;

                for (int w = 1; w < monsters.Length; w++)
                {
                    if (monsters[w] != null)
                    {
                        float dis2 = (transform.position - monsters[w].transform.position).sqrMagnitude;
                        if (dis > dis2)
                        {
                            dis = dis2;
                            enemy = monsters[w].transform;
                        }
                    }
                    
                }
            }
        }
        else
            enemy = null;

        if (enemy != null)
        {
            bullet = Instantiate(bulletPrefab, weapons[0].transform.GetChild(0).transform.position, Quaternion.identity);
            
        }

    }

    //private void OnDrawGizmos()
    //{
    //    Handles.color = color;

    //    Vector2 startDirection = Quaternion.Euler(0, 0, fov / 2) * transform.up * (-1);

    //    Handles.DrawSolidArc(transform.position, Vector3.back, startDirection, fov, radius);
    //}

    private void Direction()
    {
        if (OnPause)
            return;

        Collider2D[] monsters = Physics2D.OverlapCircleAll(transform.position, 10.0f, 1 << 7);

        if(monsters.Length > 0)
        {
            for(int i = 0; i < monsters.Length; i++)
            {
                Vector2 targetDir = monsters[i].transform.position - transform.position;
                float dot = Vector2.Dot(transform.up * (-1), targetDir.normalized);
                if(targetDir.magnitude <= radius && dot >= alertThreshold)
                {
                    continue;
                }
                else
                {
                    monsters[i] = null;
                }
            }

            for(int j = 0; j < monsters.Length; j++)
            {
                if(monsters[j] == null)
                {
                    for(int k = j; k < monsters.Length; k++)
                    {
                        if (monsters[k] != null)
                        {
                            monsters[j] = monsters[k];
                            monsters[k] = null;
                            break;
                        }
                    }
                }
            }

            if (monsters[0] != null)
            {
                Transform enemy = monsters[0].transform;
                float dis = (transform.position - monsters[0].transform.position).sqrMagnitude;

                for (int w = 1; w < monsters.Length; w++)
                {
                    if (monsters[w] != null)
                    {
                        float dis2 = (transform.position - monsters[w].transform.position).sqrMagnitude;
                        if (dis > dis2)
                        {
                            dis = dis2;
                            enemy = monsters[w].transform;
                        }
                    }

                }

                Vector3 dir = transform.position - enemy.position;

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion angleToQua = Quaternion.AngleAxis((angle - 90), Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
            }
            else
            {
                Vector3 dir = new Vector3(x, y, 0);
                dir = dir.normalized;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion angleToQua = Quaternion.AngleAxis((angle + 90), Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
            }
            
        }
        else
        {
            Vector3 dir = new Vector3(x, y, 0);
            dir = dir.normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion angleToQua = Quaternion.AngleAxis((angle + 90), Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
        }

        if (Vector2.Dot(transform.up * (-1), new Vector2(x, y).normalized) < 0)
        {
            Vector3 dir = new Vector3(x, y, 0);
            dir = dir.normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion angleToQua = Quaternion.AngleAxis((angle + 90), Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
        }

    }

    public void UnderAttack(float damage)
    {
        if (OnPause)
            return;

        myAudio.Play();
        int shieldNum = 0;

        int[] tails = BringIntArry("Tails");

        for (int i = 0; i < tails.Length; i++) 
        {
            if (tails[i] == 5)
            {
                shieldNum++;

                if(shieldNum >= 3)
                    shieldNum = 2;
            }
        }

        OnDamage = true;
        
        hp = Mathf.Clamp(hp - damage + shieldNum, 0.0f, 100f);
        
    }
    public void ReduceSpeed()
    {
        moveSpeed = Mathf.Clamp(moveSpeed - 10 * 0.1f, 10 - 10 * 0.1f * 2, 10);
        mySprite.color = new Color(0.5f, 1, 0.5f, 1);
        ReduceSpeedTime = 1.5f;

    }

    public void ReduceDamage()
    {
        damage = Mathf.Clamp(damage - 2, 0, 5);
        mySprite.color = new Color(0.5f, 0.5f, 1, 1);
        ReduceDamageTime = 1.25f;

    }

    public void GetHeal(float heal)
    {
        if (OnPause)
            return;

        hp = Mathf.Clamp(hp + heal, 0.0f, 100f);
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
