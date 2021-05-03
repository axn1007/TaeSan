using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    GameObject start;
    GameObject end;

    void Start()
    {
        start = GameObject.Find("Start");
        end = GameObject.Find("End");
        start.SetActive(false);
        end.SetActive(false);
    }

    void Update()
    {
        int layer = 1 << LayerMask.NameToLayer("Event");
        RaycastHit[] hits;
        hits = Physics.RaycastAll(
            Camera.main.transform.position,
            Camera.main.transform.forward,
            100, layer);
        if (hits.Length == 2)
        {
            start.SetActive(true);
            end.SetActive(true);
        }

        foreach (RaycastHit hit in hits)
        {
            Debug.Log("Raycast!");
        }
    }
}
