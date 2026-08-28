using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Gamemanager_stage_0 : MonoBehaviour
{
    bool stage_clear = false;
    int currentStageNumber = 0;

    public  CameraController cameraController;
    [SerializeField] GameObject target;
    public float yPos = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        yPos = target.transform.position.y;

        if (yPos < -4)
        {
            Debug.Log("落下");
            target.transform.position = new Vector3(0,2,0);
        }
        if (stage_clear == true)
        {
            // 今クリアしたステージが、これまでの最高クリアステージよりも大きい場合だけ更新！
        if (currentStageNumber > CameraController.maxClearedStage)
        {
            CameraController.maxClearedStage = currentStageNumber;
            Debug.Log($"最高クリアステージが ステージ {CameraController.maxClearedStage} に更新されました！");
        }
        else
        {
            Debug.Log("過去のステージクリアなので、進度は更新しません。");
        }

        // このあとに、次のシーンへ遷移する処理などを書く
        FadeManager.Instance.LoadScene("Scene_Select",1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
         stage_clear = true;
    }
    


}
