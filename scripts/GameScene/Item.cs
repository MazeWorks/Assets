using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public SpriteRenderer spriteRenderer; //種類によって画像を変更するためのアレ
	public Sprite[] itemSprite = new Sprite[4]; //アイテム画像

	public int type = 0; //アイテムの種類

	public GameObject player;

	// Use this for initialization
	void Start () {
		spriteRenderer.sprite = itemSprite[type]; //種類に合わせて画像を変更
	}
	

	//スクロールに合わせて落ちる
	void Scroll() {
		transform.localPosition += new Vector3(0, -BG.velocity, 0);

		//十分画面下まで行ったら消す
		if (transform.localPosition.y < -Constant.UNIT_Y) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Scroll();
		spriteRenderer.sprite = itemSprite[type]; //種類に合わせて画像を変更
	}


	//当たり判定
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			//プレイヤーが触れたときの処理
			player.SendMessage("GetItem", type);
			Destroy(gameObject);
		}
	}
}
