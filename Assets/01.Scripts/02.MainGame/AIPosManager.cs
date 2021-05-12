using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPosManager : MonoBehaviour
{
    public GameObject[] aiPoss;
    public GameObject[] rayTargets;
    public Transform overbridgeDestPos;
    RayManager rayManager;
    GameObject ai;
    int posIndex;
    MainAI mainAi;
    void Start()
    {
        ai = GameObject.Find("AI");
        mainAi = ai.GetComponent<MainAI>();
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
    }
}
