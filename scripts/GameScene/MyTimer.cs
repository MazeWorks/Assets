﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour {
	public static float time = 0;
	public static int frameCount = 0;

	// Use this for initialization
	void Start () {
		time = 0;
		frameCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		frameCount++;
	}
}
