using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    float speed = 1.0f;
    public int number = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(number > 0)
        {
            transform.position +=  Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position +=  Vector3.down * speed * Time.deltaTime;
        } 
       
    }
}
