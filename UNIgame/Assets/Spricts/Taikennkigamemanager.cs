using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Taikennkigamemanager : MonoBehaviour
{
    [Header("クリア")]
    public TextMeshProUGUI gameclear;
    [Header("失敗")]
    public TextMeshProUGUI gameover;
    [Header("うに")]
    public GameObject UNI;

    string clear = "Gameclear";
    string over = "Gameover";
    string none = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UNI.transform.position.z <= -30)
        {
            gameclear.text = clear;
        }
        else if(unimoverSprict.isGameover == false)
        {
            gameclear.text = none;
            gameover.text = none;
        }
        else
        {
            
            gameover.text = over;
        }
    }
}
