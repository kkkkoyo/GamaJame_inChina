using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour {

    //title's Animation.

    float size_change = 1;
    bool size_bs = false;
    float size_coefficient;

    private void Awake()
    {
        //this.GetComponent<Image>().color = new Color(2.55f, 2.55f, 2.55f, 1.30f);
        size_coefficient = (float)(this.GetComponent<RectTransform>().sizeDelta.x / this.GetComponent<RectTransform>().sizeDelta.y);
    }

    void Update () {
        SizeControl();
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(100 * size_change,100 * size_change * size_coefficient);
    }

    private void SizeControl()
    {
        if (size_change < 0.9)
        {
            size_bs = true;
        }
        if (size_change > 1.1)
        {
            size_bs = false;
        }
        if (size_bs)
        {
            size_change += (float)(Time.deltaTime * 0.2);
        }
        else
        {
            size_change -= (float)(Time.deltaTime * 0.2);
        }
    }
}
