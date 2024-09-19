using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tail : MonoBehaviour
{
    [SerializeField] GameObject BasicBulletPrefab;

    [Header("Weapons")]
    [SerializeField] GameObject[] weapons;

    public int myTailType;

    public bool isChaseTail;

    float moveSpeed = 20f;

    public int PosNum;

    Rigidbody2D myRigid;

    Transform enemy;

    public float hp;

    private bool isStun;
    private float stunTime;

    public bool exterTail;

    float bulletCoolTime;
    public float bulletCoolTimeFix;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isChaseTail == false && isStun == false && exterTail == false)
        {
            int[] tails = BringIntArry("Tails");

            for (int i = 0; i < tails.Length; i++) 
            {
                if (tails[i] == 0)
                {
                    PlayerMove.Instance.isTails[i] = true;
                    tails[i] = this.myTailType;
                    PosNum = i;
                    PlayerMove.Instance.followTails[i] = this;
                    SaveIntArry(tails, "Tails");
                    break;
                }
            }

            if(PosNum >= 0)
            {
                TailHPBarManager.Instance.Tailhp[PosNum] = hp;
                isChaseTail = true;
                bool[] existingTail = BringBoolArry("ExistingTail");
                existingTail[PlayerPrefs.GetInt("PresentStageNum") - 1] = false;
                SaveBoolArry(existingTail, "ExistingTail");
                exterTail = true;
            }

        }

        if (collision.gameObject.CompareTag("Player") && isChaseTail == false && isStun == false && exterTail == true)
        {
            int[] tails = BringIntArry("Tails");

            for (int i = 0; i < tails.Length; i++)
            {
                if (tails[i] == 0)
                {
                    PlayerMove.Instance.isTails[i] = true;
                    tails[i] = this.myTailType;
                    PosNum = i;
                    PlayerMove.Instance.followTails[i] = this;
                    SaveIntArry(tails, "Tails");
                    break;
                }
            }
            if (PosNum >= 0)
            {
                TailHPBarManager.Instance.Tailhp[PosNum] = hp;
                isChaseTail = true;

                switch (PlayerPrefs.GetInt("PresentStageNum"))
                {
                    case 1:
                        int[] tailtype = BringIntArry("Stage1Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage1Tailtype");

                        float[] tailX = BringFloatArry("Stage1TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage1TailX");

                        float[] tailY = BringFloatArry("Stage1TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage1TailY");
                        break;
                    case 2:
                        tailtype = BringIntArry("Stage2Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage2Tailtype");

                        tailX = BringFloatArry("Stage2TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage2TailX");

                        tailY = BringFloatArry("Stage2TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage2TailY");
                        break;
                    case 3:
                        tailtype = BringIntArry("Stage3Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage3Tailtype");

                        tailX = BringFloatArry("Stage3TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage3TailX");

                        tailY = BringFloatArry("Stage3TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage3TailY");
                        break;
                    case 4:
                        tailtype = BringIntArry("Stage4Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage4Tailtype");

                        tailX = BringFloatArry("Stage4TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage4TailX");

                        tailY = BringFloatArry("Stage4TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage4TailY");
                        break;
                    case 5:
                        tailtype = BringIntArry("Stage5Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage5Tailtype");

                        tailX = BringFloatArry("Stage5TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage5TailX");

                        tailY = BringFloatArry("Stage5TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage5TailY");
                        break;
                    case 6:
                        tailtype = BringIntArry("Stage6Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage6Tailtype");

                        tailX = BringFloatArry("Stage6TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage6TailX");

                        tailY = BringFloatArry("Stage6TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage6TailY");
                        break;
                    case 7:
                        tailtype = BringIntArry("Stage7Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage7Tailtype");

                        tailX = BringFloatArry("Stage7TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage7TailX");

                        tailY = BringFloatArry("Stage7TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage7TailY");
                        break;
                    case 8:
                        tailtype = BringIntArry("Stage8Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage8Tailtype");

                        tailX = BringFloatArry("Stage8TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage8TailX");

                        tailY = BringFloatArry("Stage8TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage8TailY");
                        break;
                    case 9:
                        tailtype = BringIntArry("Stage9Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage9Tailtype");

                        tailX = BringFloatArry("Stage9TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage9TailX");

                        tailY = BringFloatArry("Stage9TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage9TailY");
                        break;
                    case 10:
                        tailtype = BringIntArry("Stage10Tailtype");
                        tailtype[PosNum] = 0;
                        SaveIntArry(tailtype, "Stage10Tailtype");

                        tailX = BringFloatArry("Stage10TailX");
                        tailX[PosNum] = 0f;
                        SaveFloatArry(tailX, "Stage10TailX");

                        tailY = BringFloatArry("Stage10TailY");
                        tailY[PosNum] = 0f;
                        SaveFloatArry(tailY, "Stage10TailY");
                        break;
                    default:
                        break;
                }
            }
        }

        if (collision.gameObject.CompareTag("CuttingEnemy") && isChaseTail == true)
        {
            int[] tails = BringIntArry("Tails");

            for (int i = PosNum; i < tails.Length; i++)
            {
                tails[i] = 0;
                PlayerMove.Instance.isTails[i] = false;
                PlayerMove.Instance.followTails[i] = null;
            }

            SaveIntArry(tails, "Tails");

            isChaseTail = false;
        }

    }

    private void Start()
    {
        isStun = false;
        stunTime = 0.0f;
        myRigid = GetComponent<Rigidbody2D>();
        hp = 30f;

    }

    private void Update()
    {
        if (PosNum != -1 && PlayerMove.Instance.isTails[PosNum] == false)
        {
            isChaseTail = false;
            int[] tails = BringIntArry("Tails");
            tails[PosNum] = 0;
            PlayerMove.Instance.followTails[PosNum] = null;
            SaveIntArry(tails, "Tails");

            switch (PlayerPrefs.GetInt("PresentStageNum"))
            {
                case 1:
                    int[] tailtype = BringIntArry("Stage1Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage1Tailtype");

                    float[] tailX = BringFloatArry("Stage1TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage1TailX");

                    float[] tailY = BringFloatArry("Stage1TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage1TailY");
                    break;
                case 2:
                    tailtype = BringIntArry("Stage2Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage2Tailtype");

                    tailX = BringFloatArry("Stage2TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage2TailX");

                    tailY = BringFloatArry("Stage2TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage2TailY");
                    break;
                case 3:
                    tailtype = BringIntArry("Stage3Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage3Tailtype");

                    tailX = BringFloatArry("Stage3TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage3TailX");

                    tailY = BringFloatArry("Stage3TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage3TailY");
                    break;
                case 4:
                    tailtype = BringIntArry("Stage4Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage4Tailtype");

                    tailX = BringFloatArry("Stage4TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage4TailX");

                    tailY = BringFloatArry("Stage4TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage4TailY");
                    break;
                case 5:
                    tailtype = BringIntArry("Stage5Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage5Tailtype");

                    tailX = BringFloatArry("Stage5TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage5TailX");

                    tailY = BringFloatArry("Stage5TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage5TailY");
                    break;
                case 6:
                    tailtype = BringIntArry("Stage6Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage6Tailtype");

                    tailX = BringFloatArry("Stage6TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage6TailX");

                    tailY = BringFloatArry("Stage6TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage6TailY");
                    break;
                case 7:
                    tailtype = BringIntArry("Stage7Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage7Tailtype");

                    tailX = BringFloatArry("Stage7TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage7TailX");

                    tailY = BringFloatArry("Stage7TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage7TailY");
                    break;
                case 8:
                    tailtype = BringIntArry("Stage8Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage8Tailtype");

                    tailX = BringFloatArry("Stage8TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage8TailX");

                    tailY = BringFloatArry("Stage8TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage8TailY");
                    break;
                case 9:
                    tailtype = BringIntArry("Stage9Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage9Tailtype");

                    tailX = BringFloatArry("Stage9TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage9TailX");

                    tailY = BringFloatArry("Stage9TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage9TailY");
                    break;
                case 10:
                    tailtype = BringIntArry("Stage10Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage10Tailtype");

                    tailX = BringFloatArry("Stage10TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage10TailX");

                    tailY = BringFloatArry("Stage10TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage10TailY");
                    break;
                default:
                    break;
            }

            PosNum = -1;

        }

        if (isChaseTail && PosNum >= 0)
        {
            this.gameObject.layer = 14;

            transform.position = Vector3.MoveTowards(transform.position, TailPosition.Instance.transform.GetChild(PosNum).position, Time.deltaTime * moveSpeed);

            if(PlayerMove.Instance.myRigid.velocity.x != 0 && PlayerMove.Instance.myRigid.velocity.y != 0)
            {
                float x = PlayerMove.Instance.myRigid.velocity.x * Mathf.Pow(-1, PosNum);
                float y = PlayerMove.Instance.myRigid.velocity.y * PosNum;
                Vector3 dir = new Vector3(x, y, 0);
                dir = dir.normalized;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion angleToQua = Quaternion.AngleAxis((angle + 90), Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, angleToQua, 0.5f);
            }
            else
            {
                transform.rotation = TailPosition.Instance.transform.rotation;
            }

            bulletCoolTime += Time.deltaTime;

            if (bulletCoolTime > bulletCoolTimeFix)
            {
                MakingBullet();
                bulletCoolTime = 0.0f;
            }
        }
        else
        {
            this.gameObject.layer = 10;
            bulletCoolTime = 0.0f;
        }

        if (hp <= 0 && PosNum >= 0)
        {
            switch (PlayerPrefs.GetInt("PresentStageNum"))
            {
                case 1:
                    int[] tailtype = BringIntArry("Stage1Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage1Tailtype");

                    float[] tailX = BringFloatArry("Stage1TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage1TailX");

                    float[] tailY = BringFloatArry("Stage1TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage1TailY");
                    break;
                case 2:
                    tailtype = BringIntArry("Stage2Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage2Tailtype");

                    tailX = BringFloatArry("Stage2TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage2TailX");

                    tailY = BringFloatArry("Stage2TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage2TailY");
                    break;
                case 3:
                    tailtype = BringIntArry("Stage3Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage3Tailtype");

                    tailX = BringFloatArry("Stage3TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage3TailX");

                    tailY = BringFloatArry("Stage3TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage3TailY");
                    break;
                case 4:
                    tailtype = BringIntArry("Stage4Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage4Tailtype");

                    tailX = BringFloatArry("Stage4TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage4TailX");

                    tailY = BringFloatArry("Stage4TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage4TailY");
                    break;
                case 5:
                    tailtype = BringIntArry("Stage5Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage5Tailtype");

                    tailX = BringFloatArry("Stage5TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage5TailX");

                    tailY = BringFloatArry("Stage5TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage5TailY");
                    break;
                case 6:
                    tailtype = BringIntArry("Stage6Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage6Tailtype");

                    tailX = BringFloatArry("Stage6TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage6TailX");

                    tailY = BringFloatArry("Stage6TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage6TailY");
                    break;
                case 7:
                    tailtype = BringIntArry("Stage7Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage7Tailtype");

                    tailX = BringFloatArry("Stage7TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage7TailX");

                    tailY = BringFloatArry("Stage7TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage7TailY");
                    break;
                case 8:
                    tailtype = BringIntArry("Stage8Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage8Tailtype");

                    tailX = BringFloatArry("Stage8TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage8TailX");

                    tailY = BringFloatArry("Stage8TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage8TailY");
                    break;
                case 9:
                    tailtype = BringIntArry("Stage9Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage9Tailtype");

                    tailX = BringFloatArry("Stage9TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage9TailX");

                    tailY = BringFloatArry("Stage9TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage9TailY");
                    break;
                case 10:
                    tailtype = BringIntArry("Stage10Tailtype");
                    tailtype[PosNum] = this.myTailType;
                    SaveIntArry(tailtype, "Stage10Tailtype");

                    tailX = BringFloatArry("Stage10TailX");
                    tailX[PosNum] = this.transform.position.x;
                    SaveFloatArry(tailX, "Stage10TailX");

                    tailY = BringFloatArry("Stage10TailY");
                    tailY[PosNum] = this.transform.position.y;
                    SaveFloatArry(tailY, "Stage10TailY");
                    break;
                default:
                    break;
            }

            PlayerMove.Instance.isTails[PosNum] = false;
            PlayerMove.Instance.followTails[PosNum] = null;
            isChaseTail = false;

            int[] tails = BringIntArry("Tails");
            tails[PosNum] = 0;
            SaveIntArry(tails, "Tails");

            isStun = true;
            PosNum = -1;
        }

        myRigid.velocity = new Vector2(0f, 0f);

        if (isStun == true)
        {
            stunTime += Time.deltaTime;
        }

        if (stunTime >= 3.0f)
        {
            isStun = false;
            stunTime = 0.0f;
            hp = 30f;
        }

        if (PosNum >= 0)
            TailHPBarManager.Instance.Tailhp[PosNum] = hp;
    }

    private void MakingBullet()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        Instantiate(BasicBulletPrefab, weapons[0].transform.GetChild(0).transform.position, Quaternion.identity).GetComponent<TailBullet>().Directing(transform.up * (-1));
    }

    public void UnderAttack(float damage)
    {
        if (PlayerMove.Instance.OnPause)
            return;

        hp = Mathf.Clamp(hp - damage, 0f, 30f);
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
