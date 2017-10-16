using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text scoreLabel;
	[SerializeField] private GameObject winnerLabelObject;
    private bool isFinished = false;
    private bool isStart = false;
    [SerializeField] private Image StartImage;
    [SerializeField] private Sprite[] CountDownSprite;

    public bool GetisStart()
    {
        return isStart;
    }
    public void GoStartGame()
    {
        StartCoroutine(PushStart());
    }
    private IEnumerator PushStart()
    {

        StartImage.gameObject.SetActive(true);
        for(int i=0;i<4;i++)
        {
            StartImage.sprite = CountDownSprite[i];
            yield return new WaitForSeconds(1.0f);

        }
            StartImage.gameObject.SetActive(false);
            isStart = true;
    }
    public void Update ()
    {
        if(isStart)
        {
            int count = GameObject.FindGameObjectsWithTag ("Item").Length;
            scoreLabel.text = count.ToString ();
            if (count == 0 && !isFinished) {

                isFinished = true;
                SoundManager.Instance.StopSe();
                SoundManager.Instance.PlaySe("clear");
                // オブジェクトをアクティブにする
                winnerLabelObject.SetActive (true);
            }
        }
    }
    public bool GetisFinished(){
        return isFinished;
    }
}


/*
ゲーム内のスコアを管理している

Itemタグがついたものをカウントし,数を保存
SoundManagerに関すること
など,ゲーム内に必要な値を一手に担っている



*/