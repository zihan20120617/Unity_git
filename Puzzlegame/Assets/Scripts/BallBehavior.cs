using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public enum BallStatus
    {
        FALL,    
        DROP,  
        STOP
    }

    public int colorId;

    public BallStatus ballStatus;

    public int columnNumber;
    public int rawNumber;

    public BallManager ballManager;

    [System.NonSerialized] public GameObject underBall;

    // Start is called before the first frame update
    void Start()
    {
        underBall = null;
    }

    // Update is called once per frame
    void Update()
    {
        // ボールの落下
        if (ballStatus == BallStatus.FALL)
        {
            transform.position += new Vector3(0, ballManager.fallSpeed * Time.deltaTime, 0);
        }
        else if (ballStatus == BallStatus.DROP)
        {
            transform.position += new Vector3(0, ballManager.dropSpeed * Time.deltaTime, 0);
        }
           
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ステージに落下した場合
        if (collision.gameObject.tag == "Stage")
        {
            ballStatus = BallStatus.STOP;
            transform.position = new Vector3(this.transform.position.x, 0f, this.transform.position.z);
            rawNumber = 0;
        }
        // ボールの上に落下した場合
        else if (collision.gameObject.GetComponent<BallBehavior>().columnNumber == columnNumber && ballStatus != BallStatus.STOP)
        {
            ballStatus = BallStatus.STOP;
            transform.position = new Vector3(this.transform.position.x, collision.gameObject.transform.position.y + this.transform.localScale.y, this.transform.position.z);
            rawNumber = collision.gameObject.GetComponent<BallBehavior>().rawNumber + 1;
            underBall = collision.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == underBall)
        {
            ballStatus = BallStatus.DROP;
        }
    }
}
