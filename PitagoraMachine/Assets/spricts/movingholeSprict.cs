using UnityEngine;

public class MovingHole : MonoBehaviour
{
    [Header("移動スピード")]
    public float speed = 2.0f;

    [Header("左右の移動幅")]
    public float distance = 3.0f;

    private Vector3 startPosition;

    void Start()
    {
        // 初期位置を記録
        startPosition = transform.position;
    }

    void Update()
    {
        // -1 〜 1 の間で滑らかに変化する値を計算
        float xOffset = Mathf.Sin(Time.time * speed) * distance;

        // 初期位置から左右（X軸）にずらした位置へ移動
        transform.position = startPosition + new Vector3(xOffset, 0, 0);
    }
}