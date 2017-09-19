using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineParts : MonoBehaviour {

    //時間切れ
    bool isTimeup;
    public bool IsTimeUp { get { return isTimeup; } }

    // 自キャラと衝突する権利を得るまでの待機時間
    int isCollision;

    // Use this for initialization
	void Start () {
        isTimeup = false;
        isCollision = 5;
        Invoke("timeup", 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void timeup()
    {
        isTimeup = true;
    }

    void wait(int i)
    {
        isCollision--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("[LineParts]OnCollisionEnter2D:" + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (isCollision <= 0)
        {
            print("[LineParts]OnTriggerEnter2D:" + collision.gameObject.name);
            GameObject line = GameObject.Find("Line");
            line.SendMessage("collision", gameObject);
        }*/
    }
}
