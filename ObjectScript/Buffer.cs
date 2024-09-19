using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    [SerializeField] BuffBullet buffBullet;

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

        if(Me.isChaseTail && skillCoolTime >= 7.0f)
        {
            skillCoolTime = 0.0f;
            Instantiate(buffBullet, weapons[0].transform.GetChild(0).transform.position, Quaternion.identity).GetComponent<BuffBullet>().Directing(transform.up * (-1));
        }
    }
}
