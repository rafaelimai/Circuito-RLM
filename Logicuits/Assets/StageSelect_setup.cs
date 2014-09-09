using UnityEngine;
using System.Collections;

public class StageSelect_setup : MonoBehaviour {

	public GUISkin guiSkin;
	float textSize;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		GUI.skin = guiSkin;
		guiSkin.label.fontSize = Screen.height/8;
		guiSkin.button.fontSize = Screen.height/16;

		textSize = guiSkin.label.CalcSize(new GUIContent("Stage Select")).x;
		GUI.Label(new Rect ((Screen.width - textSize)/2 , Screen.height*1/4 , textSize , guiSkin.label.fontSize), "Stage Select");

		textSize = guiSkin.button.CalcSize(new GUIContent("Level 1")).x;
		if (GUI.Button(new Rect ((Screen.width - textSize)/2, Screen.height * 12/16, textSize, guiSkin.button.fontSize), "Level 1")) {
			Application.LoadLevel("level1");
		}
	}
}
