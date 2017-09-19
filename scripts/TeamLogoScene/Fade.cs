using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
	int fadeLength = 30; //フレーム単位
	int fadeOutStart = 120;

	public float alpha = 255;

	float deltaAlpha; //1フレームにどのくらい透明度変化させればいい？


	// Use this for initialization
	void Start() {
		deltaAlpha = 255.0f / fadeLength;
	}

	// Update is called once per frame
	void Update() {
		//フェードイン
		if (MyTimer.frameCount < fadeLength) {
			alpha -= deltaAlpha;
		}

		//フェードアウト
		if(MyTimer.frameCount > fadeOutStart) {
			alpha += deltaAlpha;
		}

		GetComponent<Image>().color = new Color(0, 0, 0, alpha / 255);
	}
}
