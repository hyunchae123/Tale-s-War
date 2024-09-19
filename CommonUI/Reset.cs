using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public void SelectReset()
    {
        PlayerPrefs.SetInt("isFirstStart", 0);
        PlayerPrefs.Save();

    }
}
