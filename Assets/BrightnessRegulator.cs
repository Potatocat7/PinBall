using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {
    // Materialを入れる
    Material myMaterial;

    // Emissionの最小値
    private float minEmission = 0.3f;
    // Emissionの強度
    private float magEmission = 2.0f;
    // 角度
    private int degree = 0;
    //発光速度
    private int speed = 10;
    // ターゲットのデフォルトの色
    Color defaultColor = Color.white;   // Use this for initialization


    // 課題：スコアに加点する値。初期化はstartで行う
    private int ObjCntState;

    void Start () {
        //課題：タグによって加点する値を設定。加点する値の関係でSmallCloudTagとLargeCloudTagのif文を分割
        // タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
            ObjCntState = 1;
        }
        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
            ObjCntState = 5;
        }
        else if (tag == "SmallCloudTag" )
        {
            this.defaultColor = Color.cyan;
            ObjCntState = 10;
        }
        else if (tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
            ObjCntState = 100;
        }

        //オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);

    }

    // Update is called once per frame
    void Update () {
        if (this.degree >= 0)
        {
            // 光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            // エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;
        //課題：スコアに加点する
        ScoreCount.countScore += ObjCntState;
    }
}
