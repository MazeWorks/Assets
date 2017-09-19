using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNumber : MonoBehaviour {
	public ScoreManager scoreManager;
	public int digit; //何桁目か

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		transform.localPosition = new Vector3(-0.25f - 0.4f * digit, -0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<SpriteRenderer>().sprite = scoreManager.numberSprite[scoreManager.scoreTenDigit[digit]];
	}
}
