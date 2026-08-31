using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinSprict : MonoBehaviour
{
    float speed = 0.5f;
    float distance = 1.0f;
    private Vector3 startPosition;
    [Header("上下移動かどうか")]
    public bool updownmove = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(updownmove == false)
        {
            // -1 〜 1 の間で滑らかに変化する値を計算
        float xOffset = Mathf.Sin(Time.time * speed) * distance;

        // 初期位置から左右（X軸）にずらした位置へ移動
        transform.position = startPosition + new Vector3(xOffset, 0, 0);
        }
        else
        {
            // -1 〜 1 の間で滑らかに変化する値を計算
        float yOffset = Mathf.Sin(Time.time * speed) * distance;

        // 初期位置から上下（Y軸）にずらした位置へ移動
        transform.position = startPosition + new Vector3(0, yOffset, 0);
        }
    }
}
