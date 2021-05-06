using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    public GameObject[] offMeshLink;

    void Start()
    {

    }

    void Update()
    {
        int layer = 1 << LayerMask.NameToLayer("Event");
        RaycastHit[] hits;
        hits = Physics.RaycastAll(
            Camera.main.transform.position,
            Camera.main.transform.forward,
            25, layer);
        if (hits.Length == 2)
        {
            //print("2");
            for (int i = 0; i < offMeshLink.Length; i++)
                offMeshLink[i].SetActive(true);
        }
        else if (hits.Length == 0)
        {
            //print("0");
            for (int i = 0; i < offMeshLink.Length; i++)
                offMeshLink[i].SetActive(false);
        }
        //foreach (RaycastHit hit in hits)
        //{
        //    Debug.Log("Raycast!");
        //}
    }
}
