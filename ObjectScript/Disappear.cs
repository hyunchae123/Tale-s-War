using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public bool isCrash;
    float alpha = 1f;
    SpriteRenderer mySprite;
    Tail tail;
    Rigidbody2D myRigid;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tail")
        {
            tail = collision.gameObject.GetComponent<Tail>();

            if (tail != null && tail.PosNum >= 0) 
            {
                isCrash = true;
            }
        }
            

    }

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myRigid = GetComponent<Rigidbody2D>();
        isCrash = false;
    }

    void Update()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        mySprite.color = new Color(1, 1, 1, alpha);

        if (isCrash)
        {
            myRigid.velocity = Vector3.zero;
            alpha -= Time.deltaTime;
        }

        if (alpha <= 0)
            Destroy(this.gameObject);
    }
}
