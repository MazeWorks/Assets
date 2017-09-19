using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineParts_ : MonoBehaviour {
	public float time = 0;

	//時間切れ
	bool isTimeup;
	public bool IsTimeUp { get { return isTimeup; } }

	// Use this for initialization
	void Start() {
		isTimeup = false;
		Invoke("timeup", 2.0f);
	}

	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;
	}

	void timeup() {
		isTimeup = true;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		print("[LineParts]OnCollisionEnter2D:" + collision.gameObject.name);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		print("[LineParts]OnTriggerEnter2D:" + collision.gameObject.name);
	}
}
