using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGenerator : MonoBehaviour {
	public GameObject shot;
	public Transform parent;


	void Start() {
		parent = GameObject.Find("Shot_").transform;
	}


	void Generate(Vector3 pos) {
		Instantiate(shot, pos, Quaternion.Euler(0, 0, 0), parent);
		print("a");
	}

	void Update() {
		//Generate(new Vector3(0, 0, 0));
	}
}
