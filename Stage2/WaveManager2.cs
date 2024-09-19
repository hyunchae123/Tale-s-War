using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager2 : MonoBehaviour
{
    [SerializeField] Image wave1;
    [SerializeField] Image wave2;
    [SerializeField] Image wave3;
    [SerializeField] Image winImage;
    [SerializeField] StageManager2 stageManager2;
    [SerializeField] Image failedUI;

    void Start()
    {
        wave1.gameObject.SetActive(true);
    }

    void Update()
    {
        if (PlayerMove.Instance.hp <= 0)
        {
            failedUI.gameObject.SetActive(true);
            PlayerMove.Instance.OnPause = true;
        }

        if (stageManager2.waveNum == 2)
        {
            wave1.gameObject.SetActive(false);
            wave2.gameObject.SetActive(true);
        }

        if (stageManager2.waveNum == 3)
        {
            wave2.gameObject.SetActive(false);
            wave3.gameObject.SetActive(true);
        }

        if (stageManager2.waveNum == 4)
        {
            winImage.gameObject.SetActive(true);
        }
    }
}
