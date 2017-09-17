using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
	public GameObject target; //自機狙いの時のターゲット
	public float velocity; //弾速
	float angle; //ラジアン角

	public GameObject player;


	// Use this for initialization
	void Start () {
		//これは自機狙い弾の動作(仮)
		target = GameObject.FindGameObjectWithTag("Player");

		float distanceX = target.transform.position.x - transform.position.x;
		float distanceY = target.transform.position.y - transform.position.y;

		angle = Mathf.Atan(distanceY / distanceX);
		//ここまで自機狙い弾

		//画像の向き変更
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle);
	}


	//弾の移動
	void Move() {
		//画像の右側に向かって飛んでくよ
		//全部直線移動弾ならここはもういじらなくておｋ
		transform.position += velocity * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
	}


	// Update is called once per frame
	void Update () {
		Move();

		//画面外に行ったら消去
		if(transform.position.x < -Constant.UNIT_X / 2 - 1 || transform.position.x > Constant.UNIT_X / 2 + 1
			|| transform.position.y < -Constant.UNIT_Y / 2 - 1 || transform.position.y > Constant.UNIT_Y / 2 + 1) {

			Destroy(gameObject);
		}
	}


	//攻撃判定
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			//プレイヤーが触れたときの処理(プレイヤーを殺す)
			player.SendMessage("kill");
		}
	}
}
