using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove1 : MonoBehaviour
{
    public GameObject[] wayPointBox;
    public NavMeshAgent navi;
    public int wpIndex;
    RayMana rayMana;

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
        rayMana = GameObject.Find("RayMana").GetComponent<RayMana>();
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
        if (rayMana.hits.Length == 2)
        {
            if (wpIndex < wayPointBox.Length - 1) wpIndex++;
            state = AIState.Run;
            anim.SetTrigger("Run");
            leave.SetActive(true);
            smoke.SetActive(true);
            Destroy(rayMana.hits[0].transform.gameObject);
            Destroy(rayMana.hits[1].transform.gameObject);
        }
    }
}
