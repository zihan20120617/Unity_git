using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static int passedUniCount = 0;  // 通過したウニの数
    public int clearTargetCount = 20;      // クリアに必要なウニの数（20個 ＝ 10ウェーブ避ければクリア）

    public GameObject gameOverText;
    public GameObject gameClearText;

    private bool isClear = false;

    void Start()
    {
        // 初期化
        passedUniCount = 0;
        unimoverSprict.isGameover = false;

        // UIを非表示にしておく
        if (gameOverText != null) gameOverText.SetActive(false);
        if (gameClearText != null) gameClearText.SetActive(false);
    }

    void Update()
    {
        // 目標数に達したらクリア
        if (!isClear && !unimoverSprict.isGameover && passedUniCount >= clearTargetCount)
        {
            GameClear();
        }
    }

    public void GameOver()
    {
        unimoverSprict.isGameover = true;
        if (gameOverText != null) gameOverText.SetActive(true);
    }

    public void GameClear()
    {
        isClear = true;
        unimoverSprict.isGameover = true; // 動きをストップ
        if (gameClearText != null) gameClearText.SetActive(true);
    }
}