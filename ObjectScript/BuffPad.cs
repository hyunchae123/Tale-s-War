using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && (other.gameObject.tag == "Player"))
        {
            PlayerMove.Instance.OnBuff = true;
            Destroy(this.gameObject);
        }
    }

}
