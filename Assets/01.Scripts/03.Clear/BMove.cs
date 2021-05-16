using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMove : MonoBehaviour
{
    public Transform bdPos;
    public float bSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 dir = (bdPos.up - transform.position).normalized;

        transform.position = Vector3.Lerp(transform.position, dir, bSpeed);

        //transform.position = Vector3.Slerp(transform.position, bdPos.position, bSpeed);

    }
}
