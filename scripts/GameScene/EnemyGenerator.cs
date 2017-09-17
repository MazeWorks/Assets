using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemy; //生成するもの(敵)
	public Transform parent; //敵は敵でまとめる

	public GameObject enemyList;

	/* //レベルデザイン時に使うかも？
	class GeneratePattern {
		float time;
		int type;
		Vector3 pos;
	}

	GeneratePattern[] generatePattern = new GeneratePattern[256];
	*/


	// Use this for initialization
	void Start() {

	}


	//n番目の敵を消す
	void Kill(int n) {
		enemyList.SendMessage("Delete", n);
	}


	// Update is called once per frame
	void Update() {

		if (MyInput.mouseState[1].press) { //仮。マウス右クリックしたら。ToDo
			Vector3 pos = new Vector3(Random.Range(-Constant.UNIT_X / 2 + 1, Constant.UNIT_X / 2 - 1), Constant.UNIT_Y / 2 + 0.5f, 0); //生成する座標

			//生成
			GameObject enemyClone = Instantiate(enemy, pos, Quaternion.Euler(0, 0, 0), parent);
			
			//敵の種類をここで指定
			enemyClone.GetComponent<Enemy>().type = Random.Range(0, 3); //仮にランダムとしている

			//管理リストに追加
			enemyList.SendMessage("Add", enemyClone);
		}
	}
}
