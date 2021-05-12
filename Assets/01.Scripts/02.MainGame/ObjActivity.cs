using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActivity : MonoBehaviour
{
    public GameObject tornado;
    public GameObject balloon;
    public GameObject torAiDummy;
    public GameObject ballAiDummy;
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
        // ����̵� ��Ȱ��ȭ
        tornado.SetActive(false);
        // AIDummy ��Ȱ��ȭ
        torAiDummy.SetActive(false);
        ballAiDummy.SetActive(false);
        // RayManager ����
        rayManager = GameObject.Find("RayManager").GetComponent<RayManager>();
        // AI ����
        ai = GameObject.Find("AI");
        // MainAI ����
        mainAi = ai.GetComponent<MainAI>();
    }

    void Update()
    {
        // ���࿡ Ray�� ����Ǹ� Ȱ��ȭ
        if (rayManager.hits.Length == 2)
        {
            if (rayManager.hits[0].transform.CompareTag("TornadoBtn") &&
            rayManager.hits[1].transform.CompareTag("TornadoBtn") &&
            mainAi.wpIndex == 4)
            {
                // ����̵� Ȱ��ȭ
                tornado.SetActive(true);
                // AIDummy Ȱ��ȭ
                torAiDummy.SetActive(true);
                // AI ��Ȱ��ȭ
                ai.SetActive(false);
            }
        }

        if (torAiDummy.activeSelf == true)
        {
            // ��ǥ�������� �̵�
            tornado.transform.position = Vector3.Slerp(
                tornado.transform.position,
                mainAi.wayPointBox[4].transform.position,
                tornadoSpeed);
            // �����ϸ�
            if (Vector3.Distance(torAiDummy.transform.position,
                mainAi.wayPointBox[4].transform.position) < 1)
            {
                // �� �� ��Ȱ��
                tornado.SetActive(false);
                torAiDummy.SetActive(false);
                // ���� AI�� ��ġ ����
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
    }
}
