using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPosManager : MonoBehaviour
{
    public GameObject[] aiPoss;
    public GameObject[] rayTargets;
    RayMana rayManager;
    int posIndex;
    void Start()
    {
        rayManager = GameObject.Find("RayMana").GetComponent<RayMana>();
        for (int i = 0; i < aiPoss.Length; i++)
        {
            aiPoss[i].SetActive(false);
        }
        aiPoss[0].SetActive(true);
    }

    void Update()
    {
        if (rayManager.hits.Length == 2)
        {
            if (rayManager.hits[0].transform.gameObject == rayTargets[posIndex].gameObject ||
                rayManager.hits[1].transform.gameObject == rayTargets[posIndex].gameObject)
            {
                aiPoss[posIndex].SetActive(false);
                if (posIndex < aiPoss.Length - 1) posIndex++;
                aiPoss[posIndex].SetActive(true);
            }
        }
    }
}
