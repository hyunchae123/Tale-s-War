using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffPad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && (other.gameObject.tag == "Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
