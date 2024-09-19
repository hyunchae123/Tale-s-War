using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitialDatabase : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetInt("isFirstStart", 0) == 0)
        {
            int[] tails = new int[5];
            SaveIntArry(tails, "Tails");

            int PresentStageNum = 0;
            PlayerPrefs.SetInt("PresentStageNum", PresentStageNum);

            int ableStagelevel = 1;
            PlayerPrefs.SetInt("AbleStageLevel", ableStagelevel);

            bool[] existingTail = new bool[10];
            for(int i = 0; i < 10; i++)
            {
                existingTail[i] = true;
            }
            SaveBoolArry(existingTail, "ExistingTail");

            int[] Stage1Tailtype = new int[5];
            SaveIntArry(Stage1Tailtype, "Stage1Tailtype");

            float[] Stage1TailX = new float[5];
            SaveFloatArry(Stage1TailX, "Stage1TailX");

            float[] Stage1TailY = new float[5];
            SaveFloatArry(Stage1TailY, "Stage1TailY");

            int[] Stage2Tailtype = new int[5];
            SaveIntArry(Stage2Tailtype, "Stage2Tailtype");

            float[] Stage2TailX = new float[5];
            SaveFloatArry(Stage2TailX, "Stage2TailX");

            float[] Stage2TailY = new float[5];
            SaveFloatArry(Stage2TailY, "Stage2TailY");

            int[] Stage3Tailtype = new int[5];
            SaveIntArry(Stage3Tailtype, "Stage3Tailtype");

            float[] Stage3TailX = new float[5];
            SaveFloatArry(Stage3TailX, "Stage3TailX");

            float[] Stage3TailY = new float[5];
            SaveFloatArry(Stage3TailY, "Stage3TailY");

            int[] Stage4Tailtype = new int[5];
            SaveIntArry(Stage4Tailtype, "Stage4Tailtype");

            float[] Stage4TailX = new float[5];
            SaveFloatArry(Stage4TailX, "Stage4TailX");

            float[] Stage4TailY = new float[5];
            SaveFloatArry(Stage4TailY, "Stage4TailY");

            int[] Stage5Tailtype = new int[5];
            SaveIntArry(Stage5Tailtype, "Stage5Tailtype");

            float[] Stage5TailX = new float[5];
            SaveFloatArry(Stage5TailX, "Stage5TailX");

            float[] Stage5TailY = new float[5];
            SaveFloatArry(Stage5TailY, "Stage5TailY");

            int[] Stage6Tailtype = new int[5];
            SaveIntArry(Stage6Tailtype, "Stage6Tailtype");

            float[] Stage6TailX = new float[5];
            SaveFloatArry(Stage6TailX, "Stage6TailX");

            float[] Stage6TailY = new float[5];
            SaveFloatArry(Stage6TailY, "Stage6TailY");

            int[] Stage7Tailtype = new int[5];
            SaveIntArry(Stage7Tailtype, "Stage7Tailtype");

            float[] Stage7TailX = new float[5];
            SaveFloatArry(Stage7TailX, "Stage7TailX");

            float[] Stage7TailY = new float[5];
            SaveFloatArry(Stage7TailY, "Stage7TailY");

            int[] Stage8Tailtype = new int[5];
            SaveIntArry(Stage8Tailtype, "Stage8Tailtype");

            float[] Stage8TailX = new float[5];
            SaveFloatArry(Stage8TailX, "Stage8TailX");

            float[] Stage8TailY = new float[5];
            SaveFloatArry(Stage8TailY, "Stage8TailY");

            int[] Stage9Tailtype = new int[5];
            SaveIntArry(Stage9Tailtype, "Stage9Tailtype");

            float[] Stage9TailX = new float[5];
            SaveFloatArry(Stage9TailX, "Stage9TailX");

            float[] Stage9TailY = new float[5];
            SaveFloatArry(Stage9TailY, "Stage9TailY");

            int[] Stage10Tailtype = new int[5];
            SaveIntArry(Stage10Tailtype, "Stage10Tailtype");

            float[] Stage10TailX = new float[5];
            SaveFloatArry(Stage10TailX, "Stage10TailX");

            float[] Stage10TailY = new float[5];
            SaveFloatArry(Stage10TailY, "Stage10TailY");
        }

        PlayerPrefs.Save();
    }


    private void SaveIntArry(int[] arry, string keyName)
    {
        string strArr = "";
        for (int i = 0; i < arry.Length; i++)
        {
            strArr = strArr + arry[i];
            if (i < arry.Length - 1)
            {
                strArr = strArr + ",";
            }
        }
        PlayerPrefs.SetString(keyName, strArr);
    }

    private void SaveFloatArry(float[] arry, string keyName)
    {
        string strArr = "";
        for (int i = 0; i < arry.Length; i++)
        {
            strArr = strArr + arry[i];
            if (i < arry.Length - 1)
            {
                strArr = strArr + ",";
            }
        }
        PlayerPrefs.SetString(keyName, strArr);
    }

    private void SaveBoolArry(bool[] arry, string keyName)
    {
        string strArr = "";
        for (int i = 0; i < arry.Length; i++)
        {
            strArr = strArr + arry[i];
            if (i < arry.Length - 1)
            {
                strArr = strArr + ",";
            }
        }
        PlayerPrefs.SetString(keyName, strArr);
    }
}
