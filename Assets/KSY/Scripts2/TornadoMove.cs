using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TornadoMove : MonoBehaviour
{

    public GameObject Tornado;
    public GameObject Aii;
    Vector3 sp;
    public Vector3 dp = new Vector3(-12, 9, 5);
    public float speed = 1f;
    public GameObject AI;

    RayMana rayMana;

    void Start()
    {
        //����̵� ��Ȱ��ȭ
        Tornado.SetActive(false);
        //AI ��Ȱ��ȭ
        Aii.SetActive(false);
        // RayManager ��ũ��Ʈ ��������
        rayMana = GameObject.Find("RayMana").GetComponent<RayMana>();

        //����̵� ���� ��ġ
        sp = Tornado.transform.position;
        //dp = this.gameObject.transform.position;
    }

    void Update()
    {
        //���࿡ Ray�� ����Ǹ� Ȱ��ȭ
        if (rayMana.hits.Length == 2)
        {
            if (rayMana.hits[0].transform.gameObject.CompareTag("RayTarget30") ||
            rayMana.hits[1].transform.gameObject.CompareTag("RayTarget30"))
            {
                //����̵� Ȱ��ȭ
                Tornado.SetActive(true);
                //Aii Ȱ��ȭ
                Aii.SetActive(true);
                //AI ��Ȱ��ȭ
                AI.SetActive(false);               
            }
        }

        if(Aii.activeSelf == true)
        {
            //��ǥ�������� �̵�
            transform.position = Vector3.Slerp(transform.position, dp, speed);
            //�����ϸ�
            if (Vector3.Distance(Aii.transform.position, dp) < 1)
            {
                //�Ѵ� ��Ȱ
                Tornado.SetActive(false);
                Aii.SetActive(false);
                //���� AI�� ��ġ ����
                AI.SetActive(true);
                AI.transform.position = dp;
            }
        }
    }
}
