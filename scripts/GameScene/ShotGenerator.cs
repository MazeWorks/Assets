using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGenerator : MonoBehaviour {
	public GameObject shot;
	public Transform parent;


	void Start() {
		parent = GameObject.Find("Shot_").transform;
	}


	public void Generate(Vector3 pos, float angleDeg, float velocity) {
		//生成
		GameObject shotClone = Instantiate(shot, pos, Quaternion.Euler(0, 0, 0), parent);
		
		//角度決定
		shotClone.GetComponent<Shot>().angle = angleDeg * Mathf.Deg2Rad;

		//速度決定
		shotClone.GetComponent<Shot>().velocity = velocity;

		//print("a");
	}

	void Update() {

	}
}
