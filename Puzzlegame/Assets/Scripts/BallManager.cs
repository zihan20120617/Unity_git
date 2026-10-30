using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    GameObject ballObjectA;
    GameObject ballObjectB;
    BallBehavior ballBehaviorA;
    BallBehavior ballBehaviorB;

    public enum FazeStatus
    {
        FALL,
        DROP,
        DELETE,
        WAIT
    }

    FazeStatus faze;

    [SerializeField] GameObject[] balls;

    int width = 10;
    int height = 10;

    // 落下したボールのゲームオブジェクトを格納する2次元配列を定義
    GameObject[,] falledBalls;

    // 上下左右の4方向を表すベクトルの配列を定義
    Vector3Int[] rotatePositions = {Vector3Int.right, Vector3Int.up, Vector3Int.left, Vector3Int.down};
    int rotateNumber = 0;

    List<(int, int)> deleteList = new List<(int, int)>();

    public float fallSpeed;
    public float dropSpeed;

    const float NORMAL_SPEED = -3.0f;
    const float FAST_SPEED = -15.0f;
    const float DROP_SPEED = -5.0f;

    //  Start is called before the first frame update
    void Start()
    {
        // 落下速度の設定
        fallSpeed = NORMAL_SPEED;
        dropSpeed = DROP_SPEED;

        // ボール格納リストの初期化
        falledBalls = new GameObject[width, height];

        // フェーズをfallに設定
        faze = FazeStatus.FALL;

        // 最初のボールを生成
        GenerateBall();
    }

    void Update()
    {
        //落下している時
        if(faze == FazeStatus.FALL)
        {
            float size = ballObjectA.transform.localScale.x;
            //→移動
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ballObjectA.transform.position += new Vector3(size,0f,0f);
            }
        }
        // ボールの落下判定
        if (faze == FazeStatus.FALL || faze == FazeStatus.DROP)
        {      
            // 両方が同時に落下した場合
            if (ballBehaviorA.ballStatus == BallBehavior.BallStatus.STOP && ballBehaviorB.ballStatus == BallBehavior.BallStatus.STOP)
            {
                ContainBall(ballBehaviorA.columnNumber, ballBehaviorA.rawNumber, ballObjectA);
                ContainBall(ballBehaviorB.columnNumber, ballBehaviorB.rawNumber, ballObjectB);

                faze = FazeStatus.DELETE;
            }
            // ボール1or2が落下した時
            else if (ballBehaviorA.ballStatus == BallBehavior.BallStatus.STOP || ballBehaviorB.ballStatus == BallBehavior.BallStatus.STOP)
            {              
                // 落下した方の上にもう一方のボールが乗っている時
                if (rotateNumber == 1)
                {
                    ContainBall(ballBehaviorA.columnNumber, ballBehaviorA.rawNumber, ballObjectA);
                    ballBehaviorB.rawNumber = ballBehaviorA.rawNumber + 1;
                    ballBehaviorB.underBall = ballObjectA;
                    ContainBall(ballBehaviorB.columnNumber, ballBehaviorB.rawNumber, ballObjectB);

                    faze = FazeStatus.DELETE;
                }
                else if (rotateNumber == 3)
                {
                    ContainBall(ballBehaviorB.columnNumber, ballBehaviorB.rawNumber, ballObjectB);
                    ballBehaviorA.rawNumber = ballBehaviorB.rawNumber + 1;
                    ballBehaviorA.underBall = ballObjectB;
                    ContainBall(ballBehaviorA.columnNumber, ballBehaviorA.rawNumber, ballObjectA);

                    faze = FazeStatus.DELETE;
                }
                // 落下していない方の下に空間がある場合はDropにステータスを変更
                else
                {
                    if (ballBehaviorA.ballStatus == BallBehavior.BallStatus.STOP)
                    {
                        ballBehaviorB.ballStatus = BallBehavior.BallStatus.DROP;
                    }
                    else if (ballBehaviorB.ballStatus == BallBehavior.BallStatus.STOP)
                    {
                        ballBehaviorA.ballStatus = BallBehavior.BallStatus.DROP;
                    }

                     faze = FazeStatus.DROP;
                }
            }
        }

        if(faze == FazeStatus.DELETE)
        {
            GenerateBall();
        }

    }

    // ボール生成処理
    void GenerateBall()
    {
        // ランダムな色のボールを生成
        int colorId1 = Random.Range(0, 4);
        int colorId2 = Random.Range(0, 4);

        int center = (int)((width - 1) / 2);

        ballObjectA = Instantiate(balls[colorId1], new Vector3(center, height, 0), Quaternion.identity);
        ballObjectB = Instantiate(balls[colorId2], new Vector3(center + 1, height, 0), Quaternion.identity);

        ballBehaviorA = ballObjectA.GetComponent<BallBehavior>();
        ballBehaviorB = ballObjectB.GetComponent<BallBehavior>();

        ballBehaviorA.colorId = colorId1;
        ballBehaviorB.colorId = colorId2;

        ballBehaviorA.columnNumber = center;
        ballBehaviorB.columnNumber = center + 1;

        ballBehaviorA.ballManager = this;
        ballBehaviorB.ballManager = this;

        faze = FazeStatus.FALL;

    }

    // ボール格納処理
    void ContainBall(int x, int y, GameObject ball)
    {   
        falledBalls[x, y] = ball;
        ball.transform.position = new Vector3(x, y, ball.transform.position.z);
        ball.GetComponent<BallBehavior>().ballStatus = BallBehavior.BallStatus.STOP;
    }

    // ボールが枠内にあるかの判定
    

    // 指定位置が空白かどうかの判定
    

    // ボールの接続確認処理(メインのアルゴリズム)
   

    // ボール消去処理


    // リスト内のボールが全て落下し切っているかの判定


    // ゲームオーバー判定


    IEnumerator DeleteObjectDelay()
    {
        dropSpeed = 0f;

        FazeStatus tmpfaze = faze;

        faze = FazeStatus.WAIT;

        // 停止
        yield return new WaitForSecondsRealtime(1f);

        faze = tmpfaze;

        dropSpeed = DROP_SPEED;
    }
}
