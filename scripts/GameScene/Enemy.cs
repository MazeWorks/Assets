using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public SpriteRenderer spriteRenderer; //種類によって画像を変更するためのアレ
	public Sprite[] enemySprite = new Sprite[3]; //敵画像

	public int type = 0; //敵の種類

	public GameObject player; //プレイヤー。キルメッセージ送る用
	public GameObject shotGenerator; //弾撃つやつ。メッセージ送る用

	int frameCount = 0; //生成されてからの時間(フレーム数)
						//何秒に一度撃つ、みたいな処理をするのにfloat型はめんどいのでここはフレーム数で

	bool killed = false;
	float timeSinceKilled = 0;

	public BG bg;
	public StateByItem stateByItem;

	int state = 0;

	int[] score = { 150, 400, 100, 150, 400, 200 };
	ScoreManager scoreManager;



	// Use this for initialization
	void Start() {
		spriteRenderer.sprite = enemySprite[type]; //種類に合わせて画像を変更
		player = GameObject.FindGameObjectWithTag("Player");
		shotGenerator = transform.Find("ShotGenerator").gameObject;

		bg = GameObject.Find("BG_").GetComponent<BG>();
		stateByItem = GameObject.Find("StateByItem").GetComponent<StateByItem>();

		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
	}


	//スクロールに合わせて落ちる
	void Scroll() {
		transform.localPosition += new Vector3(0, -bg.velocity, 0);
	}

	//自主的に動く ToDo
	void Move() {

		if (type == 0) { //ミニオックス
			float velocity = 0.05f;

			if (Mathf.Abs(transform.position.x - player.transform.position.x) < 1.0f //X座標が近い
				&& transform.position.y > player.transform.position.y) { //回り込まれてない

				transform.localPosition += new Vector3(0, -velocity, 0); //突進
			}
		}
		else if (type == 1) { //オックス

		}
		else if (type == 2) { //リーフ
							  //直進。何もしない。
		}
		else if (type == 3) { //ミニウルフ

		}
		else if (type == 4) { //ウルフ

		}
		else if (type == 5) { //ボムボム
							  //蛇行
			transform.position += new Vector3(0.025f * Mathf.Sin(MyTimer.time), 0, 0);
		}
		else if(type == -1) { //デバッグ敵
			transform.localPosition -= new Vector3(0, -bg.velocity, 0);
		}

		//端に行きすぎない
		float leftLimit = -Constant.UNIT_X / 2 + 1;
		float rightLimit = Constant.UNIT_X / 2 - 1;
		if (transform.position.x < leftLimit) {
			transform.position = new Vector3(leftLimit, transform.position.y, 0);
		}
		if (transform.position.x > rightLimit) {
			transform.position = new Vector3(rightLimit, transform.position.y, 0);
		}
	}

	//攻撃 ToDo
	void Attack() {

		if (type == 0) { //ミニオックス

		}
		else if (type == 1) { //オックス

		}
		else if (type == 2) { //リーフ
							  //直進。何もしない。
		}
		else if (type == 3) { //ミニウルフ

		}
		else if (type == 4) { //ウルフ

		}
		else if (type == 5) { //ボムボム

		}
	}

	// Update is called once per frame
	void Update() {
		if (!stateByItem.stopIsEnable) {
			Scroll();
			if (!killed) {
				Move();
				Attack();
			}
		}
		//spriteRenderer.sprite = enemySprite[type]; //種類に合わせて画像を変更

		frameCount++;
		if (killed) {
			KillUpdate();
		}
	}


	//攻撃判定
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player" && !killed) {
			//プレイヤーが触れたときの処理(プレイヤーを殺す)
			player.SendMessage("kill");
		}
	}

	//やられた
	void Kill() {
		killed = true;
		print("enemy killed");
	}

	//やられ演出用 ToDo
	void KillUpdate() {

		if (timeSinceKilled < 0.5) {
			transform.localScale += 0.015f * new Vector3(1, 1, 1);
			transform.position += new Vector3(Random.Range(-timeSinceKilled / 2.5f, timeSinceKilled / 2.5f), Random.Range(-0.1f, 0.1f), 0);
		}
		else {
			scoreManager.score += score[type];
			Destroy(gameObject);
		}

		timeSinceKilled += Time.deltaTime;
	}
}
