using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager4 : MonoBehaviour
{
    [SerializeField] Tail[] tailPrefabs = new Tail[5];
    [SerializeField] PlayerMove player;
    [SerializeField] EnemyMove[] enemyPrefabs = new EnemyMove[3];
    [SerializeField] GameObject existingTailObject;

    public int waveNum;

    bool isWave2;
    bool isWave3;

    Tail[] chaseTails = new Tail[5];
    Tail[] remainTails = new Tail[5];

    AudioSource myAudio;
    void Awake()
    {
        waveNum = 1;

        Instantiate(player);
        PlayerMove.Instance.transform.position = new Vector3(12f, -20f, 0f);
        Instantiate(PlayerMove.Instance.tailPos, PlayerMove.Instance.transform.position, Quaternion.identity);

        int[] tails = BringIntArry("Tails");

        for (int i = 0; i < tails.Length; i++)
        {
            if (tails[i] != 0)
            {
                for (int j = 0; j < tailPrefabs.Length; j++)
                {
                    if (tailPrefabs[j].myTailType == tails[i])
                    {
                        chaseTails[i] = Instantiate(tailPrefabs[j], PlayerMove.Instance.transform.GetChild(i).position, Quaternion.identity);
                        chaseTails[i].PosNum = i;
                        chaseTails[i].isChaseTail = true;
                        chaseTails[i].exterTail = true;
                        PlayerMove.Instance.isTails[i] = true;
                        PlayerMove.Instance.followTails[i] = chaseTails[i];
                    }
                }

            }
        }


        int[] remainTailsType = BringIntArry("Stage4Tailtype");
        float[] remainTailsPosX = BringFloatArry("Stage4TailX");
        float[] remainTailsPosY = BringFloatArry("Stage4TailY");

        for (int k = 0; k < remainTailsType.Length; k++)
        {
            if (remainTailsType[k] != 0)
            {
                remainTails[k] = Instantiate(tailPrefabs[remainTailsType[k] - 1], new Vector3(remainTailsPosX[k], remainTailsPosY[k], 0f), Quaternion.identity);
                remainTails[k].exterTail = true;

            }
        }

        PlayerPrefs.SetInt("PresentStageNum", 4);

    }

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();

        bool[] existingTail = BringBoolArry("ExistingTail");

        if (existingTail[3] == true)
        {
            Instantiate(existingTailObject, new Vector3(5f, -5f, 0f), Quaternion.identity);
        }


        Instantiate(enemyPrefabs[0], new Vector3(3f, -10f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(18f, -10f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(3f, -40f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(18f, -40f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(5f, -10f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(16f, -10f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(5f, -40f, 0f), Quaternion.identity);

        Instantiate(enemyPrefabs[1], new Vector3(-1f, 5f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[1], new Vector3(22f, 5f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[1], new Vector3(-1f, -45f, 0f), Quaternion.identity);
    }
    void Update()
    {
        if (PlayerMove.Instance.enemyCount == 10 && isWave2 == false)
        {
            waveNum = 2;
            isWave2 = true;

            Instantiate(enemyPrefabs[0], new Vector3(3f, -10f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(20f, -10f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(3f, -40f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(20f, -40f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(5f, -10f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(18f, -10f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(5f, -40f, 0f), Quaternion.identity);

            Instantiate(enemyPrefabs[1], new Vector3(-1f, 5f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(22f, 5f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(-1f, -45f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(22f, -45f, 0f), Quaternion.identity);
        }
            

        if (PlayerMove.Instance.enemyCount == 21 && isWave3 == false)
        {
            waveNum = 3;
            isWave3 = true;

            Instantiate(enemyPrefabs[0], new Vector3(3f, -10f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(20f, -10f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(3f, -40f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(20f, -40f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(5f, -10f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(18f, -10f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(5f, -40f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(18f, -40f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(16f, -40f, 0f), Quaternion.identity);

            Instantiate(enemyPrefabs[1], new Vector3(-1f, 5f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(23f, 5f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(-1f, -45f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(23f, -45f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(0f, 5f, 0f), Quaternion.identity);

            Instantiate(enemyPrefabs[2], new Vector3(12f, -20f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(15f, -20f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(9f, -20f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(12f, -16f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(15f, -16f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(9f, -16f, 0f), Quaternion.identity);
        }
            

        if (PlayerMove.Instance.enemyCount == 41)
        {
            myAudio.Stop();
            waveNum = 4;
            PlayerPrefs.SetInt("AbleStageLevel", 5);
            PlayerPrefs.Save();
        }
            
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

    private float[] BringFloatArry(string keyName)
    {
        string[] tempArry = PlayerPrefs.GetString(keyName).Split(',');
        float[] floatArry = new float[tempArry.Length];
        for (int i = 0; i < tempArry.Length; i++)
        {
            floatArry[i] = float.Parse(tempArry[i]);
        }

        return floatArry;
    }

    private bool[] BringBoolArry(string keyName)
    {
        string[] tempArry = PlayerPrefs.GetString(keyName).Split(',');
        bool[] boolArry = new bool[tempArry.Length];
        for (int i = 0; i < tempArry.Length; i++)
        {
            boolArry[i] = System.Convert.ToBoolean(tempArry[i]);
        }

        return boolArry;
    }
}
