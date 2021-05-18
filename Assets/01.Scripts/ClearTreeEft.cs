using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTreeEft : MonoBehaviour
{
    GameObject clear;
    GameObject ai;
    AIMove aiMove;
    void Start()
    {
        clear = GameObject.Find("Clear");
        clear.SetActive(false);
        ai = GameObject.Find("AI");
        aiMove = ai.GetComponent<AIMove>();
    }

    void Update()
    {
        float dist = Vector3.Distance(
            ai.transform.position,
            aiMove.wayPointBox[aiMove.wayPointBox.Length - 1].transform.position);

        if (dist < 0.025f)
        {
            if (transform.localScale.x <= 2 &&
                transform.localScale.y <= 2 &&
                transform.localScale.z <= 2)
            {
                transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
            }
        }

        if (transform.localScale.x >= 2) clear.SetActive(true);
    }
}
