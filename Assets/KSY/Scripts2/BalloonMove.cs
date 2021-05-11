using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    Vector3 startPos;
    public Vector3 destPos;
    public float speed = 0.005f;

    void Start()
    {
        startPos = new Vector3(-15, 16, 8);
        destpos = new vector3(14, 17.5, -14);
    }
        

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            print("충돌 감지");
            //목표지점까지 이동
            transform.position = Vector3.Slerp(transform.position, destPos, speed);
        }
    }
}
