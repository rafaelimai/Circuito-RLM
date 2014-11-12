using UnityEngine;
using System.Collections;

public class StageSelect_setup : MonoBehaviour {

	public GUISkin guiSkin;
	float textSize;
	float BUTTON_WIDTH;
	public AudioClip levelMusic;

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

	//	textSize = guiSkin.label.CalcSize(new GUIContent("Stage Select")).x;
	//	GUI.Label(new Rect ((Screen.width - textSize)/2 , Screen.height*1/6 , textSize , guiSkin.label.fontSize), "Stage Select");

		for (int i = 1; i <= 8; i++) {
			if (GUI.Button(new Rect ((Screen.width - BUTTON_WIDTH)*1f/3f, Screen.height * (5+i)/16, BUTTON_WIDTH, guiSkin.button.fontSize), "Level "+System.Convert.ToString(i))) {
				Level_setup.currentLevel = i;
				Application.LoadLevel("leveleditor");
			}
		}
		for (int i = 9; i <= 16; i++) {
			if (GUI.Button(new Rect ((Screen.width - BUTTON_WIDTH)*2f/3f, Screen.height * (i-3)/16, BUTTON_WIDTH, guiSkin.button.fontSize), "Level "+System.Convert.ToString(i))) {
				Level_setup.currentLevel = i;
				Application.LoadLevel("leveleditor");
			}
		}
	}
}
