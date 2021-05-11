using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    
    Vector3 startPos;
    public Vector3 destPos = new Vector3(15, 15, -3);
    public float speed = 0.005f;

    void Start()
    {
        startPos = transform.position;
        destPos = this.gameObject.transform.position;
    }
        

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            print("�浹 ����");
            //��ǥ�������� �̵�
            transform.position = Vector3.Slerp(transform.position, destPos, speed);
        }
    }
}