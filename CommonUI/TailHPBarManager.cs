using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TailHPBarManager : Singleton<TailHPBarManager>
{
    [Header("HPBar")]
    [SerializeField] Image[] HPBarUI = new Image[5];
    [SerializeField] Image[] CharUI = new Image[5];

    public float[] Tailhp = new float[5];

    private void Start()
    {
        for (int i = 0; i < PlayerMove.Instance.followTails.Length; i++)
        {
            if (PlayerMove.Instance.followTails[i] != null)
            {
                HPBarUI[i].gameObject.SetActive(true);
                HPBarUI[i].fillAmount = PlayerMove.Instance.followTails[i].hp / 30f;
                switch (PlayerMove.Instance.followTails[i].myTailType)
                {
                    case 1:
                        CharUI[i].sprite = Resources.Load<Sprite>("Healer");
                        break;
                    case 2:
                        CharUI[i].sprite = Resources.Load<Sprite>("Dealer");
                        break;
                    case 3:
                        CharUI[i].sprite = Resources.Load<Sprite>("Buffer");
                        break;
                    case 4:
                        CharUI[i].sprite = Resources.Load<Sprite>("Debuffer");
                        break;
                    case 5:
                        CharUI[i].sprite = Resources.Load<Sprite>("Shielder");
                        break;
                    default:
                        break;

                }
            }
            else
            {
                HPBarUI[i].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < PlayerMove.Instance.followTails.Length; i++)
        {
            if (PlayerMove.Instance.followTails[i] != null)
            {
                HPBarUI[i].gameObject.SetActive(true);
                HPBarUI[i].fillAmount = PlayerMove.Instance.followTails[i].hp / 30f;
                switch (PlayerMove.Instance.followTails[i].myTailType)
                {
                    case 1:
                        CharUI[i].sprite = Resources.Load<Sprite>("Healer");
                        break;
                    case 2:
                        CharUI[i].sprite = Resources.Load<Sprite>("Dealer");
                        break;
                    case 3:
                        CharUI[i].sprite = Resources.Load<Sprite>("Buffer");
                        break;
                    case 4:
                        CharUI[i].sprite = Resources.Load<Sprite>("Debuffer");
                        break;
                    case 5:
                        CharUI[i].sprite = Resources.Load<Sprite>("Shielder");
                        break;
                    default:
                        break;

                }
            }
            else
            {
                HPBarUI[i].gameObject.SetActive(false);
            }
        }
    }


}
