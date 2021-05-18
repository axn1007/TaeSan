using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutUIManager : MonoBehaviour
{
    GameObject help;

    void Start()
    {
        help = GameObject.Find("Help");
        Invoke("HelpMessageOff", 5);
    }

    void Update()
    {

    }

    void HelpMessageOff()
    {
        help.SetActive(false);
    }

    public void OnClickGoMain()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClickGoTitle()
    {
        SceneManager.LoadScene(0);
    }
}
