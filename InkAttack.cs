using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            print("敵を囲んだ");
        }
    }
}
