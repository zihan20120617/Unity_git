using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class blasterSprict : MonoBehaviour
{   Rigidbody rb;               //Rigidbody型の変数
public float jumpPower;     //ジャンプ力　アクセス修飾子をpublicに指定
float yPos = 0;
[Header("発射成功")]
public AudioClip blastersound;
[Header("発射失敗")]
public AudioClip errorsound;
[Header("テキスト")]
public GameObject text;


void Start()
{
    rb= GetComponent<Rigidbody>();  //Rigidbodyを取得、変数に代入
}

void Update()
{
    transform.rotation =  Quaternion.identity;
    yPos = transform.position.y;
    //spaceキーが押されたとき
    if (Input.GetKeyDown(KeyCode.Space) ) 
    {
        if( Ballcontroller.Ballstatus == 0)
            {
                //Rigidbodyに上方向にJumpPowerの力を加える
                rb.AddForce(transform.up * jumpPower);
                Ballcontroller.Ballstatus = 1;
                Ballcontroller.isfirstpushed = true;
                text.SetActive(false);
                AudioSource.PlayClipAtPoint(blastersound, transform.position, 1.0f);
            }
            else
            {
                AudioSource.PlayClipAtPoint(errorsound, transform.position, 1.0f);
            }
        
    }

    if(yPos >= 2)
        {
            transform.position = new Vector3(8,2,0);
            // ボールを移動させる処理の直前または直後に入れるコード
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;        // 移動速度（エネルギー）を消す
            rb.angularVelocity = Vector3.zero; // 回転の勢いを消す
        }
}
}
