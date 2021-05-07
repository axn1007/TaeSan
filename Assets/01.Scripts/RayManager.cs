using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    AIMove aiMove;

    void Start()
    {
        aiMove = GameObject.Find("AI").GetComponent<AIMove>();
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
            if (aiMove.wpIndex < aiMove.wayPointBox.Length - 1) aiMove.wpIndex++;
            Destroy(hits[0].transform.gameObject);
            //print("2");
        }
        else
        {
            //print("0");
        }
        //foreach (RaycastHit hit in hits)
        //{
        //    Debug.Log("Raycast!");
        //}
    }
}
