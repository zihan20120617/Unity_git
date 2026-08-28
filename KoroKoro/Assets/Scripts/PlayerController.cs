using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 3.0f;
                 
    public float jumpPower;     
    private Rigidbody rb;  
    private bool isJumping = false;
    void Start()
    {
    rb= GetComponent<Rigidbody>();  //Rigidbodyを取得、変数に代入
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0,1.5f,0);
            Debug.Log("reset");
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
           
        }
         if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
           
        }

         if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
           
        }

         if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0.5f, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -0.5f, 0));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)&& !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }
    
    
        
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        
        
            isJumping = false;
        
    }

   
}

