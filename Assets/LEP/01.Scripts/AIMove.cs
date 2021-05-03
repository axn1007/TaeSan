using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    // ���콺 Ŭ�� ����
    Vector3 mouseClickPoint;
    // �̵�����
    Vector3 dir;
    // �̵��� �Ÿ�
    float dist;
    // NavMeshAgent
    NavMeshAgent navi;

    void Start()
    {
        navi = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ���콺 ���� Ŭ���� �ߴٸ�
        if (Input.GetMouseButtonDown(0))
        {
            // Ŭ���� �������� Ray �����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ray�� ���� �ε����ٸ� hit ������ ��´�.
            if (Physics.Raycast(ray, out hit))
            {
                navi.SetDestination(hit.point);

                //print(hit.transform.gameObject.name);
                //// �� Ray�� �ε��� ��ġ�� �̵��ϰ� �ʹ�.
                //// 0. �ε��� ���� ����
                //mouseClickPoint = hit.point;
                //// 1. �ε��� ������ ���ϴ� ������ ���Ѵ�.
                //dir = hit.point - transform.position;
                //// 2. �ε��� ������ ������ �Ÿ��� ���Ѵ�.
                //dist = dir.magnitude;
                //// 3. ����ȭ
                //dir.Normalize();
            }
        }

        //// ���� �̵��ؾ��� �Ÿ��� �ִٸ�
        //if (dist > 0)
        //{
        //    // 3. �� �������� �����δ�.
        //    transform.position += dir * 5 * Time.deltaTime;

        //    dist -= 5 * Time.deltaTime;

        //    if(dist <= 0)
        //    {
        //        transform.position = mouseClickPoint;
        //    }
        //}
    }
}
