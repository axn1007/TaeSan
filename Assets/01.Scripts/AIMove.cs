using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    public GameObject[] wayPointBox;
    public NavMeshAgent navi;
    int wpIndex;
    RayManager rayManager;

    // Player Effect
    public GameObject leave;
    public GameObject smoke;

    enum AIState
    {
        Run,
        Idle,
    }

    AIState state;
    Animator anim;

    void Start()
    {
        // RayManager ��ũ��Ʈ ��������
        rayManager = GameObject.Find("RayManager").GetComponent<RayManager>();
        // Run ���·� ����
        state = AIState.Run;
        // Animator ����
        anim = GetComponentInChildren<Animator>();
        // Navigation ����
        navi = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ���� ���¿� ���� ��� ����
        switch (state)
        {
            case AIState.Run:
                Run();
                break;
            case AIState.Idle:
                Idle();
                break;
            default:
                break;
        }
        print(wpIndex);
    }

    void Run()
    {
        print("Run!!");
        navi.SetDestination(wayPointBox[wpIndex].transform.position);
        float dist = Vector3.Distance(
            transform.position, wayPointBox[wpIndex].transform.position);
        // ���� ��ǥ������ ���������
        if (dist < 1)
        {
            print("Access!!");
            state = AIState.Idle;
            anim.SetTrigger("Idle");
            leave.SetActive(false);
            smoke.SetActive(false);
        }
    }

    void Idle()
    {
        print("Stop!!");
        if (rayManager.hits.Length == 2)
        {
            if (wpIndex < wayPointBox.Length - 1) wpIndex++;
            state = AIState.Run;
            anim.SetTrigger("Run");
            leave.SetActive(true);
            smoke.SetActive(true);
            Destroy(rayManager.hits[0].transform.gameObject);
        }
    }
}
