using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    Vector3 dir;

    void Start()
    {
        dir = Vector3.up;
    }

    void Update()
    {
        transform.position += dir * 0.5f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        dir *= -1;
    }
}
