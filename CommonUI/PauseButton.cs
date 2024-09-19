using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] Image PauseScreen;

    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void SelectPauseButton()
    {
        myAudio.Play();
        PlayerMove.Instance.OnPause = true;
        PauseScreen.gameObject.SetActive(true);
    }

    public void SelectStartButton()
    {
        myAudio.Play();
        PlayerMove.Instance.OnPause = false;
        PauseScreen.gameObject.SetActive(false);
    }
}
