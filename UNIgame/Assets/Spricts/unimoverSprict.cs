using UnityEngine;

public class unimoverSprict : MonoBehaviour
{
    public float speed = -0.1f;
    public float destroyZ = 100.0f;     // 画面外（潜水艦の後ろ）に消えるZ座標

    public static bool isGameover = false;

    void Update()
    {
        if (isGameover) return;

        // 手前に移動
        transform.position += new Vector3(0, 0, speed);

        // 潜水艦を通り過ぎたらカウントして削除
        if (transform.position.z < destroyZ)
        {
            gamemanager.passedUniCount++;
            Destroy(gameObject);
        }
        Debug.Log(gamemanager.passedUniCount);
    }
}