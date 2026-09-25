using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UboatMoverSprict : MonoBehaviour
{
    // Start is called before the first frame update
    private int isTouched = 0;
    //ゲームオーバー数：１
    void Start()
    {
        Debug.Log("ee");
    }

    // Update is called once per frame
    void Update()
    {
        if(unimoverSprict.isGameover == false){
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
        Debug.Log(isTouched);

        if(isTouched == 1)
        {
            unimoverSprict.isGameover = true;
        }
    }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ee");
        isTouched ++;
        
           
        
    }

}

