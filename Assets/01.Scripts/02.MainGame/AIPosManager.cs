using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPosManager : MonoBehaviour
{
    public GameObject[] aiPoss;
    public GameObject[] rayTargets;
    public GameObject moveDummy;
    public GameObject stageClearDummy;
    public Transform moveDestPos;
    public Transform overbridgeDestPos;
    RayManager rayManager;
    GameObject ringMove;
    GameObject ai;
    public int posIndex;
    MainAI mainAi;
    void Start()
    {
        ai = GameObject.Find("AI");
        mainAi = ai.GetComponent<MainAI>();

        moveDummy.SetActive(false);
        stageClearDummy.SetActive(false);

        ringMove = GameObject.Find("RingMove");

        rayManager = GameObject.Find("RayManager").GetComponent<RayManager>();

        for (int i = 0; i < aiPoss.Length; i++)
        {
            aiPoss[i].SetActive(false);
        }
        for (int i = 0; i < rayTargets.Length; i++)
        {
            rayTargets[i].SetActive(false);
        }
    }

    void Update()
    {
        rayTargets[posIndex].SetActive(true);

        if (rayManager.hits.Length == 2)
        {
            if (rayManager.hits[0].transform.gameObject == mainAi.rayTarget[1].gameObject ||
                rayManager.hits[1].transform.gameObject == mainAi.rayTarget[1].gameObject)
            {
                moveDummy.SetActive(true);
                ai.SetActive(false);
            }

            if (rayManager.hits[0].transform.gameObject == rayTargets[posIndex].gameObject ||
                rayManager.hits[1].transform.gameObject == rayTargets[posIndex].gameObject)
            {
                if (posIndex == 0) ai.SetActive(false);

                if (posIndex < aiPoss.Length - 1)
                {
                    aiPoss[posIndex].SetActive(false);
                    rayTargets[posIndex].SetActive(false);
                    posIndex++;
                    aiPoss[posIndex].SetActive(true);
                }

                if (aiPoss[aiPoss.Length - 1].activeSelf == true)
                {
                    ai.transform.position = overbridgeDestPos.position;
                    ai.SetActive(true);
                    mainAi.wpIndex++;
                    mainAi.state = MainAI.AIState.Run;
                    aiPoss[aiPoss.Length - 1].SetActive(false);
                }
            }
        }

        if (Vector3.Distance(moveDummy.transform.position, moveDestPos.position) < 1 &&
            moveDummy.activeSelf == true)
        {
            ai.transform.position = moveDestPos.position;
            ai.SetActive(true);
            moveDummy.SetActive(false);
        }

        if (Vector3.Distance(ai.transform.position,
            mainAi.wayPointBox[mainAi.wayPointBox.Length - 1].transform.position) < 1)
        {
            stageClearDummy.SetActive(true);
            ai.SetActive(false);
            ringMove.GetComponent<GroundMove>().enabled = true;
        }
    }
}
