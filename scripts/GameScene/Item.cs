using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public SpriteRenderer spriteRenderer; //種類によって画像を変更するためのアレ
	public Sprite[] itemSprite = new Sprite[4]; //アイテム画像

	public int type = 0; //アイテムの種類

	public GameObject player;
	public GameObject stateByItem;
	BG bg;

	StateByItem sbi;



	// Use this for initialization
	void Start () {
		spriteRenderer.sprite = itemSprite[type]; //種類に合わせて画像を変更
		player = GameObject.FindGameObjectWithTag("Player");
		stateByItem = GameObject.Find("StateByItem");
		bg = GameObject.Find("BG_").GetComponent<BG>();

		sbi = stateByItem.GetComponent<StateByItem>();
	}


	//スクロールに合わせて落ちる
	void Scroll() {
		transform.localPosition += new Vector3(0, -bg.velocity, 0);

		//十分画面下まで行ったら消す
		if (transform.localPosition.y < -Constant.UNIT_Y) {
			Destroy(gameObject);
		}
	}


	float GetDistance(GameObject obj1, GameObject obj2) {
		return Mathf.Sqrt(Mathf.Pow(obj1.transform.position.x - obj2.transform.position.x, 2)
			+ Mathf.Pow(obj1.transform.position.y - obj2.transform.position.y, 2));
	}


	//磁石
	void Magnet() {
		//一定距離以内ならプレイヤーに吸われる
		if (GetDistance(player, gameObject) < Constant.UNIT_Y * 0.5f) {
			transform.position += 0.05f * (player.transform.position - transform.position);
		}
	}


	
	// Update is called once per frame
	void Update () {
		Scroll();
		spriteRenderer.sprite = itemSprite[type]; //種類に合わせて画像を変更

		if (sbi.magnetIsEnable) {
			Magnet();
		}
	}


	//当たり判定
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			//プレイヤーが触れたときの処理
			player.SendMessage("GetItem", type);
			stateByItem.SendMessage("GetItem", type);
			Destroy(gameObject);
		}
	}
}
