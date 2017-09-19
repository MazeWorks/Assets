using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemy; //生成するもの(敵)
	public Transform parent; //敵は敵でまとめる

	public GameObject enemyList;


	string fileName = "enemy"; //ファイル名
	TextAsset csvFile; //csvファイル



	//敵出現パターン
	class GeneratePattern {
		public float time;
		public int type;
		public Vector3 pos;
	}

	//配列
	//GeneratePattern[] generatePattern = new GeneratePattern[256];

	//リスト
	List<GeneratePattern> generatePattern_ = new List<GeneratePattern>();


	//ステージデータ読み込み
	void Read() {
		//配列
		/*
		for (int j = 0; j < generatePattern.GetLength(0); j++) {
			generatePattern[j] = new GeneratePattern();
		}
		*/



		csvFile = Resources.Load<TextAsset>("CSV/" + fileName);
		StringReader reader = new StringReader(csvFile.text);

		//int i = 0;
		while (reader.Peek() > -1) {
			string line = reader.ReadLine();
			string[] separated = line.Split(',');

			for (int j = 0; j < separated.GetLength(0); j++) {
				//print(separated[j]);
			}

			//リスト
			generatePattern_.Add(new GeneratePattern());
			generatePattern_[generatePattern_.Count - 1].time = float.Parse(separated[0]);
			generatePattern_[generatePattern_.Count - 1].type = int.Parse(separated[1]);
			generatePattern_[generatePattern_.Count - 1].pos = new Vector3(float.Parse(separated[2]), Constant.UNIT_Y / 2 + 1, 0);

			//print("time: " + generatePattern_[generatePattern_.Count - 1].time);
			//print("type: " + generatePattern_[generatePattern_.Count - 1].type);
			//print("pos.x: " + generatePattern_[generatePattern_.Count - 1].pos.x);

			//配列
			/*
			generatePattern[i].time = float.Parse(separated[0]);
			generatePattern[i].type = int.Parse(separated[1]);
			generatePattern[i].pos = new Vector3(float.Parse(separated[2]), Constant.UNIT_Y / 2 + 1, 0);

			print("time: " + generatePattern[i].time);
			print("type: " + generatePattern[i].type);
			print("pos.x: " + generatePattern[i].pos.x);
			
			i++;
			*/
		}
	}


	// Use this for initialization
	void Start() {
		Read();
	}


	//n番目の敵を消す
	void Kill(int n) {
		enemyList.SendMessage("Delete", n);
	}


	// Update is called once per frame
	void Update() {

		/*
		if (MyInput.mouseState[1].press) { //仮。マウス右クリックしたら。ToDo
			Vector3 pos = new Vector3(Random.Range(-Constant.UNIT_X / 2 + 1, Constant.UNIT_X / 2 - 1), Constant.UNIT_Y / 2 + 0.5f, 0); //生成する座標

			//生成
			GameObject enemyClone = Instantiate(enemy, pos, Quaternion.Euler(0, 0, 0), parent);

			//敵の種類をここで指定
			enemyClone.GetComponent<Enemy>().type = Random.Range(0, 6); //仮にランダムとしている

			//管理リストに追加
			enemyList.SendMessage("Add", enemyClone);
		}*/

		/*
		if (MyInput.mouseState[1].press) { //デバッグ敵生成

			Vector3 pos = new Vector3(Event.current.mousePosition.x, Event.current.mousePosition.y, 0); //生成する座標

			//生成
			GameObject enemyClone = Instantiate(enemy, pos, Quaternion.Euler(0, 0, 0), parent);

			//敵の種類をここで指定
			enemyClone.GetComponent<Enemy>().type = 6; //デバッグ敵、6番

			//管理リストに追加
			enemyList.SendMessage("Add", enemyClone);
		}*/

		for (int i = (int)KeyCode.Alpha1; i < (int)KeyCode.Alpha1 + 6; i++) {
			if (MyInput.keyState[i].press) { //1 - 6キーで各敵キャラ生成

				Vector3 pos = new Vector3(0, Constant.UNIT_Y / 2, 0); //生成する座標

				//生成
				GameObject enemyClone = Instantiate(enemy, pos, Quaternion.Euler(0, 0, 0), parent);

				//敵の種類をここで指定
				enemyClone.GetComponent<Enemy>().type = i - (int)KeyCode.Alpha1;

				//管理リストに追加
				enemyList.SendMessage("Add", enemyClone);
			}
		}

		for (int i = 0; i < generatePattern_.Count; i++) {
			//時間になったら
			if (generatePattern_[i].time <= MyTimer.time && MyTimer.time < generatePattern_[i].time + Time.deltaTime) {
				//場所を指定して生成
				GameObject enemyClone = Instantiate(enemy, generatePattern_[i].pos, Quaternion.Euler(0, 0, 0), parent);

				//敵の種類を指定
				enemyClone.GetComponent<Enemy>().type = generatePattern_[i].type;

				//管理リストに追加
				enemyList.SendMessage("Add", enemyClone);
			}
		}
	}
}
