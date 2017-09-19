using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScoreNumber : MonoBehaviour {

    public ResultScore resultScore;
    public int digit; //何桁目か

    // Use this for initialization
    void Start()
    {
        resultScore = GameObject.Find("ResultScore").GetComponent<ResultScore>();
        transform.localPosition = new Vector3(2 - 0.4f * digit, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = resultScore.numberSprite[resultScore.scoreTenDigit[digit]];
    }
}
