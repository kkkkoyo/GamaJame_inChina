using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter (Collider hit)
    {
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag ("Player")) {

            SoundManager.Instance.PlaySe("coin");

            // このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);
        }
    }
}

/*
PlayerとItemとの衝突が起きた際に呼ばれる

Itemを破棄（ゲームからの削除）を行うことで画面から消えるようにする


*/