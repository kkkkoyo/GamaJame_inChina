using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{

    [SerializeField]private GameObject prefab;
    [SerializeField] private Text a;
    [SerializeField] private Text b;

    bool isBack = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  入力をxとzに代入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (!Application.isEditor)
        {
            x = PhoneAxis_X();
            z = PhoneAxis_Y();
        }
        a.text = x.ToString();
        b.text = z.ToString();
        prefab.gameObject.transform.position = new Vector3(x,z,prefab.gameObject.transform.position.z);

        if (x < 0.1f && isBack)
        {
            //SoundManager.Instance.PlaySe("se07");
            StartCoroutine(Image());
            isBack = false;
        }
        if (x > 0.8f)
        {
            isBack = true;
        }
    }
    private IEnumerator Image()
    {   
        yield return new WaitForSeconds(0.5f);
        //SoundManager.Instance.PlaySe("se07");
    }

    private float PhoneAxis_X()
    {
        Debug.Log(Input.acceleration.x);
        return Input.acceleration.x;
    }
    private float PhoneAxis_Y()
    {
        return Input.acceleration.y;
    }
}

