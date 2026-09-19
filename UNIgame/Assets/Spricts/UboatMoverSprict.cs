using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UboatMoverSprict : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ee");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(transform.position.x > -9 ){
                transform.position += new Vector3(-10,0,0);

            }
            
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(transform.position.x < 9 ){
                transform.position += new Vector3(10,0,0);

            }
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ee");
        
           
        
    }

}
