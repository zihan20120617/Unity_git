using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kabe_kontroller : MonoBehaviour
{
    [Header("テキスト")]
    public GameObject text;
    private bool isMoved = false;

    [Header("キーボード設定")]
    [SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rightKey = KeyCode.RightArrow;
    [Header("スマホ用ボタンフラグ")]
    private bool isLeftPressed = false;
    private bool isRightPressed = false;
    public void SetLeftPressed(bool isPressed) => isLeftPressed = isPressed;
    public void SetRightPressed(bool isPressed) => isRightPressed = isPressed; // 右ボタン用
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey) | isLeftPressed )
        {
            transform.position += new Vector3(-1,0,0) * Time.deltaTime;
            isMoved = true; 
        }


        if (Input.GetKey(rightKey) | isRightPressed)
        {
            transform.position += new Vector3(1,0,0) * Time.deltaTime;
            isMoved = true; 
        }

        if(isMoved == true)
        {
            text.SetActive(false);
        }

        if(transform.position.x <= 6.5)
        {
            transform.position = new Vector3(6.5f,6.1f,0);
        }

        if(transform.position.x >= 11)
        {
            transform.position = new Vector3(11,6.1f,0);
        }
    }
}
