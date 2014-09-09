using UnityEngine;
using System.Collections;

public class Level_menu : MonoBehaviour {

	public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.button.fontSize = Screen.height/16;

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*12/16, Screen.width*1/8, guiSkin.button.fontSize), "Help")) {
			
		}

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*13/16, Screen.width*1/8, guiSkin.button.fontSize), "Undo")) {
			
		}

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*14/16, Screen.width*1/8, guiSkin.button.fontSize), "Main Menu")) {
			
		}

	}
}
