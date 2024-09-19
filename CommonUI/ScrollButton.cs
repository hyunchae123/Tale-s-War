using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollButton : MonoBehaviour
{
    [SerializeField] RectTransform Stages;

    AudioSource myAudio;

    int PresentStageNum = 0;

    private void Start()
    {
        PresentStageNum = 1;
        myAudio = GetComponent<AudioSource>();
    }

    public void SelectRightButton()
    {
        myAudio.Play();

        if (PresentStageNum != 10)
            PresentStageNum++;

        if (Stages.anchoredPosition.x == -4760)
            return;
        else
        {
            Stages.anchoredPosition = new Vector2(Stages.anchoredPosition.x - 1080, Stages.anchoredPosition.y);
        }
    }

    public void SelectLeftButton()
    {
        myAudio.Play();

        if(PresentStageNum != 1)
            PresentStageNum--;

        if (Stages.anchoredPosition.x == 4960)
            return;
        else
        {
            Stages.anchoredPosition = new Vector2(Stages.anchoredPosition.x + 1080, Stages.anchoredPosition.y);
        }
    }

    public void SelectStart()
    {
        myAudio.Play();

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 1 && PresentStageNum == 1)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage1");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 2 && PresentStageNum == 2)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage2");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 3 && PresentStageNum == 3)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage3");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 4 && PresentStageNum == 4)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage4");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 5 && PresentStageNum == 5)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage5");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 6 && PresentStageNum == 6)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage6");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 7 && PresentStageNum == 7)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage7");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 8 && PresentStageNum == 8)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage8");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 9 && PresentStageNum == 9)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage9");
        }

        if (PlayerPrefs.GetInt("AbleStageLevel") >= 10 && PresentStageNum == 10)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage10");
        }
    }
}
