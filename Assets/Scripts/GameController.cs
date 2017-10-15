using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private PanelSlider settingButton;
	[SerializeField] private PanelSlider menuButton;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTapMenuButton(bool isIn)
	{
		if(isIn)
		{	
			settingButton.SlideOut();
			menuButton.SlideIn();
		}else{
			settingButton.SlideIn();
			menuButton.SlideOut();
		}
	}
}
