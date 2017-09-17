using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour {
	public class KeyState {
		public int count = 0;
		public int countSincePress = 0;
		public int countSinceRelease = 0;
		public bool press = false;
		public bool pressed = false;
		public bool release = false;
	}
	public class MouseState {
		public int count = 0;
		public int countSincePress = 0;
		public int countSinceRelease = 0;
		public bool press = false;
		public bool pressed = false;
		public bool release = false;
	}


	const int keynum = 512;
	const int mousenum = 3;

	public static KeyState[] keyState = new KeyState[keynum];
	public static MouseState[] mouseState = new MouseState[mousenum];

	// Use this for initialization
	void Start () {
		for (int i = 0; i < keynum; i++) {
			keyState[i] = new KeyState();
		}
		for (int i = 0; i < mousenum; i++) {
			mouseState[i] = new MouseState();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//キーボード
		for(int i = 0; i < keynum; i++) {
			if (!Input.GetKey((KeyCode)i) && keyState[i].pressed) {
				keyState[i].release = true;
				keyState[i].countSinceRelease = 0;
			}
			else {
				keyState[i].release = false;
				keyState[i].countSinceRelease++;
			}

			if (Input.GetKey((KeyCode)i)) {
				keyState[i].count++;
				keyState[i].pressed = true;
			}
			else {
				keyState[i].count = 0;
				keyState[i].pressed = false;
			}

			if(keyState[i].count == 1) {
				keyState[i].press = true;
				keyState[i].countSincePress = 0;
			}
			else {
				keyState[i].press = false;
				keyState[i].countSincePress++;
			}
		}

		//マウス
		for (int i = 0; i < mousenum; i++) {
			if (!Input.GetMouseButton(i) && mouseState[i].pressed) {
				mouseState[i].release = true;
				mouseState[i].countSinceRelease = 0;
			}
			else {
				mouseState[i].release = false;
				mouseState[i].countSinceRelease++;
			}

			if (Input.GetMouseButton(i)) {
				mouseState[i].count++;
				mouseState[i].pressed = true;
			}
			else {
				mouseState[i].count = 0;
				mouseState[i].pressed = false;
			}

			if (mouseState[i].count == 1) {
				mouseState[i].press = true;
				mouseState[i].countSincePress = 0;
			}
			else {
				mouseState[i].press = false;
				mouseState[i].countSincePress++;
			}
		}

	}
}
