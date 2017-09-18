using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour {
	bool balance = false;
	public Rigidbody2D rb2;


	// Use this for initialization
	void Start () {
		rb2.velocity = new Vector2(0, -5);
	}
	
	// Update is called once per frame
	void Update () {
		if (balance) {
			transform.position = new Vector3(0, 0.5f * Mathf.Sin(MyTimer.time), 0);
		}
		else if(transform.position.y < 0){
			balance = true;
		}
		
	}
}
