using UnityEngine;
using System.Collections;

public class WheelRotate : MonoBehaviour
{
    float Timer;
    private void Update()
    {
        //rotate,the speed is depend on the scale of themself.
        Timer += Time.deltaTime;
        this.GetComponent<RectTransform>().rotation = Quaternion.AngleAxis(
            (60/(this.GetComponent<RectTransform>().localScale.x - 0.5f)) * -Timer, Vector3.forward);
    }
}
