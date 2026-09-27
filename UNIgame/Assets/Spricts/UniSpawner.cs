using UnityEngine;

public class UniSpawner : MonoBehaviour
{
    [Header("生成設定")]
    public GameObject uniPrefab;        // ウニのプレハブ
    public float spawnInterval = 3.0f;  // 生成間隔（秒）
    public float spawnZ = 20.0f;        // 生成するZ座標

    [Header("3レーンのX座標設定")]
    public float lane1X = -5.0f;        // 1番（左レーン）のX座標
    public float lane2X = 0.0f;         // 2番（中央レーン）のX座標
    public float lane3X = 5.0f;         // 3番（右レーン）のX座標

    private float timer = 0f;

    void Update()
    {
        // ゲームオーバー時はストップ
        if (unimoverSprict.isGameover) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnThreeLanePair();
            timer = 0f;
        }
    }

    void SpawnThreeLanePair()
    {
        if (uniPrefab == null) return;

        // 3つのパターンのうちどれかをランダムに選ぶ（0, 1, 2）
        int pattern = Random.Range(0, 3);

        float firstUniX = 0f;
        float secondUniX = 0f;

        switch (pattern)
        {
            case 0:
                // 1番（左）と 2番（中央）に生成 ➔ 右（3番）が安全
                firstUniX = lane1X;
                secondUniX = lane2X;
                break;

            case 1:
                // 2番（中央）と 3番（右）に生成 ➔ 左（1番）が安全
                firstUniX = lane2X;
                secondUniX = lane3X;
                break;

            case 2:
                // 1番（左）と 3番（右）に生成 ➔ 中央（2番）が安全
                firstUniX = lane1X;
                secondUniX = lane3X;
                break;
        }

        // ウニを2つ生成
        Instantiate(uniPrefab, new Vector3(firstUniX, 0f, spawnZ), Quaternion.identity);
        Instantiate(uniPrefab, new Vector3(secondUniX, 0f, spawnZ), Quaternion.identity);
    }
}