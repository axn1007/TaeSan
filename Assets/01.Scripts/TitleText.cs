using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleText : MonoBehaviour
{
    public Text titleText;
    public bool standby;
    float alpha = 0;

    void Update()
    {
        if (standby == true)
        {
            alpha += 0.5f * Time.deltaTime;
            titleText.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }
}
