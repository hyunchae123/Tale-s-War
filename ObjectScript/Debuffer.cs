using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffer : MonoBehaviour
{
    [SerializeField] DebuffBullet DebuffBullet;

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

        if (Me.isChaseTail && skillCoolTime >= 4.0f)
        {
            skillCoolTime = 0.0f;
            Instantiate(DebuffBullet, weapons[0].transform.GetChild(0).transform.position, Quaternion.identity).GetComponent<DebuffBullet>().Directing(transform.up * (-1));
        }
    }

}
