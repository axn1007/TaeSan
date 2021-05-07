using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    public GameObject[] wayPointBox;
    public NavMeshAgent navi;
    public int wpIndex;

    void Start()
    {
        navi = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navi.SetDestination(wayPointBox[wpIndex].transform.position);
        float distance = Vector3.Distance(transform.position, wayPointBox[wpIndex].transform.position);
        print(wpIndex);
        //if (distance < 1)
        //{
        //    if (wpIndex < wayPointBox.Length - 1) wpIndex++;
        //}
    }
}
