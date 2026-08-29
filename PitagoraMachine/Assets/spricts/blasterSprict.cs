using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blasterSprict : MonoBehaviour
{   Rigidbody rb;               //Rigidbody型の変数
public float jumpPower;     //ジャンプ力　アクセス修飾子をpublicに指定

float yPos = 0;


void Start()
{
    rb= GetComponent<Rigidbody>();  //Rigidbodyを取得、変数に代入
}

void Update()
{
    yPos = transform.position.y;
    //上矢印キーが押されたとき
    if (Input.GetKeyDown(KeyCode.Space)) 
    {
        //Rigidbodyに上方向にJumpPowerの力を加える
        rb.AddForce(transform.up * jumpPower);
    }

    if(yPos >= 2)
        {
            transform.position = new Vector3(12,2,2);
        }
}
}
