using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperControllerTap : MonoBehaviour {
    //課題：タップ用のスクリプトを別で作成
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touchNumState in Input.touches)
        {
            //タップ位置が画面右側で且タグがRightFripperTag
            if (touchNumState.position.x >= Screen.width / 2.0f && tag == "RightFripperTag")
            {
                var touchId = touchNumState.fingerId;
                switch (touchNumState.phase)
                {
                    case TouchPhase.Began:
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        //タップされたorされている時フリッパーを動かす
                        SetAngle(this.flickAngle);
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        //タップが離された時フリッパーを元に戻す
                        SetAngle(this.defaultAngle);
                        break;
                }
            }

            //タップ位置が画面左側で且タグがLeftFripperTag
            if (touchNumState.position.x < Screen.width / 2.0f && tag == "LeftFripperTag")
            {
                var touchId = touchNumState.fingerId;
                switch (touchNumState.phase)
                {
                    case TouchPhase.Began:
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        //タップされたorされている時フリッパーを動かす
                        SetAngle(this.flickAngle);
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        //タップが離された時フリッパーを元に戻す
                        SetAngle(this.defaultAngle);
                        break;
                }
            }
        }
    }
    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
