using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void Select1()
    {
        myAudio.Play();
        SceneManager.LoadScene("Stage1");
    }

    public void Select2()
    {
        if(PlayerPrefs.GetInt("AbleStageLevel") >= 2)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage2");
        }
        
    }

    public void Select3()
    {
        if (PlayerPrefs.GetInt("AbleStageLevel") >= 3)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage3");
        }
        
    }

    public void Select4()
    {
        if (PlayerPrefs.GetInt("AbleStageLevel") >= 4)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage4");
        }
        
    }

    public void Select5()
    {
        if (PlayerPrefs.GetInt("AbleStageLevel") >= 5)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage5");
        }
        
    }

    public void Select6()
    {
        if (PlayerPrefs.GetInt("AbleStageLevel") >= 6)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage6");
        }
        
    }

    public void Select7()
    {
        if (PlayerPrefs.GetInt("AbleStageLevel") >= 7)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage7");
        }
        
    }

    public void Select8()
    {
        if (PlayerPrefs.GetInt("AbleStageLevel") >= 8)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage8");
        }
        
    }

    public void Select9()
    {
        if (PlayerPrefs.GetInt("AbleStageLevel") >= 9)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage9");
        }
        
    }

    public void Select10()
    {
        if (PlayerPrefs.GetInt("AbleStageLevel") >= 10)
        {
            myAudio.Play();
            SceneManager.LoadScene("Stage10");
        }
        
    }
}
