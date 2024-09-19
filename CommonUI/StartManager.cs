using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] Image StartBackground;
    [SerializeField] Sprite Background1;
    [SerializeField] Sprite Background2;
    [SerializeField] Sprite Background3;

    int RandomNum;

    void Start()
    {
        RandomNum = Random.Range(1, 4);

        switch(RandomNum)
        {
            case 1:
                StartBackground.sprite = Background1;
                break;
            case 2:
                StartBackground.sprite = Background2;
                break;
            case 3:
                StartBackground.sprite = Background3;
                break;
            default:
                break;

        }
    }

}
