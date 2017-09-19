using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitLineChecker : MonoBehaviour {
	public bool hitLine = false;

	// Use this for initialization
	void Start() {
		hitLine = false;
	}

	// Update is called once per frame
	void Update() {
		//print("Update");

	}


	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag == "LineParts") {
			hitLine = true;

			//print("OnTriggerStay");
		}
		else {
			hitLine = false;
		}
		//print("OnTriggerStay");
	}
}
