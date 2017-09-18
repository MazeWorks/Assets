using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateByItem : MonoBehaviour {
	public int feverGauge = 0;

	const int feverMax = 20;

	public float feverTime = 0;
	const float feverEndTime = 10;

	public bool isFever = false;




	public float stopTime = 0;
	public float magnetTime = 0;

	const float stopEndTime = 4;
	const float magnetEndTime = 10;

	public bool stopIsEnable = false;
	public bool magnetIsEnable = false;


	ScoreManager scoreManager;


	// Use this for initialization
	void Start() {
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
	}


	void GetItem(int num) {
		if (num == 0) { //収集
			if (feverGauge < feverMax) {
				feverGauge++;
			}
			else {
				feverGauge = 0;
				feverTime = 0;
				isFever = true;
			}

			scoreManager.score += 100;
		}
		else if (num == 1) { //バリア
							 //これはPlayerで処理
		}
		else if (num == 2) { //ストップ
			stopIsEnable = true;
			stopTime = 0;
		}
		else { //マグネット
			magnetIsEnable = true;
			magnetTime = 0;
		}
		print("get item " + num);
	}


	// Update is called once per frame
	void Update() {
		if (stopIsEnable) {
			if (stopTime < stopEndTime) {
				stopTime += Time.deltaTime;
			}
			else {
				stopIsEnable = false;
			}
		}
		else {
			stopTime = 0;
		}

		if (magnetIsEnable) {
			if (magnetTime < magnetEndTime) {
				magnetTime += Time.deltaTime;
			}
			else {
				magnetIsEnable = false;
			}
		}
		else {
			magnetTime = 0;
		}
	}
}
