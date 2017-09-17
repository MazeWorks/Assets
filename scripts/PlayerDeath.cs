using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    // 移動速度
    Vector2 velocity;

    public static PlayerDeath Add(float x, float y)
    {
        GameObject prefab = Resources.Load("prefab/PlayerDeath") as GameObject;
        GameObject g = Instantiate(prefab, new Vector3(x, y), Quaternion.identity) as GameObject;
        PlayerDeath obj = g.GetComponent<PlayerDeath>();
        return obj;
    }

	// Use this for initialization
	void Start () {
        float x = Random.Range(-40, 40) / 10.0f;
        float y = Random.Range(-40, 40) / 10.0f;
        velocity = new Vector2(x, y);
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D rd = GetComponent<Rigidbody2D>();
        rd.velocity = velocity;

        var scale = transform.localScale;
        scale.x *= 0.9f;
        scale.y *= 0.9f;
        scale.z *= 0.9f;
        transform.localScale = scale;

        //velocity *= 0.9f;

        if (scale.x < 0.01f)
        {
            Destroy(this.gameObject);
        }
	}
}
