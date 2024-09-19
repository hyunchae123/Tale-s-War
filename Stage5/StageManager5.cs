using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager5 : MonoBehaviour
{
    [SerializeField] Tail[] tailPrefabs = new Tail[5];
    [SerializeField] PlayerMove player;
    [SerializeField] EnemyMove[] enemyPrefabs = new EnemyMove[3];
    [SerializeField] EnemyMove middleCuttingEnemy;
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
        PlayerMove.Instance.transform.position = new Vector3(12f, -30f, 0f);
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

        int[] remainTailsType = BringIntArry("Stage5Tailtype");
        float[] remainTailsPosX = BringFloatArry("Stage5TailX");
        float[] remainTailsPosY = BringFloatArry("Stage5TailY");

        for (int k = 0; k < remainTailsType.Length; k++)
        {
            if (remainTailsType[k] != 0)
            {
                remainTails[k] = Instantiate(tailPrefabs[remainTailsType[k] - 1], new Vector3(remainTailsPosX[k], remainTailsPosY[k], 0f), Quaternion.identity);
                remainTails[k].exterTail = true;

            }
        }

        PlayerPrefs.SetInt("PresentStageNum", 5);

    }

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();

        bool[] existingTail = BringBoolArry("ExistingTail");

        if (existingTail[4] == true)
        {
            Instantiate(existingTailObject, new Vector3(5f, -5f, 0f), Quaternion.identity);
        }


        Instantiate(enemyPrefabs[0], new Vector3(3f, -12f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(20f, -12f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(3f, -55f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(20f, -55f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(5f, -12f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[0], new Vector3(18f, -12f, 0f), Quaternion.identity);

        Instantiate(enemyPrefabs[1], new Vector3(-1f, 5f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[1], new Vector3(23f, 5f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[1], new Vector3(-1f, -64f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[1], new Vector3(23f, -64f, 0f), Quaternion.identity);
        Instantiate(enemyPrefabs[1], new Vector3(0f, 5f, 0f), Quaternion.identity);
    }

    void Update()
    {
        if (PlayerMove.Instance.enemyCount == 11 && isWave2 == false)
        {
            waveNum = 2;
            isWave2 = true;

            Instantiate(enemyPrefabs[0], new Vector3(3f, -12f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(20f, -12f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(3f, -55f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(20f, -55f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(5f, -12f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(18f, -12f, 0f), Quaternion.identity);

            Instantiate(enemyPrefabs[1], new Vector3(-2f, 6f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(23f, 6f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(-2f, -65f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(23f, -65f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(1f, 6f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(21f, 6f, 0f), Quaternion.identity);
        }
            

        if (PlayerMove.Instance.enemyCount == 23 && isWave3 == false)
        {
            waveNum = 3;
            isWave3 = true;

            Instantiate(enemyPrefabs[0], new Vector3(3f, -12f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(20f, -12f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(3f, -55f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(20f, -55f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(5f, -12f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[0], new Vector3(18f, -12f, 0f), Quaternion.identity);

            Instantiate(enemyPrefabs[1], new Vector3(-2f, 6f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(23f, 6f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(-2f, -65f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(23f, -65f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[1], new Vector3(1f, 6f, 0f), Quaternion.identity);

            Instantiate(enemyPrefabs[2], new Vector3(12f, -30f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(17f, -30f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(7f, -30f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(12f, -35f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(17f, -35f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(7f, -35f, 0f), Quaternion.identity);
            Instantiate(enemyPrefabs[2], new Vector3(12f, -40f, 0f), Quaternion.identity);

            Instantiate(middleCuttingEnemy, new Vector3(12f, -40f, 0f), Quaternion.identity);
        }
            

        if (PlayerMove.Instance.enemyCount == 41)
        {
            myAudio.Stop();
            waveNum = 4;
            PlayerPrefs.SetInt("AbleStageLevel", 6);
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
