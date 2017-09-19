using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineParts : MonoBehaviour {

    //時間切れ
    bool isTimeup;
    public bool IsTimeUp { get { return isTimeup; } }

	// Use this for initialization
	void Start () {
        isTimeup = false;
        Invoke("timeup", 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void timeup()
    {
        isTimeup = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("[LineParts]OnCollisionEnter2D:" + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("[LineParts]OnTriggerEnter2D:" + collision.gameObject.name);
    }
}
