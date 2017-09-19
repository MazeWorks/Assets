using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLogo : MonoBehaviour {

    // 位置取り目的地
    Vector2 goal_position;
    // スケール目的値
    Vector2 goal_scale;

	// Use this for initialization
	void Start () {
        goal_position = new Vector2(0, 0);
        goal_scale = new Vector2(1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        var pos_speed = 2.5f;
        var sca_speed = 0.1f;

        var vel_x = (goal_position.x - transform.position.x) * pos_speed;
        var vel_y = (goal_position.y - transform.position.y) * pos_speed;
        Rigidbody2D rd = gameObject.GetComponent<Rigidbody2D>();
        rd.velocity = new Vector2(vel_x, vel_y);
        if ((goal_position.x - transform.position.x) < 0.01 && (goal_position.y - transform.position.y) < 0.01)
        {
            var pos = transform.position;
            pos.x = 0;
            pos.y = 0;
            transform.position = pos;
        }

        vel_x = (goal_scale.x - transform.localScale.x) * sca_speed;
        vel_y = (goal_scale.y - transform.localScale.y) * sca_speed;
        var sca = transform.localScale;
        sca.x += vel_x;
        sca.y += vel_y;
        transform.localScale = sca;
        if (transform.localScale.x < 1.01 && transform.localScale.y < 1.01)
        {
            sca = transform.localScale;
            sca.x = 1;
            sca.y = 1;
            transform.localScale = sca;
        }
    }

    float euclid(Vector2 pos1, Vector2 pos2)
    {
        var x = pos2.x - pos1.x;
        var y = pos2.y - pos1.y;

        return Mathf.Sqrt(x * x + y * y);
    }
}
