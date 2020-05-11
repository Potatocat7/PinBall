using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreData : MonoBehaviour {
    //課題：スコア加点用スクリプト
    // スコアに加点する値。初期化はstartで行う
    private int ObjCntState;
    // スコア表記のオブジェクト用
    private GameObject ScoreTextObj;
    // Use this for initialization
    void Start () {

        // タグによって加点する値を変える
        if (tag == "SmallStarTag")
        {
            ObjCntState = 1;
        }
        else if (tag == "LargeStarTag")
        {
            ObjCntState = 5;
        }
        else if (tag == "SmallCloudTag")
        {
            ObjCntState = 10;
        }
        else if (tag == "LargeCloudTag")
        {
            ObjCntState = 100;
        }
        //ScoreTextを探してセット
        this.ScoreTextObj = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update () {

    }
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //課題：スコアに加点する
        ScoreTextObj.GetComponent<ScoreCount>().countScore += ObjCntState;
    }
}
