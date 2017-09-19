using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadAnimation : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent("Animator") as Animator;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Enemy>().killed) {
			animator.SetBool("isDead", true);
		}
		else {
			animator.SetBool("isDead", false);
		}

		animator.SetInteger("type", gameObject.GetComponent<Enemy>().type);
	}
}
