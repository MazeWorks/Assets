using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScore : MonoBehaviour {

    public int score = 0; //スコア

    public int[] scoreTenDigit = new int[6]; //スコアの各桁の数

    public Sprite[] numberSprite = new Sprite[10];
    public SpriteRenderer[] numberRenderer = new SpriteRenderer[10];

    public GameObject scoreNumber;
    public Transform parent;


    // Use this for initialization
    void Start()
    {
        parent = GameObject.Find("ResultScore").transform;

        //数字生成
        for (int i = 0; i < 6; i++)
        {
            Instantiate(scoreNumber, parent).GetComponent<ResultScoreNumber>().digit = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //各桁の数を計算
        for (int i = 0; i < scoreTenDigit.GetLength(0); i++)
        {
            scoreTenDigit[i] = score / (int)Mathf.Pow(10, i) % 10;
        }
    }
}
