using UnityEngine;

public class StageSelecter : MonoBehaviour
{
    [Header("移動先のシーン名")]
    public string targetSceneName;

    [Header("フェードにかける時間（秒）")]
    public float fadeTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{targetSceneName} へフェードしながら移動します！");
            
            // FadeManagerのフェードアウト付きシーン遷移を呼び出す
            // ※お使いのFadeManagerの仕様に合わせて、下記のどちらか（あるいは似た関数）を使ってください
            
            // パターンA: インスタンス経由で呼ぶタイプ（一般的）
            FadeManager.Instance.LoadScene(targetSceneName, fadeTime);

            
        }
    }
}