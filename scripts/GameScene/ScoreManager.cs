using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public int score = 0; //スコア
	public float distance = 0; //進んだ距離

	public int[] scoreTenDigit = new int[6]; //スコアの各桁の数
	public int[] distanceTenDigit = new int[6]; //距離の各桁の数

	public Sprite[] numberSprite = new Sprite[10];
	public SpriteRenderer[] numberRenderer = new SpriteRenderer[10];

	public GameObject scoreNumber;
	public GameObject distanceNumber;
	public Transform parent;


	// Use this for initialization
	void Start() {
		parent = GameObject.Find("ScoreManager").transform;

		//スコア数字生成
		for (int i = 0; i < 6; i++) {
			Instantiate(scoreNumber, parent).GetComponent<ScoreNumber>().digit = i;
		}

		//距離数字生成
		for (int i = 0; i < 5; i++) {
			Instantiate(distanceNumber, parent).GetComponent<DistanceNumber>().digit = i;
		}
	}

	// Update is called once per frame
	void Update() {
		//各桁の数を計算
		for (int i = 0; i < scoreTenDigit.GetLength(0); i++) {
			scoreTenDigit[i] = score / (int)Mathf.Pow(10, i) % 10;
		}

		for (int i = 0; i < distanceTenDigit.GetLength(0); i++) {
			distanceTenDigit[i] = (int)distance / (int)Mathf.Pow(10, i) % 10;
		}
	}
}
