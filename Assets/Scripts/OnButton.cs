using UnityEngine;
using System.Collections;

public class OnButton : MonoBehaviour {

    //button's function.

    public void LevelOne()
    {
        if (XMLManager.getIsPass(1))
            Application.LoadLevel(1);
    }
    public void LevelTwo()
    {
        if (XMLManager.getIsPass(2))
            Application.LoadLevel(2);
    }
    public void LevelThree()
    {
        if (XMLManager.getIsPass(3))
            Application.LoadLevel(3);
    }
    public void LevelFour()
    {
        if (XMLManager.getIsPass(4))
            Application.LoadLevel(4);
    }
    public void LevelFive()
    {
        if (XMLManager.getIsPass(5))
            Application.LoadLevel(5);
    }


}
