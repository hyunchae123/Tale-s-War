using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    Tail Me;
    float skillCoolTime;

    void Start()
    {
        Me = GetComponent<Tail>();

        skillCoolTime = 0.0f;
    }

    private void Update()
    {
        if (PlayerMove.Instance.OnPause)
            return;

        skillCoolTime += Time.deltaTime;

        if (Me.isChaseTail && skillCoolTime >= 3.0f)
        {
            skillCoolTime = 0.0f;

            if (PlayerMove.Instance.hp < 50)
                PlayerMove.Instance.GetHeal(5.0f);
            else
            {
                for(int i = 0; i < 5; i++)
                {
                    if(PlayerMove.Instance.followTails[i] != null && PlayerMove.Instance.followTails[i].hp < 30)
                    {
                        PlayerMove.Instance.followTails[i].hp = Mathf.Clamp(PlayerMove.Instance.followTails[i].hp + 5.0f, 0f, 30f);
                        break;
                    }
                    
                }
                
            }
        }
    }


}
