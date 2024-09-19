using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void SelectQuitButton()
    {
        myAudio.Play();
        SceneManager.LoadScene("StageSelect");
        PlayerPrefs.Save();
    }
}
