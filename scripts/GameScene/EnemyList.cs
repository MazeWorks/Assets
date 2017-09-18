using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {
	public List<GameObject> enemies;

	// Use this for initialization
	void Start() {

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
	}
}
