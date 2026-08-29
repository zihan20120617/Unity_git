using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour
{
    public static int Ballstatus = 0;
    //0=未発射、リセット後　　1=発射後　2=リセット時の一時的な値
    public static bool isfirstpushed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ballstatus == 2 )
        {
            transform.position = new Vector3(8,0,0);
            Ballstatus = 0;
        }
    }
}
