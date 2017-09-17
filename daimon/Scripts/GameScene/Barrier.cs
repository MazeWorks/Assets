using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    // プレイヤーのオブジェクト
    GameObject player;

    // アクティブか
    public bool isActive;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}

    public void active()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    public void inactive()
    {
        gameObject.SetActive(false);
        isActive = false;
    }
}
