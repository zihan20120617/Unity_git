using UnityEngine;
using TMPro;

public class ClassicManager : MonoBehaviour
{
    public static ClassicManager instance;

    [Header("球数設定")]
public int remainingBalls = 10; // 残り球数（初期値10）

[Header("UI設定")]
public TextMeshPro ballCountText; // 残り球数テキスト
public GameObject gameOverText;   // ゲームオーバーテキスト

public bool isGameOver = false;

void Awake()
{
    if (instance == null) instance = this;
}

void Start()
{
    Time.timeScale = 1f; // ゲーム開始時に時間を正しく動かす
    UpdateUI();
    if (gameOverText != null)
    {
        gameOverText.SetActive(false); // 開始時は非表示
    }
}

// ★ 1. 発射時に呼び出す（球数を1減らすだけ）
public void DecreaseBall()
{
    if (isGameOver) return;
    remainingBalls--;
    UpdateUI();
}

// ★ 2. ボールが穴に入った（得点が入った）直後に呼び出す
public void OnBallInHole()
{
    if (isGameOver) return;

    // 残り球数が0以下なら、穴に入ったこの瞬間にゲームオーバー！
    if (remainingBalls <= 0)
    {
        GameOver();
    }
}

void UpdateUI()
{
    if (ballCountText != null)
    {
        ballCountText.text = remainingBalls.ToString();
    }
}

void GameOver()
{
    isGameOver = true;
    if (gameOverText != null)
    {
        gameOverText.SetActive(true); // ゲームオーバーを表示
    }
    Time.timeScale = 0f; // ゲーム全体の動きを完全にストップ
    Debug.Log("Game Over!");
}
}