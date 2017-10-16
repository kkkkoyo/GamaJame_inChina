using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // speedを制御する
    public float speed = 10;
    [SerializeField] private GameController gamecontroller;
	 void FixedUpdate ()
    {
        if(!gamecontroller.GetisStart())
            return;
        //  入力をxとzに代入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if(!Application.isEditor){
            x = PhoneAxis_X();
            z = PhoneAxis_Y();

        }
		// 同一のGameObjectが持つRigidbodyコンポーネントを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        // rigidbodyのx軸（横）とz軸（奥）に力を加える
        rigidbody.AddForce(x*speed, 0, z*speed);
    }
    private float PhoneAxis_X(){

        return Input.acceleration.x;
    }
    private float PhoneAxis_Y(){

        return Input.acceleration.y;
    }
}

/*
Player（ボール）に関する値を管理する

ここで注目したいのは

public float speed = 10

である.別のスクリプトで説明したが[SerializeField]を用いないでInspectorに
表示させる方法である.しかし,publicを用いているため,他の機密性に欠ける点に注意



*/
