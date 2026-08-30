using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class scoreManagerSprict : MonoBehaviour
{
    public static int score = 0;

    [Header("この穴の加算ポイント")]
    public int plusscore;

    [Header("穴の数値テキスト（+10などを表示するTMP）")]
    public TextMeshPro holeValueText;

    [Header("最終的なスコア表示")]
    public TextMeshPro scoretext;

    [Header("穴に入った時の効果音（成功）")]
    public AudioClip goodsoundEffect;

    [Header("穴に入った時の効果音（失敗）")]
    public AudioClip badsoundEffect;

    void Start()
    {
        // ゲーム開始時に数値を決める
        ShuffleScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Ball") || collision.gameObject.CompareTag("Player"))
        {
            // 1. スコアの加算
            score += plusscore;
            scoretext.text = score.ToString();
            //音を鳴らす
            if(plusscore >= 0)
            {
                AudioSource.PlayClipAtPoint(goodsoundEffect,transform.position,1.0f);
            }

            else
            {
                AudioSource.PlayClipAtPoint(badsoundEffect,transform.position,1.0f);
            }

            // 2. ボールのリセット
            Ballcontroller.Ballstatus = 2;

            // 3. ステージ上の「すべての穴」の数値を一斉にシャッフル！
            scoreManagerSprict[] allHoles = FindObjectsOfType<scoreManagerSprict>();
            foreach (scoreManagerSprict hole in allHoles)
            {
                hole.ShuffleScore();
            }

            
        }
    }

    // 数値をシャッフルして表示を更新する専用関数
    public void ShuffleScore()
    {
        int[] choices = { -15,-10,-10, -5, 10, 10, 15, 20 };
        plusscore = choices[Random.Range(0, choices.Length)];

        if (holeValueText != null)
        {
            holeValueText.text = plusscore > 0 ? $"+{plusscore}" : plusscore.ToString();
        }
    }
}