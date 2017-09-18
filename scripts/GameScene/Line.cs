using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    // 時間切れ
    public bool isTimeUp;

    // プレハブ
    static GameObject _prefab = null;

    public static Line Add(float x, float y)
    {
        _prefab = Resources.Load("prefab/Line") as GameObject;
        GameObject g = Instantiate(_prefab, new Vector3(x, y), Quaternion.identity) as GameObject;
        Line obj = g.GetComponent<Line>();
        return obj;
    }

	// Use this for initialization
	void Start () {
        Invoke("timeup", 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void timeup()
    {
        isTimeUp = true;
    }
}
