using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using TMPro;

public class RotateFloor : MonoBehaviour
{

    public float rotaleSpeed = 0.001f;
    private bool Ispalyeron = false;//プレイヤーが上に乗ったらtrueにする
    public static bool IsButtonpushed = false;//しかけのスイッチをおしたらtrueにする
    public static bool IsButtonpushed_H = false;
    // Start is called before the first frame update
    [Header("看板")]
    public TextMeshPro kanbann;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ispalyeron == true & IsButtonpushed == false)
        {
             transform.Rotate(Vector3.up * rotaleSpeed  );
        }

        if(IsButtonpushed == true)
        {
            transform.rotation = Quaternion.Euler(90,90,0);
            IsButtonpushed_H = false;
            kanbann.text = "You can go now! ";
        }

        if(IsButtonpushed_H == true)
        {
          
            transform.Rotate(new Vector3(90,90,0));
            kanbann.text = "You missed!";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            IsButtonpushed_H = true;
        }

        Debug.Log(IsButtonpushed);
        
       
    }
    void OnCollisionEnter(Collision collision)
    {
        Ispalyeron = true;
    }
    void OnCollisionExit(Collision collision)
    {
        Ispalyeron = false;
    }




}
