using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class blasterSprict : MonoBehaviour
{
    Rigidbody rb;
    public float jumpPower;
    float yPos = 0;

    [Header("発射成功")]
    public AudioClip blastersound;
    [Header("発射失敗")]
    public AudioClip errorsound;
    [Header("テキスト")]
    public GameObject text;
    [Header("発射キー")]
    [SerializeField] private KeyCode space = KeyCode.Space;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        yPos = transform.position.y;

        // Spaceキーが押されたとき
        if (Input.GetKeyDown(space))
        {
            LaunchBall();
        }

        if (yPos >= 2)
        {
            transform.position = new Vector3(8, 2, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    // ★ キーボードとスマホボタンの両方から呼び出す発射処理
    public void LaunchBall()
{
    // ★ ゲームオーバーなら何もしない
    if (ClassicManager.instance != null && ClassicManager.instance.isGameOver) return;

    if (Ballcontroller.Ballstatus == 0)
    {
        rb.AddForce(transform.up * jumpPower);
        Ballcontroller.Ballstatus = 1;
        Ballcontroller.isfirstpushed = true;
        text.SetActive(false);
        AudioSource.PlayClipAtPoint(blastersound, transform.position, 1.0f);

        // ★ 発射成功時に球数を1減らす
        if (ClassicManager.instance != null)
        {
            ClassicManager.instance.DecreaseBall();
        }
    }
    else
    {
        AudioSource.PlayClipAtPoint(errorsound, transform.position, 1.0f);
    }
}
}