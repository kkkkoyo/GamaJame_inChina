using UnityEngine;
using System.Collections;

public class ItweenCube : MonoBehaviour 
{
	void Start()
	{
		ShowAnimation();
	}

	/// <summary>
	/// 表示アニメーション
	/// </summary>
	void ShowAnimation()
	{
		/* 
		 * --- iTween.Hash 説明 ---
		 * position		: 変化量
		 * time			: アニメーション完了までの時間
		 * easeType 		: アニメーションの仕方(リファレンス参照)
		 * oncomplete		: アニメーション終了時に呼ぶメソッド名
		 * oncompletetarget 	: アニメーション終了時に呼ぶメソッドを受け取るオブジェクト
		 * 
		 * --- iTween 説明 ---
		 * MoveTo 	: 現在の位置から指定の位置まで移動
		 * 引数1 	: 動かしたいオブジェクト
		 * 引数2 	: 動かす挙動を設定するテーブル
		 */

		// パターン１ [Hashを前もって登録してから使う方法]
		// 移動
		var moveHash = new Hashtable();
		moveHash.Add ("position", new Vector3(2f, 2f, 0));
		moveHash.Add ("time", 2f);
		moveHash.Add ("delay", 1f);
		moveHash.Add ("easeType", "easeInOutBack");
		moveHash.Add ("oncomplete", "AnimationEnd");
		moveHash.Add ("oncompletetarget", this.gameObject);
		iTween.MoveTo (this.gameObject, moveHash);
/*
        Hashtable parameters = new Hashtable();
        previousPosition = this.gameObject.transform.position;
        parameters.Add("x", this.gameObject.transform.position.x);
        parameters.Add("y", this.gameObject.transform.position.y+ChangePlayerPos_y);
        parameters.Add("z", this.gameObject.transform.position.z);
        parameters.Add("time", .3);
        parameters.Add("oncomplete", "CompleteHandler");
        parameters.Add("oncompletetarget", gameObject);
        iTween.MoveTo(this.gameObject, parameters);
*/

	}

	/// <summary>
	/// アニメーション終了時
	/// </summary>
	void AnimationEnd()
	{
		var time = 2f;

		// パターン２ [HashをiTweenの中で宣言いていく方法]
		// 移動
		iTween.MoveTo (this.gameObject, iTween.Hash(
			"x", -3f,
			"time", time,
			"oncomplete", "AnimationEnd", 
			"oncompletetarget", this.gameObject, 
			"easeType", "easeInOutBack"
		));

		// 回転
		iTween.RotateTo(this.gameObject, iTween.Hash(
			"x", 90,
			"time", time
		));
			
		// 大きさ
		iTween.ScaleTo(this.gameObject, iTween.Hash(
			"x", 2f,
			"y", 2f,
			"z", 2f,
			"time", time
		));
	}

}