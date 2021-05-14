using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPasser : MonoBehaviour
{
    MainAI mainAi;
    GameObject ai;
    ObjActivity objAct;
    AIPosManager aiPosMng;
    void Start()
    {
        ai = GameObject.Find("AI");
        mainAi = ai.GetComponent<MainAI>();
        objAct = GameObject.Find("ObjActivity").GetComponent<ObjActivity>();
        aiPosMng = GameObject.Find("AIPosManager").GetComponent<AIPosManager>();
    }

    void Update()
    {
        print(aiPosMng.posIndex);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (mainAi.wpIndex == 5 && mainAi.state == MainAI.AIState.Idle)
            {
                if (ai.activeSelf == true && aiPosMng.posIndex == 0)
                {
                    ai.SetActive(false);
                }

                if (aiPosMng.posIndex < aiPosMng.aiPoss.Length - 1)
                {
                    aiPosMng.aiPoss[aiPosMng.posIndex].SetActive(false);
                    aiPosMng.rayTargets[aiPosMng.posIndex].SetActive(false);
                    aiPosMng.posIndex++;
                    aiPosMng.aiPoss[aiPosMng.posIndex].SetActive(true);
                }
                
                if (aiPosMng.aiPoss[aiPosMng.aiPoss.Length - 1].activeSelf == true)
                {
                    ai.transform.position = aiPosMng.overbridgeDestPos.position;
                    ai.SetActive(true);
                    mainAi.wpIndex++;
                    mainAi.state = MainAI.AIState.Run;
                    aiPosMng.aiPoss[aiPosMng.aiPoss.Length - 1].SetActive(false);
                }
            }
            
            else if (mainAi.wpIndex == 3 && mainAi.state == MainAI.AIState.Idle && ai.activeSelf == true)
            {
                mainAi.wpIndex++;
                // 토네이도 활성화
                objAct.tornado.SetActive(true);
                // AIDummy 활성화
                objAct.torAiDummy.SetActive(true);
                // AI 비활성화
                mainAi.anim.SetTrigger("Run");
                mainAi.state = MainAI.AIState.Run;
                ai.SetActive(false);
            }
            
            else if (mainAi.state == MainAI.AIState.Idle && ai.activeSelf == true)
            {
                mainAi.leave.SetActive(true);
                mainAi.smoke.SetActive(true);
                mainAi.wpIndex++;
                mainAi.anim.SetTrigger("Run");
                mainAi.state = MainAI.AIState.Run;
            }
        }
    }
}
