using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    FollowCamera followCamera;

    private float shakeTime;
    private float shakeIntensity;

    private void Start()
    {
        followCamera = GetComponent<FollowCamera>();
    }

    bool hp30check;
    bool hp20check;
    bool hp10check;

    void Update()
    {
        if(PlayerMove.Instance.hp <= 30 && !hp30check)
        {
            OnShakeCamera(0.25f, 0.4f);
            hp30check = true;
        }

        if (PlayerMove.Instance.hp <= 20 && !hp20check)
        {
            OnShakeCamera(0.25f, 0.4f);
            hp20check = true;
        }

        if (PlayerMove.Instance.hp <= 10 && !hp10check)
        {
            OnShakeCamera(0.25f, 0.4f);
            hp10check = true;
        }

        if (PlayerMove.Instance.hp > 10)
            hp10check = false;
        if (PlayerMove.Instance.hp > 20)
            hp20check = false;
        if(PlayerMove.Instance.hp > 30)
            hp30check = false;
    }

    public void OnShakeCamera(float shakeTime, float shakeIntensity)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    private IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;
        followCamera.onShake = true;

        while (shakeTime > 0)
        {
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;
            shakeTime -= Time.deltaTime;

            yield return null;

        }

        transform.position = startPosition;
        followCamera.onShake = false;
    }
}
