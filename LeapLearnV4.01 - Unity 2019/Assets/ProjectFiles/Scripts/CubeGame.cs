using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CubeGame : MonoBehaviour
{
    public GameObject cube;
    public ScoreScript score;
    public SpawnCubes spawn;
    TimerScript timerScript;
    [HideInInspector]
    public int cubePoints;


    // Start is called before the first frame update
    void Start()
    {
        
        timerScript = FindObjectOfType<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //cubePoints = score.nowPoints;
        //if (timerScript.reseted)
        //{
        //    cubePoints = 0;
        //}
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == cube.tag)
        {
            score.scoreCount();
            spawn.createCube();
            Destroy(other.gameObject);
        }
        else
        {
            other.gameObject.transform.position = new Vector3(0f, -0.2685f, 0.422f);
        }
    }
}


