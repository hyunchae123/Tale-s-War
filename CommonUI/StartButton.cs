using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void SelectStartButton()
    {
        myAudio.Play();
        SceneManager.LoadScene("StageSelect");
        PlayerPrefs.SetInt("isFirstStart", PlayerPrefs.GetInt("isFirstStart", 0) + 1);
        PlayerPrefs.Save();
    }
}
