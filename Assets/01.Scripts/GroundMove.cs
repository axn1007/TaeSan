using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    Vector3 dir;
    void Start()
    {
        dir = Vector3.right;
    }

    void Update()
    {
        transform.position += dir * 2 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        dir *= -1;
    }
}
