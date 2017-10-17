﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OnButton : MonoBehaviour {

    public GameObject Choose;
    public GameObject wheel;

    public void OnRight()
    {
        if (XMLManager.getIsPass(Choose.GetComponent<LevelChoose>().StageNum + 1) 
            && Choose.GetComponent<LevelChoose>().StageNum < 5)
        {
            Choose.GetComponent<LevelChoose>().StageNum += 1;
            Choose.GetComponent<LevelChoose>().UpdateName();
            Choose.GetComponent<LevelChoose>().UpdateScore();
        }
    }

    public void OnLeft()
    {
        if (XMLManager.getIsPass(Choose.GetComponent<LevelChoose>().StageNum - 1)
            && Choose.GetComponent<LevelChoose>().StageNum > 1)
        {
            Choose.GetComponent<LevelChoose>().StageNum -= 1;
            Choose.GetComponent<LevelChoose>().UpdateName();
            Choose.GetComponent<LevelChoose>().UpdateScore();
        }
    }

    public void OnStart()
    {
        switch (Choose.GetComponent<LevelChoose>().StageNum)
        {
            //start Stage1
            case 1:
                SceneManager.LoadScene("stage1");
                break;
            //stage2
            case 2:
                SceneManager.LoadScene("stage1");
                break;
            //stage3
            case 3:
                break;
            //stage4
            case 4:
                break;
            //stage5
            case 5:
                break;
            default:
                break;
        }
    }

    public void On_button()
    {
        wheel.SetActive(true);
        wheel.GetComponent<CilckManager>().Back();
    }
}
