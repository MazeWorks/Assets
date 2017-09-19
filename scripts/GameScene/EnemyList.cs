using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {
	public List<GameObject> enemies;


	// Use this for initialization
	void Start() {

	}

	void Surround() {
		//囲まれ判定
		if (enemies == null) return;
		for (int i = 0; i < enemies.Count; i++) {
			//Enemy ene = 
			if (enemies[i].GetComponent<Enemy>().ehlcRi == null) return;
			if (enemies[i].GetComponent<Enemy>().ehlcRi.hitLine &&
				enemies[i].GetComponent<Enemy>().ehlcHi.hitLine &&
				enemies[i].GetComponent<Enemy>().ehlcLe.hitLine &&
				enemies[i].GetComponent<Enemy>().ehlcLo.hitLine) {


				Delete(i);

			}
			print(i + "右" + enemies[i].GetComponent<Enemy>().ehlcRi.hitLine);
			print(i + "上" + enemies[i].GetComponent<Enemy>().ehlcHi.hitLine);
			print(i + "左" + enemies[i].GetComponent<Enemy>().ehlcLe.hitLine);
			print(i + "下" + enemies[i].GetComponent<Enemy>().ehlcLo.hitLine);
		}

		GameObject line = GameObject.Find("Line");
		if(line != null) {
			line.SendMessage("EnemyAttacked");
		}
	}


	//追加
	void Add(GameObject enemy) {
		enemies.Add(enemy);
	}

	//n番目の敵をリストから消す
	void Delete(int n) {
		enemies[n].SendMessage("Kill");
		enemies.RemoveAt(n);
	}

	// Update is called once per frame
	void Update() {
		//print(enemies.Count);

		//十分画面下まで行ったら消す
		for (int i = 0; i < enemies.Count; i++) {
			/*
			print(i);
			print(enemies[i].transform.position.y);
			*/
			if (enemies[i].transform.position.y < -Constant.UNIT_Y) {
				Delete(i);
			}

		}

		//デバッグ用、敵全消し
		if (MyInput.keyState[(int)KeyCode.K].pressed) {
			for (int i = 0; i < enemies.Count; i++) {
				Delete(i);
			}
		}

		/*
		if (enemies.Count > 0) {
			//print(enemies[0].GetComponent<Enemy>().ehlcRi.name);
			EnemyHitLineChecker hoge = enemies[0].GetComponent<Enemy>().ehlcRi;
			bool hoge2 = false;
			hoge2 = hoge.hitLine;
		}*/


	}
}
