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
        //Timer 스크립트 가져오기
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        //저장된 Timer 가져오기
        PlayerPrefs.GetFloat("SaveTime");
    }
}
