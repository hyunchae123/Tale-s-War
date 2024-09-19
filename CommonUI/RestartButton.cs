using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void SelectRestartButton()
    {
        myAudio.Play();

        switch (PlayerPrefs.GetInt("PresentStageNum"))
        {
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
            case 4:
                SceneManager.LoadScene("Stage4");
                break;
            case 5:
                SceneManager.LoadScene("Stage5");
                break;
            case 6:
                SceneManager.LoadScene("Stage6");
                break;
            case 7:
                SceneManager.LoadScene("Stage7");
                break;
            case 8:
                SceneManager.LoadScene("Stage8");
                break;
            case 9:
                SceneManager.LoadScene("Stage9");
                break;
            case 10:
                SceneManager.LoadScene("Stage10");
                break;
        }

    }
}
