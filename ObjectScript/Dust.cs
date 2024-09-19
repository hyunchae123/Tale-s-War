using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    void Update()
    {
        DustPlace();
    }

    void DustPlace()
    {
        transform.rotation = TailPosition.Instance.transform.rotation;

        if (PlayerMove.Instance.isTails[4] == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, TailPosition.Instance.transform.GetChild(5).transform.position, Time.deltaTime * 24f);
        }
        else
        {
            for (int i = 0; i < PlayerMove.Instance.isTails.Length; i++)
            {
                if (PlayerMove.Instance.isTails[i] == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, TailPosition.Instance.transform.GetChild(i).transform.position, Time.deltaTime * 24f);
                    break;
                }
            }
        }

    }
}
