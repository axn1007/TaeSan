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
        // RayManager 스크립트 가져오기
        rayMana = GameObject.Find("RayMana").GetComponent<RayMana>();
        // Run 상태로 시작
        state = AIState.Run;
        // Animator 셋팅
        anim = GetComponentInChildren<Animator>();
        // Navigation 셋팅
        navi = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // 현재 상태에 따라 기능 수행
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
        // 만약 목표지점과 가까워지면
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
