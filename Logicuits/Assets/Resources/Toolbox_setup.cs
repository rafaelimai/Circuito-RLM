using UnityEngine;
using System.Collections;

public class Toolbox_setup : MonoBehaviour {

	public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		GUI.skin = guiSkin;
		guiSkin.textArea.fontSize = Screen.height/8;

		//GUI.TextArea(new Rect(0,0,Screen.width*3/16,Screen.height*1/2), "Toolbox");
	}
}
