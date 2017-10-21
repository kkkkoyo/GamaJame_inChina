using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;	//シーンを遷移させるのに必要なもの

public class GoalBox : MonoBehaviour
{
    [SerializeField] private GameController gamecontroller;
    private bool isFinished = false;
    // オブジェクトと接触した時に呼ばれるコールバック
    void Start()
    {
        gamecontroller = GameObject.Find("GameController").GetComponent<GameController>();
    }
    
    void OnCollisionEnter (Collision hit)
    {
        Debug.Log("hit");

        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag ("Player")) {
        Debug.Log("hit!!!!");

            gamecontroller.GoalClear();   
        }
    }
}
/*
赤い壁にに衝突したときに読み込まれる

接触したタグがPlayerの場合,現在のシーン（今回はstage1）を再帰的に呼び出す
ことにより,ゲームクリアまでゲームを続けることができる


*/