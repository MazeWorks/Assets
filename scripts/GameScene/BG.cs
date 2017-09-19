using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour {
	public float size; //縦の画像サイズ(マス数)
	public const float velocityDefault = 0.033f;
	public float velocity = velocityDefault; //スクロールの速さ

	public GameObject[] bg = new GameObject[2]; //実際の背景(オブジェクト)
	public SpriteRenderer[] bgSpriteRenderer = new SpriteRenderer[2]; //背景のSprite Renderer

	StateByItem stateByItem;



	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, 0, 0);

		//2枚並べて回す→ループ
		//↓はループ用の初期位置
		for(int i=0; i<bg.GetLength(0); i++) {
			bg[i].transform.localPosition = new Vector3(0, size * i, 0);
		}

		stateByItem = GameObject.Find("StateByItem").GetComponent<StateByItem>();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (stateByItem.stopIsEnable) {
			velocity = 0;
		}
		else {
			velocity = velocityDefault;
		}*/


		//背景を指定の速さで移動させる
		transform.position += new Vector3(0, -velocity, 0);

		//ループさせる
		if (transform.position.y < -size) {
			//この時点では画面には2枚目だけが映る
			//→1枚目の位置に戻す
			transform.position = new Vector3(0, 0, 0);
			//1枚目の色を2枚目の色と同じに
			bgSpriteRenderer[0].color = bgSpriteRenderer[1].color;


			//次ページの色を指定　ページ数から色を決定するルールを決めるといいかなー
			//bgSpriteRenderer[1].color = Color.cyan;
		}
	}
}
