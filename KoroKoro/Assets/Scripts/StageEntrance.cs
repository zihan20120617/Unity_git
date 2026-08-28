using UnityEngine;
using TMPro; // テキスト（TextMeshPro）を扱うために必要

public class StageEntrance : MonoBehaviour
{
    [Header("この穴のステージ番号 (0〜4)")]
    public int stageNumber;

    [Header("設定するオブジェクト（インスペクターから引っ張る）")]
    public GameObject purpleFloor; // 紫の床（コライダーON）
    public GameObject greenFloor;  // 緑の床（コライダーOFF）
    public TextMeshPro statusText; // ステージ名や「クリア！」を出すテキスト

    void Start()
    {
        // 最初のステージ(0)か、または「前のステージ」がクリア済みなら通れる
        if (stageNumber == 0 || CameraController.maxClearedStage >= (stageNumber - 1))
        {
            // 通れる状態（緑をON、紫をOFF）
            purpleFloor.SetActive(false);
            greenFloor.SetActive(true);
        }
        else
        {
            // まだ通れない状態（紫をON、緑をOFF）
            purpleFloor.SetActive(true);
            greenFloor.SetActive(false);
        }

        // もし「このステージ自体」がすでにクリア済みなら、テキストを「クリア！」にする
        if (CameraController.maxClearedStage >= stageNumber)
        {
            statusText.text = "Stage"+ stageNumber+ "                                                                Cleared!";
           
        }
    }
}