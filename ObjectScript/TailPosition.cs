using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPosition : Singleton<TailPosition>
{
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.position = new Vector3(PlayerMove.Instance.transform.position.x, PlayerMove.Instance.transform.position.y, 0f);

        Vector3 dir = new Vector3(PlayerMove.Instance.x, PlayerMove.Instance.y, 0);
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion angleToQua = Quaternion.AngleAxis((angle + 90), Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
    }
}
