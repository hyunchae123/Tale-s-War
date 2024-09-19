using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] GameObject dealerBullet;

    [Header("Weapons")]
    [SerializeField] GameObject[] weapons;

    Tail Me;

    float skillCoolTime;

    void Start()
    {
        Me = GetComponent<Tail>();

        skillCoolTime = 0.0f;
    }

    private void Update()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        skillCoolTime += Time.deltaTime;
        Collider2D[] monsters = Physics2D.OverlapCircleAll(transform.position, 20.0f, 1 << 7);
        if (Me.isChaseTail && skillCoolTime >= 3.0f)
        {
            skillCoolTime = 0.0f;
            if (monsters.Length > 0)
                Instantiate(dealerBullet, weapons[0].transform.GetChild(0).transform.position, Quaternion.identity);
        }
    }

}
