﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	//シーン遷移に必要

public class Title_Scene_Change_Controller : MonoBehaviour {

	void Awake()
	{
		SoundManager.Instance.PlayBgm("main");
	}

	public void OnClickedStart()
	{
		SoundManager.Instance.PlaySe("title_se");
		SceneManager.LoadScene("stage1");
	}
		public void OnClickedBack()
	{
		SoundManager.Instance.PlaySe("title_se");
		SceneManager.LoadScene("Title");
	}
}

/*
シーン遷移を管理するスクリプト

他のスクリプトではBuildの際の番号でシーンの再帰を行っていたが
これはシーンの名前で遷移している



*/