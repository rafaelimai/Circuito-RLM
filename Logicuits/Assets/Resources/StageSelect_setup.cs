﻿using UnityEngine;
using System.Collections;

public class StageSelect_setup : MonoBehaviour {

	public GUISkin guiSkin;
	float textSize;
	float BUTTON_WIDTH;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		BUTTON_WIDTH = Screen.width/8;
	}

	void OnGUI () {

		GUI.skin = guiSkin;
		guiSkin.label.fontSize = Screen.height/8;
		guiSkin.button.fontSize = Screen.height/16;

		textSize = guiSkin.label.CalcSize(new GUIContent("Stage Select")).x;
		GUI.Label(new Rect ((Screen.width - textSize)/2 , Screen.height*1/4 , textSize , guiSkin.label.fontSize), "Stage Select");

		for (int i = 1; i <= 5; i++) {
			if (GUI.Button(new Rect ((Screen.width - BUTTON_WIDTH)*1f/3f, Screen.height * (8+i)/16, BUTTON_WIDTH, guiSkin.button.fontSize), "Level "+System.Convert.ToString(i))) {
				Level_setup.currentLevel = i;
				Application.LoadLevel("leveleditor");
			}
		}
		for (int i = 6; i <= 10; i++) {
			if (GUI.Button(new Rect ((Screen.width - BUTTON_WIDTH)*2f/3f, Screen.height * (3+i)/16, BUTTON_WIDTH, guiSkin.button.fontSize), "Level "+System.Convert.ToString(i))) {
				Level_setup.currentLevel = i;
				Application.LoadLevel("leveleditor");
			}
		}
	}
}
