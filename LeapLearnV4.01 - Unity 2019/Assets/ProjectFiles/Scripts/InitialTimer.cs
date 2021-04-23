using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialTimer : MonoBehaviour
{

    public static InitialTimer initialTimer;
    public GameObject initialTimerDisplay;
    public float time;

    // Start is called before the first frame update

    
    void Start()
    {
        initialTimer = this;
    }

    // Update is called once per frame
    void Update()
    {
        initialTimerDisplay.GetComponent<Text>().text = time.ToString("0.00");
        time -= Time.deltaTime;

    }
}
