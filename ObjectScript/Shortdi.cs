using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortdi : MonoBehaviour
{
    PlayerMove player;
    Tail tail;

    EnemyMove Me;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<PlayerMove>();
        }

        if(collision.gameObject.tag == "Tail")
        {
            tail = collision.gameObject.GetComponent<Tail>();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = null;
        }

        if (collision.gameObject.tag == "Tail")
        {
            tail = null;
        }
    }

    void Start()
    {
        Me = GetComponent<EnemyMove>();
        StartCoroutine(IEPlayerAttack());
    }


    public IEnumerator IEPlayerAttack()
    {
        while (true)
        {
            if (player != null)
            {
                player.UnderAttack(Me.damage);
            }

            if(tail != null && tail.isChaseTail == true) 
            {
                tail.UnderAttack(Me.damage);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
