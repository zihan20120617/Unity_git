using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class blasterSprict : MonoBehaviour
{   Rigidbody rb;               //Rigidbody型の変数
public float jumpPower;     //ジャンプ力　アクセス修飾子をpublicに指定
float yPos = 0;
public GameObject[] text;


void Start()
{
    rb= GetComponent<Rigidbody>();  //Rigidbodyを取得、変数に代入
}

void Update()
{
    transform.rotation =  Quaternion.identity;
    yPos = transform.position.y;
    //spaceキーが押されたとき
    if (Input.GetKeyDown(KeyCode.Space) && Ballcontroller.Ballreset == true) 
    {
        //Rigidbodyに上方向にJumpPowerの力を加える
        rb.AddForce(transform.up * jumpPower);
        Ballcontroller.Ballreset = false;
        text[0].SetActive(false);
    }

    if(yPos >= 2)
        {
            transform.position = new Vector3(8,2,0);

            
        }
}
}
