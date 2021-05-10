using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRendOff1 : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
        
    }
}
