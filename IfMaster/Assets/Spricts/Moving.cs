using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [Header("text")]
    public TextMeshPro Text;
    float yPos = 0;//y座標
    public bool Gameover = false;
    public int number = 1;
    int pushed = 0;
    int push = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        pushed = push-pushed;
        if(Gameover == false)
        {
            Game();
        }
        if(yPos <= -5)
        {
            Gameover = true;
            Text.text = "Gameover";
        }
    }

    void Game()
    {
        Text.text = " ";
            yPos = transform.position.y;
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.W))
            {
                transform.position +=  Vector3.up * Time.deltaTime * pushed;
                Debug.Log("up");
            }
            else
            {
                transform.position +=  Vector3.down * Time.deltaTime;
            } 
    }
}
