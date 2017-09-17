using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    // スプライト
    public Sprite point;
    public Sprite line;

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
        gameObject.GetComponent<SpriteRenderer>().sprite = line;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpriteChange_line()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = line;
    }

    public void SpriteChange_point()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = line;
    }
}
