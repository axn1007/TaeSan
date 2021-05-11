using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActivity : MonoBehaviour
{
    public GameObject tornado;
    public GameObject aiDummy;
    public float speed;
    RayManager rayManager;
    GameObject ai;
    MainAI mainAi;

    void Start()
    {
        // ����̵� ��Ȱ��ȭ
        tornado.SetActive(false);
        // AIDummy ��Ȱ��ȭ
        aiDummy.SetActive(false);
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
            rayManager.hits[1].transform.CompareTag("TornadoBtn"))
            {
                // ����̵� Ȱ��ȭ
                tornado.SetActive(true);
                // AIDummy Ȱ��ȭ
                aiDummy.SetActive(true);
                // AI ��Ȱ��ȭ
                ai.SetActive(false);
            }
        }

        if (aiDummy.activeSelf == true)
        {
            // ��ǥ�������� �̵�
            tornado.transform.position = Vector3.Slerp(
                tornado.transform.position,
                mainAi.wayPointBox[4].transform.position,
                speed);
            // �����ϸ�
            if (Vector3.Distance(aiDummy.transform.position,
                mainAi.wayPointBox[4].transform.position) < 1)
            {
                // �� �� ��Ȱ��
                tornado.SetActive(false);
                aiDummy.SetActive(false);
                // ���� AI�� ��ġ ����
                ai.transform.position = mainAi.wayPointBox[4].transform.position;
                ai.SetActive(true);
                mainAi.state = MainAI.AIState.Run;
                mainAi.anim.SetTrigger("Run");
                mainAi.wpIndex++;
            }
        }
    }
}
