using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleController : MonoBehaviour {

	[SerializeField] private Image wheels; 
	// Use this for initialization
	void Awake () {
		SoundManager.Instance.PlayBgm("start");
		if(Data.Instance.isTitleDisplay)
        {
			wheels.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
