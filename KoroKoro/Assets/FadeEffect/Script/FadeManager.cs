using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FadeManager : SingletonMonoBehaviour<FadeManager> {

	// フェード中の透明度
	private float fadeAlpha = 0;
	// フェード中かどうか
	private bool isFading = false;
	// フェード色
	public Color fadeColor = Color.black;
	
	public void OnGUI ()
	{
		// フェード
		if (isFading == true) {
			//色と透明度を更新して白テクスチャを描画 .
			fadeColor.a = this.fadeAlpha;
			GUI.color = this.fadeColor;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
		}
	}
	
	// 画面遷移 
	public void LoadScene (string scene, float interval)
	{
		if (isFading == false)
		{
			StartCoroutine(TransScene(scene, interval));
		}
	}

	// シーン遷移用コルーチン
	private IEnumerator TransScene (string scene, float interval)
	{
		// だんだん暗く
		isFading = true;
		float time = 0;
		while (time <= interval) {
			fadeAlpha = Mathf.Lerp (0f, 1f, time / interval);      
			time += Time.deltaTime;
			yield return 0;
		}
		
		// シーン切替
		SceneManager.LoadScene(scene);
		
		// だんだん明るく
		time = 0;
		while (time <= interval) {
			fadeAlpha = Mathf.Lerp (1f, 0f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}
		
		isFading = false;
	}
}
