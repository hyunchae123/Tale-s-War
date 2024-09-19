using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Image playerHP;
    [SerializeField] Image shieldIcon1;
    [SerializeField] Image shieldIcon2;
    [SerializeField] Image BuffIcon;

    int shieldNum;

    void Start()
    {
        shieldNum = 0;

        int[] tails = BringIntArry("Tails");

        for (int i = 0; i < tails.Length; i++)
        {
            if (tails[i] == 5)
                shieldNum++;

            if (shieldNum >= 3)
                shieldNum = 2;
        }

        if(shieldNum == 1)
            shieldIcon1.gameObject.SetActive(true);

        if(shieldNum == 2)
            shieldIcon2.gameObject.SetActive(true);
    }

    void Update()
    {
        shieldNum = 0;

        int[] tails = BringIntArry("Tails");

        for (int i = 0; i < tails.Length; i++)
        {
            if (tails[i] == 5)
                shieldNum++;

            if (shieldNum >= 3)
                shieldNum = 2;
        }

        if (shieldNum == 1)
            shieldIcon1.gameObject.SetActive(true);
        else if(shieldNum == 2)
            shieldIcon2.gameObject.SetActive(true);
        else
        {
            shieldIcon1.gameObject.SetActive(false);
            shieldIcon2.gameObject.SetActive(false);
        }

        if(PlayerMove.Instance.OnBuff == true)
            BuffIcon.gameObject.SetActive(true);

        playerHP.fillAmount = PlayerMove.Instance.hp / 50f;
    }

    private int[] BringIntArry(string keyName)
    {
        string[] tempArry = PlayerPrefs.GetString(keyName).Split(',');
        int[] intArry = new int[tempArry.Length];
        for (int i = 0; i < intArry.Length; i++)
        {
            intArry[i] = System.Convert.ToInt32(tempArry[i]);
        }

        return intArry;
    }
}
