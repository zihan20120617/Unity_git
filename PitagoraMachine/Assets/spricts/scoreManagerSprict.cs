using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class scoreManagerSprict : MonoBehaviour
{
    public static int score = 0;  //現在のスコア
    [Header("この感圧版のプラマイ")] 
    public int plusscore = 10;
    
    [Header("スコア表示用のテキスト")]
    public TextMeshPro scoretext;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = score.ToString();
    }


    void OnCollisionEnter(Collision collision)
    {
        Ballcontroller.Ballstatus = 2;
        score += plusscore;
    }
}
