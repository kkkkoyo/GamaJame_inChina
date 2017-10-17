using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Text scoreLabel;
	[SerializeField] private GameObject winnerLabelObject;
    private bool isFinished = false;
    private bool isStart = false;
    private bool isPlaying = false;

    private bool isPause = false;

    [SerializeField] private Image StartImage;
    [SerializeField] private Sprite[] CountDownSprite;
    private bool[] isLeftTap = new bool [2]{false,false};
    private bool[] isRightTap = new bool [2]{false,false};
    [SerializeField]private Image[] isTapButton;

    private Color beforeColor = Color.gray;
    private Color afterColor = Color.red;
    private Color prepareColor = Color.cyan;
    private bool isButtonChecker = false;
    private float StartTime = 0;
    private float GameTime = 0;
    private float GameStartTime = 0;
    private float touchDangerCount = 0;
    private float Timer = 0;
    private float select_TimeLimit = 3f;
    private bool[] isTImerChecker = new bool [4]{false,false,false,false};
    private bool isCounterChecker = false;
    [SerializeField]private Image PauseButton;
    private float DangerTime = 0;
    private float DangerStartTime = 0;
    private float DangerReuseSpeed = 1f;
    public void ReduceTouchPoint()
    {
        if(Time.time - DangerStartTime >= DangerReuseSpeed)
        {
            DangerStartTime = Time.time;
            touchDangerCount++;
        }
    }
    private void InitTapColors()
    {
        Color[] imageColors = new Color [4]{prepareColor,beforeColor,beforeColor,prepareColor};
        for(int i= 0;i<4;i++)
        {
            isTapButton[i].color = imageColors[i];
        }
    }
    private void TestKeyButton()
    {
        //isTapStartButton_test
        if (Input.GetKeyDown(KeyCode.T)) {
            isTapStartButton(1);
        }if(Input.GetKeyDown(KeyCode.G)) {
            isTapStartButton(2);
        }if(Input.GetKeyDown(KeyCode.Y)) {
            isTapStartButton(3);
        }if(Input.GetKeyDown(KeyCode.H)) {
            isTapStartButton(4);
        }
        //isTapOutStartButton_test
        if (Input.GetKeyUp(KeyCode.T)) {
            Debug.Log("Ttest");
            isTapOutStartButton(1);
        }if(Input.GetKeyUp(KeyCode.G)) {
            Debug.Log("Gtest");
            isTapOutStartButton(2);
        }if(Input.GetKeyUp(KeyCode.Y)) {
            Debug.Log("Ytest");

            isTapOutStartButton(3);
        }if(Input.GetKeyUp(KeyCode.H)) {
            Debug.Log("Htest");

            isTapOutStartButton(4);
        }
        // Debug.Log(Input.GetKeyDown(KeyCode.T)+":"
        // +":"+Input.GetKeyDown(KeyCode.G)
        // +":"+Input.GetKeyDown(KeyCode.Y)
        // +":"+Input.GetKeyDown(KeyCode.H)
        // +":"+Input.GetKeyUp(KeyCode.T)
        // +":"+Input.GetKeyUp(KeyCode.G)
        // +":"+Input.GetKeyUp(KeyCode.Y)
        // +":"+Input.GetKeyUp(KeyCode.H)
        // );
    }
    
    void Start()
    {

        InitTapColors();
        StartTime = Time.time;
    }
    private void CheckCompleteToLeft()
    {
        isTapButton[1].color = prepareColor;
        isTapButton[2].color = prepareColor;
    }
    public void isTapOutStartButton(int num)
    {
        return ;//is Test mode, iOS is noReturn
        Color[] imageColors = new Color [4]{prepareColor,beforeColor,beforeColor,prepareColor};

        // if(isStart)
        // {

        // }else{
            if(num==1||num==4)
            {
                for(int i=0;i<4;i++)
                {
                    isTapButton[i].color = imageColors[i];
                }
                for(int i=0;i<2;i++)
                {
                    isLeftTap[i] = false;
                    isRightTap[i] = false;
                }
            }else if((num==2||num==3)&&(isLeftTap[0]&&isLeftTap[1]))
            {
                isTapButton[1].color = prepareColor;
                isTapButton[2].color = prepareColor;
                isRightTap[0] = false;
                isRightTap[1] = false;
            }

       // }
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
        return isPlaying;
    }
    public void GoStartGame()
    {
        //StartCoroutine(PushStart());
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
            if(!isCounterChecker)
            {
                StartTime = Time.time;
                isCounterChecker = true;
            }
            // if(isButtonChecker){
                
			// float timeCount = Time.time - StartTime;

            // }
            float timeCount = Time.time - StartTime;
            //circle.fillAmount = timeCount/select_TimeLimit+0.05f;
            if (timeCount >= 1&&!isTImerChecker[0])
            {

                StartImage.gameObject.SetActive(true);
                StartImage.sprite = CountDownSprite[0];
                isTImerChecker[0] = true;
            }
            if (timeCount >= 2&&!isTImerChecker[1])
            {
                StartImage.sprite = CountDownSprite[1];
                isTImerChecker[1] = true;

            }
            if (timeCount >= 3&&!isTImerChecker[2])
            {
                StartImage.sprite = CountDownSprite[2];
                isTImerChecker[2] = true;

            }
            if (timeCount >= 4&&!isTImerChecker[3])
            {
                StartImage.sprite = CountDownSprite[3];
                isTImerChecker[3] = true;
            }
            if (timeCount >= 5)
            {
                StartImage.gameObject.SetActive(false);
                isPlaying = true;
                isPause = true;
                if(!isStart)
                {
                    InitStart();
                    isStart = true;
                }
                for(int i=0;i<4;i++){
                    isTImerChecker[i] = false;
                }
            }

        }else{
            StartImage.gameObject.SetActive(false);
            isPlaying = false;
            isCounterChecker = false;
            if(isStart&&isPause){
                PauseButton.gameObject.SetActive(true);            
            }
            for(int i=0;i<3;i++){
                isTImerChecker[0] = false;
                isTImerChecker[i] = false;
            }
        }
    }
    private void InitStart()
    {
        GameStartTime = Time.time;
    }
    public void TouchPauseButton()
    {
        PauseButton.gameObject.SetActive(false);
        isPause = false;
    }
    public void Update ()
    {
        TestKeyButton();
        Debug.Log(PauseButton.gameObject.active);
        if(isStart&&!PauseButton.gameObject.active)
        {
            GameTime = Time.time - GameStartTime;
        }
        if(isPlaying)
        {
            CheckPushButton();
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