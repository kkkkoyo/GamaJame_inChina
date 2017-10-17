using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;	//シーンを遷移させるのに必要なもの

public class DangerBox : MonoBehaviour
{
    [SerializeField] private GameController gamecontroller;
    private bool isFinished = false;
    // オブジェクトと接触した時に呼ばれるコールバック
    void OnCollisionEnter (Collision hit)
    {
        if(gamecontroller.GetisFinished()){
            return ;
        }
        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag ("Player")) {

            gamecontroller.ReduceTouchPoint();            
        }
    }
}
/*
赤い壁にに衝突したときに読み込まれる

接触したタグがPlayerの場合,現在のシーン（今回はstage1）を再帰的に呼び出す
ことにより,ゲームクリアまでゲームを続けることができる


*/