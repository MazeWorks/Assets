using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	public GameObject obj; //生成するもの(アイテム)
	public Transform parent; //アイテムはアイテムでまとめる

	class GeneratePattern {
		float time;
		int type;
		Vector3 pos;
	}

	GeneratePattern[] generatePattern = new GeneratePattern[256];


	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		//if (MyInput.mouseState[0].press) { //仮。マウス左クリックしたら。
		if (MyTimer.frameCount % (15 * 60) == 1) { //コイン以外を15sに一度ランダムに生成
			Vector3 pos = new Vector3(Random.Range(-Constant.UNIT_X / 2 + 1, Constant.UNIT_X / 2 - 1), Constant.UNIT_Y / 2 + 0.5f, 0); //生成する座標

			Instantiate(obj, pos, Quaternion.Euler(0, 0, 0), parent).GetComponent<Item>().type = Random.Range(1, 4);
		}

		if (MyTimer.frameCount % (1 * 60) == Random.Range(0, 60)) { //コインを1sに一度ランダムに生成
			Vector3 pos = new Vector3(Random.Range(-Constant.UNIT_X / 2 + 1, Constant.UNIT_X / 2 - 1), Constant.UNIT_Y / 2 + 0.5f, 0); //生成する座標

			Instantiate(obj, pos, Quaternion.Euler(0, 0, 0), parent).GetComponent<Item>().type = 0;
		}
	}
}
