using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelButton : MonoBehaviour {

    //update the button's image.depend on isPass
    public Button First;
    public Button Second;
    public Button Third;
    public Button Fourth;
    public Button Fifth;

    struct ButtonInf
    {
        public Button Name;
        public int Level;
        public int Score;
        public bool IsPass;
        public ButtonInf(Button name, int level)
        {
            Name = name;
            Level = level;
            Score = XMLManager.getBestScore(level);
            IsPass = XMLManager.getIsPass(level);
        }
    };

    private void Awake()
    {
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
        int num = 0;
        foreach (ButtonInf button in ButtonList)
        {
            if (button.IsPass == false)
            {
                button.Name.image.overrideSprite = Resources.Load<Sprite>("Sprite/gray");
            }
        }
    }

}
