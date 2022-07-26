using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataTeste : MonoBehaviour
{
    string data;
    // Start is called before the first frame update
    void Start()
    {
        data = System.DateTime.Now.ToString("MM/dd/yyyy");
        Debug.Log(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
