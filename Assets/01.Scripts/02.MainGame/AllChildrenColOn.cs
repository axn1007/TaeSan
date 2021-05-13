using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllChildrenColOn : MonoBehaviour
{
    GameObject ai;
    MainAI mainAi;
    MeshCollider[] allChildren;
    void Start()
    {
        ai = GameObject.Find("AI");
        mainAi = ai.GetComponent<MainAI>();

        allChildren = GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider child in allChildren)
        {
            child.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

    void Update()
    {
        float dist = Vector3.Distance(
            ai.transform.position,
            mainAi.wayPointBox[mainAi.wayPointBox.Length - 1].transform.position);

        if (dist < 1)
        {
            foreach (MeshCollider child in allChildren)
            {
                child.gameObject.GetComponent<MeshCollider>().enabled = true;
            }
        }
    }
}
