using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirDetector : MonoBehaviour
{

  
    public GameObject bgImage;
    Color imageColor;

    bool falseDir, trueDir, activated;

 


    // Start is called before the first frame update
    void Start()
    {
        imageColor = bgImage.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        bgImage.GetComponent<Image>().color = imageColor;
    }


    public void ActiveDetecion()
    {
        
        Debug.Log("Is Active");

        activated = true;
        imageColor.r = 0;
        imageColor.g = 1;
        imageColor.b = 0;
    }

    public void DeactiveDetection()
    {
        Debug.Log("Is Not Active");

        
        imageColor.r = 1;
        imageColor.g = 0;
        imageColor.b = 0;
    }


    public void FalseDirection()
    {
        Debug.Log("False Direction");
        imageColor.r = 1;
        imageColor.g = 0;
        imageColor.b = 1;
    }
    
    public void TrueDirection()
    {
        Debug.Log("True Direction");
        imageColor.r = 0;
        imageColor.g = 1;
        imageColor.b = 1;
    }

    public void HandClosed()
    {
        Debug.Log("isClosed");
    }
    public void HandOpened()
    {
        Debug.Log("isOpened");
    }
}
