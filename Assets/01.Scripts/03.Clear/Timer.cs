using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float time;
    float sec;
    float min;
    float hour;
    float currTime;
    bool isGameClear;
    

    void Start()
    {
        //ResetTimer();
        //textTimer.gameObject.SetActive(false);
    }

    void Update()
    {
        //if (isEnded)
        //    return;
        //CheckTimer();
        sec = (int)(Time.time - currTime);
        if(sec > 59)
        {
            currTime = Time.time;
            sec = 0;
            min++;

            if(min > 59)
            {
                min = 0;
                hour++;
            }
        }
        timerText.text = string.Format("Time : {0:00}:{1:00}:{2:00}", hour, min, sec);
    }

}

