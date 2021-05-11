using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    
    Vector3 startPos;
    public Vector3 destPos = new Vector3(15, 15, -3);
    public float speed = 0.005f;
    RayMana rayMana;

    void Start()
    {
        startPos = transform.position;
        destPos = this.gameObject.transform.position;

        rayMana = GameObject.Find("RayMana").GetComponent<RayMana>();
    }
        

    void Update()
    {
        //if (rayMana.hits.Length == 2)
        
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
