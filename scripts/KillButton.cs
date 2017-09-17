using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonPush()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        g.SendMessage("kill");
    }
}
