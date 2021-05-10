using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPosManager : MonoBehaviour
{
    public GameObject[] aiPoss;
    public GameObject[] rayTargets;
    RayManager rayManager;
    int posIndex;
    void Start()
    {
        rayManager = GameObject.Find("RayManager").GetComponent<RayManager>();
        for (int i = 0; i < aiPoss.Length; i++)
        {
            aiPoss[i].SetActive(false);
        }
    }

    void Update()
    {
        if (rayManager.hits.Length == 2)
        {
            //if ()
            //{
            //    aiPoss[posIndex].SetActive(true);
            //    if (posIndex < aiPoss.Length - 1) posIndex++;
            //    Destroy(rayManager.hits[0].transform.gameObject);
            //    Destroy(rayManager.hits[1].transform.gameObject);
            //}
        }
    }
}
