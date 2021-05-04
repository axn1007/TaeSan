using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    public NavMeshAgent navi;

    void Start()
    {
        navi = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navi.SetDestination(new Vector3(19, 8, 14));
    }
}
