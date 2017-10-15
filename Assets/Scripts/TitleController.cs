using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	public void GoGame()
	{
		FadeManager.Instance.LoadLevel("Main",0.5f);
	}
}
