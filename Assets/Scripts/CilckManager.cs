using UnityEngine;
using System.Collections;

public class CilckManager : MonoBehaviour {

    //the page of welcome.
    public GameObject downhand;
    public GameObject uphand;
    public GameObject tag;

    private Vector3 whale;
    private Vector3 wheels;

    private static bool move = false;

    private void Awake()
    {
        whale = uphand.transform.position;
        wheels = downhand.transform.position;
    }

    void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            SoundManager.Instance.PlaySe("OK");
            move = true;
            tag.SetActive(false);
            Invoke("jump",1); 
            Data.Instance.isTitleDisplay = true;
        }
        if (move)
        {
            downhand.transform.Translate(new Vector3(0, -5, 0));
            uphand.transform.Translate(new Vector3(0, 5, 0));
        }

    }
    void jump()
    {
        this.gameObject.SetActive(false);
    }

    public void Back()
    {
        tag.SetActive(true);
        CilckManager.move = false;
        uphand.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        downhand.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }
}
