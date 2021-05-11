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
        //토네이도 비활성화
        Tornado.SetActive(false);
        //AI 비활성화
        Aii.SetActive(false);
        // RayManager 스크립트 가져오기
        rayMana = GameObject.Find("RayMana").GetComponent<RayMana>();

        //토네이도 현재 위치
        sp = Tornado.transform.position;
        //dp = this.gameObject.transform.position;
    }

    void Update()
    {
        //만약에 Ray가 통과되면 활성화
        if (rayMana.hits.Length == 2)
        {
            if (rayMana.hits[0].transform.gameObject.CompareTag("RayTarget30") ||
            rayMana.hits[1].transform.gameObject.CompareTag("RayTarget30"))
            {
                //토네이도 활성화
                Tornado.SetActive(true);
                //Aii 활성화
                Aii.SetActive(true);
                //AI 비활성화
                AI.SetActive(false);               
            }
        }

        if(Aii.activeSelf == true)
        {
            //목표지점까지 이동
            transform.position = Vector3.Slerp(transform.position, dp, speed);
            //도착하면
            if (Vector3.Distance(Aii.transform.position, dp) < 1)
            {
                //둘다 비활
                Tornado.SetActive(false);
                Aii.SetActive(false);
                //원래 AI는 위치 변경
                AI.SetActive(true);
                AI.transform.position = dp;
            }
        }
    }
}
