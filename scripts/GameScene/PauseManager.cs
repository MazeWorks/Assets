using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
	bool isPause = false;
	public GameObject Ui;
	GameObject tmp;

	// Use this for initialization
	void Start () {
		
	}


	public void ButtonClick() {

		print("button " + isPause + Time.timeScale);

		if (isPause) {
			tmp = Instantiate(Ui);
			Time.timeScale = 0;
		}
		else {
			Time.timeScale = 1;
			Destroy(tmp);
		}
		isPause = !isPause;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
