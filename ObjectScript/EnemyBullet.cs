using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Vector3 destination;
    Transform friend;
    Tail tail;

    private float damage;

    private void Start()
    {
        if(this.gameObject.tag == "Stage5Lbullet" || this.gameObject.tag == "Stage6Mbullet")
        {
            destination = 10 * (PlayerMove.Instance.transform.position - transform.position);
        }
        else
        {
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
                destination = 10 * (friend.position - transform.position);

            }
        }

    }
    void Update()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        Movement();

        if(transform.position == destination)
            Destroy(this.gameObject);

    }

    public void Movement()
    {
        if (PlayerMove.Instance.OnPause)
            return;


        Vector3 dir = transform.position - destination;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion angleToQua = Quaternion.AngleAxis((angle - 90), Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 15.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerMove.Instance.OnPause)
            return;

        if (this.gameObject.tag == "Stage5Lbullet")
        {
            if (other != null && other.gameObject.tag == "Player")
            {
                PlayerMove.Instance.UnderAttack(damage);
                PlayerMove.Instance.ReduceSpeed();
                Destroy(this.gameObject);
            }
        }
        else if (this.gameObject.tag == "Stage6Mbullet")
        {
            if (other != null && other.gameObject.tag == "Player")
            {
                PlayerMove.Instance.UnderAttack(damage);
                PlayerMove.Instance.ReduceDamage();
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (other != null && other.gameObject.tag == "Player")
            {
                PlayerMove.Instance.UnderAttack(damage);
                Destroy(this.gameObject);
            }
            else if (other != null && other.gameObject.tag == "Tail")
            {
                tail = other.GetComponent<Tail>();
                if (tail.isChaseTail == true)
                {
                    tail.UnderAttack(damage);
                    Destroy(this.gameObject);
                }

            }
        }
        
    }

    public void LoadDamage(float damage)
    {
        this.damage = damage;
    }
}
