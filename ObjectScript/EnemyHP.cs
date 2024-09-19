using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] AudioClip DeathSound;

    public float HP;
    EnemyMove enemyMove;
    AudioSource myAudio;

    bool isdead;

    private void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        if (HP <= 0 && this.gameObject.tag == "Enemy")
        {
            if(isdead == false)
            {
                myAudio.PlayOneShot(DeathSound);
                isdead = true;
            }
            
            if(!myAudio.isPlaying)
            {
                Destroy(gameObject);
                PlayerMove.Instance.enemyCount++;
            }
           
        }
            
    }

    public void UnderAttack(float damage)
    {
        if (PlayerMove.Instance.OnPause)
            return;

        transform.position = new Vector3(transform.position.x - enemyMove.dir.x * 1, transform.position.y - enemyMove.dir.y * 1, 0);
        HP -= damage;
    }
}
