using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailBullet : MonoBehaviour
{
    EnemyHP enemyHP;

    public float Damage;
    Vector2 dir;

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        float angle = Mathf.Atan2(this.dir.y, this.dir.x) * Mathf.Rad2Deg;
        Quaternion angleToQua = Quaternion.AngleAxis((angle + 90), Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3)dir * 10f, Time.deltaTime * 20.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerMove.Instance.OnPause)
            return;

        if (other != null && (other.gameObject.tag == "Enemy" || other.gameObject.tag == "CuttingEnemy"))
        {
            enemyHP = other.gameObject.GetComponent<EnemyHP>();
            enemyHP.UnderAttack(Damage);
            Destroy(this.gameObject);
        }
    }

    public void Directing(Vector2 dir)
    {
        this.dir = dir;
    }
}
