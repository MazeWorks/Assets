using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void MoveUp() {
		gameObject.transform.position = new Vector3(0, -5.5f, 0);
	}

	void OnTriggerEnter2D(Collider2D col) {
		Invoke("MoveUp", 0.75f);
		print("trigger enter");
	}
}
