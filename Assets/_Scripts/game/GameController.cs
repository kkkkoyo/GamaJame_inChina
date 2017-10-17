using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreLabel;
    private bool isFinished = false;
    private bool isStart = false;
    private bool isPlaying = false;

    private bool isPause = false;

    [SerializeField] private Image StartImage;
    [SerializeField] private Sprite[] CountDownSprite;
    [SerializeField] private Image StartImage_2;

    private bool[] isLeftTap = new bool [2]{false,false};
    private bool[] isRightTap = new bool [2]{false,false};
    [SerializeField]private Image[] isTapButton;

    // private Color beforeColor;
    // private Color afterColor;
    // private Color prepareColor;
    private bool isButtonChecker = false;
    private float StartTime = 0;
    private float GameTime = 0;
    private float GameStartTime = 0;
    private int touchDangerCount = 0;
    private float Timer = 0;
    private float select_TimeLimit = 3f;
    private bool[] isTImerChecker = new bool [4]{false,false,false,false};
    private bool isCounterChecker = false;
    [SerializeField]private Image PauseButton;
    private float DangerTime = 0;
    private float DangerStartTime = 0;
    private float DangerReuseSpeed = 1f;
    [SerializeField] private Image FinishedImage;
    [SerializeField] private Text ScoreText;
    private int score = 0;
    private int [] CH_LIM = new int[5]　{1000,800,600,400,200}; //const_num

    void Awake()
    {
        // prepareColor  = Color.white;
        // beforeColor = Color.gray;
        // afterColor  = Color.gray;
    }
    private Color prepareColor()
    {
        return new Color(255,255,55,125f);
    }
    private Color beforeColor()
    {
        return new Color(255,255,255,255f);
    }
    private Color afterColor()
    {
        return new Color(255,255,255,0.2f);
    }
    public void GoMenu(){
        SceneManager.LoadScene("PassChoose");
    }
    public void GoRetry(){
        SceneManager.LoadScene("stage1");
    }
    public void GoRestart(){
        PauseButton.gameObject.SetActive(false);
        isPause = false;
    }
    public void ReduceTouchPoint()
    {
        if(Time.time - DangerStartTime >= DangerReuseSpeed)
        {
            Debug.Log("ReduceTouchPoint");
            DangerStartTime = Time.time;
            //GoRestart();
            touchDangerCount++;
        }
    }
    public void GoalClear()
    {
        int wallScore = 10;
        int GameTimeScore = 10;
        score = CH_LIM[Data.Instance.level]-(int)GameTime-(wallScore*touchDangerCount)*2;
        if(score<=0){
            Debug.Log("score<=0");
            score = 0;
        }
        ScoreText.text = score.ToString();
        FinishedImage.gameObject.SetActive(true);
        //TODO:アニメーション            
    }
    private Color colorrr()
    {
        return new Color(255,255,255,0.5f);
    }
    private void InitTapColors()
    {
        isTapButton[0].color = prepareColor();
        isTapButton[1].color = afterColor();
        isTapButton[2].color = afterColor();
        isTapButton[3].color = prepareColor();
    }
    private void TestKeyButton()
    {
        //isTapStartButton_test
        if (Input.GetKeyDown(KeyCode.T)) {
            isTapStartButton(1);
            isTapStartButton(4);
        }if(Input.GetKeyDown(KeyCode.G)) {
            isTapStartButton(2);
            isTapStartButton(3);
        }
        //isTapOutStartButton_test
        if (Input.GetKeyUp(KeyCode.T)) {
            isTapOutStartButton(1);
            isTapOutStartButton(4);
        }if(Input.GetKeyUp(KeyCode.G)) {
            isTapOutStartButton(2);
            isTapOutStartButton(3);
        }
    }
    
    void Start()
    {

        InitTapColors();
        StartTime = Time.time;
    }
    private void CheckCompleteToLeft()
    {
        isTapButton[1].color = prepareColor();
        isTapButton[2].color = prepareColor();
    }
    public void isTapOutStartButton(int num)
    {
       //return ;//is Test mode, iOS is noReturn
        // if(isStart)
        // {

        // }else{
            if(num==1||num==4)
            {
                for(int i=0;i<4;i++)
                {
                    isTapButton[0].color = prepareColor();
                    isTapButton[1].color = afterColor();
                    isTapButton[2].color = afterColor();
                    isTapButton[3].color = prepareColor();
                }
                for(int i=0;i<2;i++)
                {
                    isLeftTap[i] = false;
                    isRightTap[i] = false;
                }
            }else if((num==2||num==3)&&(isLeftTap[0]&&isLeftTap[1]))
            {
                isTapButton[1].color = prepareColor();
                isTapButton[2].color = prepareColor();
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
                isTapButton[num-1].color = afterColor();//1
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
                isTapButton[num-1].color = afterColor();//2
                isLeftTap[1] = true;
                CheckCompleteToLeft();
            }
        }else if(!isLeftTap[0]&&isLeftTap[1])//prepareLeft
        {
            if(num==1)
            {
                isTapButton[num-1].color = afterColor();//2
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
                    isTapButton[num-1].color = afterColor();//2
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
                    isTapButton[num-1].color = afterColor();//2
                    isRightTap[0] = true;
                }
            }else if(isRightTap[0]&&!isRightTap[1])//prepareLeft
            {
                if(num==3)
                {
                    isTapButton[num-1].color = afterColor();//2
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
            if (timeCount >= 0&&!isTImerChecker[0])
            {

                StartImage.gameObject.SetActive(true);
                StartImage.sprite = CountDownSprite[0];
                isTImerChecker[0] = true;
            }
            if (timeCount >= 1&&!isTImerChecker[1])
            {
                StartImage.sprite = CountDownSprite[1];
                isTImerChecker[1] = true;

            }
            if (timeCount >= 2&&!isTImerChecker[2])
            {
                StartImage.sprite = CountDownSprite[2];
                isTImerChecker[2] = true;

            }
            if (timeCount >= 3&&!isTImerChecker[3])
            {
                StartImage.gameObject.SetActive(false);
                StartImage_2.gameObject.SetActive(true);
                isTImerChecker[3] = true;
            }
            if (timeCount >= 4)
            {
                StartImage.gameObject.SetActive(false);
                StartImage_2.gameObject.SetActive(false);
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
    public void Update ()
    {
        TestKeyButton();
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

                //isFinished = true;
                SoundManager.Instance.StopSe();
                SoundManager.Instance.PlaySe("clear");
                // active object
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