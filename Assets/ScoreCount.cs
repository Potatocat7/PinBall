using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {
    //スコアの数値部
    public static int countScore;

    //スコア表示用テキスト
    private GameObject gameScoreText;

    // Use this for initialization
    void Start () {
        //スコアの初期化
        countScore = 0;
        //シーン中のgameScoreTextオブジェクトを取得
        this.gameScoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update () {
        //gameScoreTextにスコアの表示
        this.gameScoreText.GetComponent<Text>().text = "得点：" + countScore;

    }
}
