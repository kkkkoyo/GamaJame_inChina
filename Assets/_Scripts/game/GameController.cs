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
    private bool[] isLeftTap = new bool [2]{false,false};
    private bool[] isRightTap = new bool [2]{false,false};
    [SerializeField]private Image[] isTapButton;
    [SerializeField]private Button[] isTapButton_;

    private Color beforeColor = Color.gray;
    private Color afterColor = Color.red;
    private Color prepareColor = Color.cyan;
    private bool isButtonChecker = false;

    private void InitTapColors()
    {
        Color[] imageColors = new Color [4]{prepareColor,beforeColor,beforeColor,prepareColor};
        for(int i= 0;i<4;i++)
        {
            isTapButton[i].color = imageColors[i];
        }
    }
    
    void Start()
    {   
        InitTapColors();
    }
    private void CheckCompleteToLeft()
    {
        isTapButton[1].color = prepareColor;
        isTapButton[2].color = prepareColor;
    }
    public void isTapStartButton(int num)
    {
        if(!isLeftTap[0]&&!isLeftTap[1])//preaseLeft,right
        {
            if(num==1||num==4)
            {
                isTapButton[num-1].color = afterColor;//1
                if(num==1)
                {
                    isLeftTap[0] = true;

                }else{
                    isLeftTap[1] = true;
                }
            }

        }
        //lefttap
        else if(isLeftTap[0]&&!isLeftTap[1])//prepareLeft
        {
            if(num==4)
            {
                isTapButton[num-1].color = afterColor;//2
                isLeftTap[1] = true;
                CheckCompleteToLeft();
            }
        }else if(!isLeftTap[0]&&isLeftTap[1])//prepareLeft
        {
            if(num==1)
            {
                isTapButton[num-1].color = afterColor;//2
                isLeftTap[0] = true;
                CheckCompleteToLeft();
            }
        //after, lefttap
        }else if(isLeftTap[0]&&isLeftTap[1])
        {
            if(!isRightTap[0]&&!isRightTap[1])//preaseLeft,right
            {
                if(num==2||num==3)
                {
                    isTapButton[num-1].color = afterColor;//2
                    if(num==2)
                    {
                        isRightTap[0] = true;
                    }else{
                        isRightTap[1] = true;
                    }
                }

            }
            //lefttap
            else if(!isRightTap[0]&&isRightTap[1])//prepareLeft
            {
                if(num==2)
                {
                    isTapButton[num-1].color = afterColor;//2
                    isRightTap[0] = true;
                }
            }else if(isRightTap[0]&&!isRightTap[1])//prepareLeft
            {
                if(num==3)
                {
                    isTapButton[num-1].color = afterColor;//2
                    isRightTap[1] = true;
                }
            //after, lefttap
            }
        }
    }
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
    private void CheckPushButton()
    {
        if(isLeftTap[0]&&isLeftTap[1]&&isRightTap[0]&&isRightTap[1])
        {
            if(isButtonChecker)
                return;
            isButtonChecker = true;
            GoStartGame();
        }
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
                // active object
                winnerLabelObject.SetActive (true);
            }
        }else{
            CheckPushButton();
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