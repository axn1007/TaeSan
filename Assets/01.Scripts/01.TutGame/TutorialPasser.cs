using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPasser : MonoBehaviour
{
    //ArrowActivity arrowAct;
    AIMove aiMove;
    GameObject ai;
    void Start()
    {
        //arrowAct = GameObject.Find("ArrowActivity").GetComponent<ArrowActivity>();
        ai = GameObject.Find("AI");
        aiMove = ai.GetComponent<AIMove>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (aiMove.state == AIMove.AIState.Idle && ai.activeSelf == true)
            {
                aiMove.leave.SetActive(true);
                aiMove.smoke.SetActive(true);
                //arrowAct.arrows[aiMove.wpIndex].gameObject.SetActive(false);
                aiMove.wpIndex++;
                aiMove.anim.SetTrigger("Run");
                aiMove.state = AIMove.AIState.Run;
            }
        }
    }
}
