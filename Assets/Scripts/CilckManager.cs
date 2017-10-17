using UnityEngine;
using System.Collections;

public class CilckManager : MonoBehaviour {

    //the page of welcome.
    public GameObject lefthand;
    public GameObject righthand;
    public GameObject uphand;
    private bool move = false;

	void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            move = true;
            Invoke("jump",1); 
        }
        if (move)
        {
            lefthand.transform.Translate(new Vector3(-5, 0, 0));
            righthand.transform.Translate(new Vector3(5, 0, 0));
            uphand.transform.Translate(new Vector3(0, 5, 0));
        }

    }
    void jump()
    {
        this.gameObject.SetActive(false);
    }
}
