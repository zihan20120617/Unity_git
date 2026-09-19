using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UboatMoverSprict : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeydown(keycode.leftarrow)){
            transform.position += new Vector3(0,0,-10);
        }

        if(Input.Getkeydown(Keycode.rightarrow)){
            transform.position += new Vector3(0,0,10);
        }
    }
}
