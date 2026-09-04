using UnityEngine;
using TMPro;

public class ClassicManager : MonoBehaviour
{
    public static ClassicManager instance; // どこからでも呼び出せるようにする

    [Header("球数設定")]
    public int remainingBalls = 10; // 残り球数（初期値10）

    [Header("UI設定")]
    public TextMeshPro ballCountText; // 残り球数テキスト
    public GameObject gameOverText;      // ゲームオーバーテキスト

    public bool isGameOver = false;

    void Awake()
    {
        // 簡易的なシングルトン設定
        if (instance == null) instance = this;
    }

    void Start()
    {
        UpdateUI();
        if (gameOverText != null) gameOverText.SetActive(false);
    }

    // 球数を1減らす処理
    public void DecreaseBall()
    {
        if (isGameOver) return;

        remainingBalls--;
        UpdateUI();

        // 球数が0になったらゲームオーバー判定
        if (remainingBalls <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (ballCountText != null)
        {
            ballCountText.text =  remainingBalls + " ";
        }
    }

    void GameOver()
    {
        isGameOver = true;
        if (gameOverText != null)
        {
            gameOverText.SetActive(true); // ゲームオーバーを表示
        }
        Debug.Log("Game Over!");
    }
}