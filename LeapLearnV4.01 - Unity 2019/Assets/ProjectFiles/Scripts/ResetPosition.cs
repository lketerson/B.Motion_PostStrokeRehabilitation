using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 pos;
    SpawnCubes _spawnCube;
    Rigidbody _cubeRB;
    // Start is called before the first frame update
    void Start()
    {
        _spawnCube = FindObjectOfType<SpawnCubes>();
        _cubeRB = GetComponent<Rigidbody>();
       pos = new Vector3(0f, -0.2685f, 0.422f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this._cubeRB.ResetInertiaTensor();
            this._cubeRB.Sleep();
            this.transform.position = pos;
            this.transform.rotation = Quaternion.EulerAngles(0, 0, 0);
            this._cubeRB.ResetInertiaTensor();
        }

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        Destroy(this.gameObject);
    //        _spawnCube.createCube();
    //    }
    //}


}
