using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    Timer timer;

    void Start()
    {
        
    }

    void Update()
    {
        //Timer ��ũ��Ʈ ��������
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        //����� Timer ��������
        PlayerPrefs.GetFloat("SaveTime");
    }
}
