using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
	public GameObject obj; //生成するもの(敵)
	public Transform parent; //敵は敵でまとめる

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

		if (MyInput.mouseState[1].press) { //仮。マウス右クリックしたら。
			Vector3 pos = new Vector3(Random.Range(-Constant.UNIT_X / 2 + 1, Constant.UNIT_X / 2 - 1), Constant.UNIT_Y / 2 + 0.5f, 0); //生成する座標

			Instantiate(obj, pos, Quaternion.Euler(0, 0, 0), parent).GetComponent<Enemy>().type = Random.Range(0, 3); //仮にランダムとしている;
		}
	}
}
