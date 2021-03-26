using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pos = new Vector3 (-0f, -0.2685f, 0.422f);
    public List<GameObject> cubePrefabs = new List<GameObject>();
    int i = 3;
    public int num;
   

    public void createCube()
    {
        Instantiate(cubePrefabs[Random.Range(0,4)], pos, transform.rotation);
        
    }
    
    private void Start()
    {
        createCube();
       

    }
    private void Update()
    {
        
    }


    
}
