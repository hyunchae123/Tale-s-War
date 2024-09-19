using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterS4 : MonoBehaviour
{
    [SerializeField] GameObject dust;

    EnemyMove myMove;

    float increaseTime;
    float OriginSpeed;

    bool peakSpeed;

    void Start()
    {
        increaseTime = 0.0f;
        dust.SetActive(false);
        myMove = GetComponent<EnemyMove>();
        OriginSpeed = myMove.moveSpeed;
    }

    void Update()
    {
        increaseTime += Time.deltaTime;

        if (increaseTime >= 3.0f && peakSpeed == false)
        {
            myMove.moveSpeed += myMove.moveSpeed * 0.05f;
            dust.SetActive(true);
            peakSpeed = true;
        }

        if (peakSpeed)
        {
            myMove.moveSpeed = Mathf.Clamp(myMove.moveSpeed - (myMove.moveSpeed * 0.05f) / (1f / Time.deltaTime), OriginSpeed, myMove.moveSpeed);
        }

        if (myMove.moveSpeed == OriginSpeed && peakSpeed == true)
        {
            increaseTime = 0f;
            peakSpeed = false;
            dust.SetActive(false);
        }
    }
}
