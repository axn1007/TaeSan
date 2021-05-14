using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActivity : MonoBehaviour
{
    public GameObject tornado;
    public GameObject balloon;
    public GameObject torAiDummy;
    public GameObject ballAiDummy;
    public GameObject branch;
    public GameObject bush;
    bool bushGrow;
    public Transform balloonOriginPos;
    public Transform balloonDestPos;
    public Transform overbridgeOriginPos;
    public Transform overbridgeDestPos;
    public float tornadoSpeed;
    public float balloonSpeed;
    RayManager rayManager;
    GameObject ai;
    MainAI mainAi;

    void Start()
    {
        // 토네이도 비활성화
        tornado.SetActive(false);
        // AIDummy 비활성화
        torAiDummy.SetActive(false);
        ballAiDummy.SetActive(false);
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
            rayManager.hits[1].transform.CompareTag("TornadoBtn") &&
            mainAi.wpIndex == 3 && mainAi.state == MainAI.AIState.Idle)
            {
                // 토네이도 활성화
                tornado.SetActive(true);
                // AIDummy 활성화
                torAiDummy.SetActive(true);

                mainAi.state = MainAI.AIState.Run;
                mainAi.wpIndex++;
                Destroy(rayManager.hits[0].transform.gameObject);
                Destroy(rayManager.hits[1].transform.gameObject);

                // AI 비활성화
                ai.SetActive(false);
            }

            if (rayManager.hits[0].transform.CompareTag("BushBtn") &&
            rayManager.hits[1].transform.CompareTag("BushBtn") &&
            mainAi.wpIndex == 6 && mainAi.state == MainAI.AIState.Idle)
            {
                bushGrow = true;
                mainAi.state = MainAI.AIState.Run;
                mainAi.wpIndex++;
                Destroy(rayManager.hits[0].transform.gameObject);
                Destroy(rayManager.hits[1].transform.gameObject);
            }
        }

        if (torAiDummy.activeSelf == true)
        {
            // 목표지점까지 이동
            tornado.transform.position = Vector3.Slerp(
                tornado.transform.position,
                mainAi.wayPointBox[4].transform.position,
                tornadoSpeed);
            // 도착하면
            if (Vector3.Distance(torAiDummy.transform.position,
                mainAi.wayPointBox[4].transform.position) < 1)
            {
                // 둘 다 비활성
                tornado.SetActive(false);
                torAiDummy.SetActive(false);
                // 원래 AI는 위치 변경
                ai.transform.position = mainAi.wayPointBox[4].transform.position;
                ai.SetActive(true);
            }
        }

        if (Vector3.Distance(ai.transform.position,
            balloonOriginPos.position) < 1)
        {
            ballAiDummy.SetActive(true);
            ai.SetActive(false);
            float balloonDist =
                Vector3.Distance(balloon.transform.position, balloonDestPos.position);
            balloon.transform.position =
                Vector3.Slerp(balloon.transform.position, balloonDestPos.position, balloonSpeed);
            if (balloonDist < 1 && ballAiDummy.activeSelf == true)
            {
                mainAi.wayPointBox[5].transform.position = overbridgeOriginPos.position;
                ai.transform.position = balloon.transform.position;
                ballAiDummy.SetActive(false);
                ai.SetActive(true);
                mainAi.state = MainAI.AIState.Run;
            }
        }

        if (bushGrow)
        {
            if (transform.localScale.x <= 1 && transform.localScale.y <= 1 && transform.localScale.z <= 1)
            {
                transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
            }
            if (transform.localScale.x >= 0.1f && transform.localScale.y >= 0.1f && transform.localScale.z >= 0.1f)
            {
                transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
            }
        }
    }
}
