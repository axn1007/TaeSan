using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTreeEft : MonoBehaviour
{
    GameObject ai;
    AIMove aiMove;
    void Start()
    {
        ai = GameObject.Find("AI");
        aiMove = ai.GetComponent<AIMove>();
    }

    void Update()
    {
        float dist = Vector3.Distance(
            ai.transform.position,
            aiMove.wayPointBox[aiMove.wayPointBox.Length - 1].transform.position);
        if (dist < 1)
        {
            if (transform.localScale.x <= 3 && transform.localScale.y <= 3 && transform.localScale.z <= 3)
            {
                transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
            }
        }
    }
}
