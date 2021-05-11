using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActivity : MonoBehaviour
{
    public GameObject tornado;
    public GameObject balloon;
    public GameObject aiDummy;
    public Transform balloonDestPos;
    public float speed;
    RayManager rayManager;
    GameObject ai;
    MainAI mainAi;

    void Start()
    {
        // 토네이도 비활성화
        tornado.SetActive(false);
        // AIDummy 비활성화
        aiDummy.SetActive(false);
        // RayManager 접근
        rayManager = GameObject.Find("RayManager").GetComponent<RayManager>();
        // AI 접근
        ai = GameObject.Find("AI");
        // MainAI 접근
        mainAi = ai.GetComponent<MainAI>();
    }

    void Update()
    {
        // 만약에 Ray가 통과되면 활성화
        if (rayManager.hits.Length == 2)
        {
            if (rayManager.hits[0].transform.CompareTag("TornadoBtn") &&
            rayManager.hits[1].transform.CompareTag("TornadoBtn")&&
            mainAi.wpIndex == 4)
            {
                // 토네이도 활성화
                tornado.SetActive(true);
                // AIDummy 활성화
                aiDummy.SetActive(true);
                // AI 비활성화
                ai.SetActive(false);
            }
        }

        if (aiDummy.activeSelf == true)
        {
            // 목표지점까지 이동
            tornado.transform.position = Vector3.Slerp(
                tornado.transform.position,
                mainAi.wayPointBox[4].transform.position,
                speed);
            // 도착하면
            if (Vector3.Distance(aiDummy.transform.position,
                mainAi.wayPointBox[4].transform.position) < 1)
            {
                // 둘 다 비활성
                tornado.SetActive(false);
                aiDummy.SetActive(false);
                // 원래 AI는 위치 변경
                ai.transform.position = mainAi.wayPointBox[4].transform.position;
                ai.SetActive(true);
            }
        }

        if (Vector3.Distance(ai.transform.position,
            mainAi.wayPointBox[5].transform.position) < 1)
        {
            ai.SetActive(false);
            float balloonDist =
                Vector3.Distance(balloon.transform.position, balloonDestPos.position);
            balloon.transform.position =
                Vector3.Slerp(balloon.transform.position, balloonDestPos.position, speed);
            if (balloonDist < 1)
            {
                ai.transform.position = balloonDestPos.position;
                ai.SetActive(true);
            }
        }
    }
}
