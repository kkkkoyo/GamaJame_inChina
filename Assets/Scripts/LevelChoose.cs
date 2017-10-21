using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelChoose : MonoBehaviour {

    //update the button's image.depend on isPass
    public int StageNum;

    public Image First;
    public Image Second;
    public Image Third;
    public Image Fourth;
    public Image Fifth;

    public Text LevelNum;
    public Text BestScore;

    struct ButtonInf
    {
        public Image Name;
        public int Level;
        public int Score;
        public bool IsPass;
        public ButtonInf(Image name, int level)
        {
            Name = name;
            Level = level;
            Score = XMLManager.getBestScore(level);
            IsPass = XMLManager.getIsPass(level);
        }
    };

    private void Start()
    {
        XMLManager.UpdateIsPass(1, true);
        XMLManager.UpdateIsPass(2, true);
        XMLManager.UpdateIsPass(3, true);
        XMLManager.UpdateIsPass(4, true);
        XMLManager.UpdateBestScore(1, 310);
        XMLManager.UpdateBestScore(2, 430);
        XMLManager.UpdateBestScore(3, 220);
        XMLManager.UpdateBestScore(4, 430);
        StageNum = 1;
        UpdateName();
        UpdateScore();
        List<ButtonInf> ButtonList = new List<ButtonInf>();
        ButtonInf Level1 = new ButtonInf(First, 1);
        ButtonList.Add(Level1);
        ButtonInf Level2 = new ButtonInf(Second, 2);
        ButtonList.Add(Level2);
        ButtonInf Level3 = new ButtonInf(Third, 3);
        ButtonList.Add(Level3);
        ButtonInf Level4 = new ButtonInf(Fourth, 4);
        ButtonList.Add(Level4);
        ButtonInf Level5 = new ButtonInf(Fifth, 5);
        ButtonList.Add(Level5);
        foreach (ButtonInf Image in ButtonList)
        {
            if (Image.IsPass == false)
            {
                Image.Name.overrideSprite = Resources.Load<Sprite>("Sprite/gray");
            }
            else
            {
                Image.Name.overrideSprite = Resources.Load<Sprite>("Sprite/yellow");
            }
        }
    }

    public void UpdateName()
    {
        LevelNum.text = StageNum.ToString();
    }

    public void UpdateScore()
    {
        BestScore.text = XMLManager.getBestScore(StageNum).ToString();
    }

}
