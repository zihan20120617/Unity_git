using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.MPE;

public class buttonmanager : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
 
 
    }


    void OnCollisionEnter(Collision collision)
    {
        RotateFloor.IsButtonpushed =  true;
        transform.position = new Vector3();
    }
}


