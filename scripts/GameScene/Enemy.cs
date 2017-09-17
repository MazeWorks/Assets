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



	// Use this for initialization
	void Start() {
		spriteRenderer.sprite = enemySprite[type]; //種類に合わせて画像を変更
		player = GameObject.FindGameObjectWithTag("Player");
		shotGenerator = transform.Find("ShotGenerator").gameObject;
	}


	//スクロールに合わせて落ちる
	void Scroll() {
		transform.localPosition += new Vector3(0, -BG.velocity, 0);

		//十分画面下まで行ったら消す
		if (transform.localPosition.y < -Constant.UNIT_Y) {
			Destroy(gameObject);
		}
	}

	//自主的に動く
	void Move() {

		if (type == 0) {
			transform.position += new Vector3(0.025f * Mathf.Sin(MyTimer.time), 0, 0);
		}
		else if (type == 1) {

		}
		else if (type == 2) {

		}

	}

	//攻撃
	void Attack() {
		if (frameCount % 120 == 1) {
			shotGenerator.SendMessage("Generate", transform.position);
		}
	}

	// Update is called once per frame
	void Update() {
		Scroll();
		Move();
		Attack();
		//spriteRenderer.sprite = enemySprite[type]; //種類に合わせて画像を変更

		//これはデバッグ用
		if (MyInput.keyState[(int)KeyCode.K].press) {
			Kill();
		}

		frameCount++;
	}


	//攻撃判定
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			//プレイヤーが触れたときの処理(プレイヤーを殺す)
			player.SendMessage("kill");
		}
	}

	//やられた
	void Kill() {
		Destroy(gameObject);
	}
}
