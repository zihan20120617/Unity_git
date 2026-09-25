using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unimoverSprict : MonoBehaviour
{
    public static bool isGameover = false;
    public static float speed = -0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isGameover == true)
        {
            Gameover();
        }
        else
        {
            transform.position += new Vector3(0,0,speed);
        }
        
        
        
        
        
    }

    void Gameover()
    {
        Time.timeScale = 0f;
        Debug.Log("trtr");
    }
}
