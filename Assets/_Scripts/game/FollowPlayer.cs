using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] private Transform target;    // ターゲットへの参照
    private Vector3 offset;     // 相対座標
    void Start ()
    {
        //自分自身とtargetとの相対距離を求める
        offset = GetComponent<Transform>().position - target.position;
    }
	void Update () {
        // 自分の座標にtargetの座標を代入する     
        GetComponent<Transform>().position = target.position+offset;
	}
}
/*
カメラがPlayer（今回はボール）を追従するようにしている

ここで注目してほしいのは他のプログラムでも何回か登場している[SerializeField]
である.
これは,通常Inspector内に自分で新しい変数入力場を作成することはpublicでないとできないが
これを用いることでprivateでも変数入力場を作成することができる

つまり,ボールのスピードや摩擦力などをわざわざスクリプトで編集しなくても,Inspectorのところで
値を入力することで同じ効果を生むことが出来る

さらに単なる入力場だけでなくプルダウンなども作成できるため興味があればググるとよい


*/