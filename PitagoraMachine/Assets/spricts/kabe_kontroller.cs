using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kabe_kontroller : MonoBehaviour
{
    public GameObject[] text;
    private bool isMoved = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1,0,0) * Time.deltaTime;
            isMoved = true; 
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1,0,0) * Time.deltaTime;
            isMoved = true; 
        }

        if(isMoved == true)
        {
            text[0].SetActive(false);
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
