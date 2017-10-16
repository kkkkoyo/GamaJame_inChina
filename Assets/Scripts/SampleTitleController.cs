using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void Update()
	{
        if (Input.GetButtonUp ("Fire1")) {
		GoGame();
 		}

	}
	

	public void GoGame()
	{
		FadeManager.Instance.LoadLevel("Main",0.5f);
	}
}
