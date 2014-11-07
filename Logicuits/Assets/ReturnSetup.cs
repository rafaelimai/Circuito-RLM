using UnityEngine;
using System.Collections;

public class ReturnSetup : MonoBehaviour {
  
	public int ScreenToLabelFontSizeRatio;
	public int ScreenToButtonFontSizeRatio;
	public float ReturnButtonX;
	public float ReturnButtonY;
	public GUISkin guiSkin;	
	float textSize;

 
	// Use this for initialization
	void Start () {

		ScreenToLabelFontSizeRatio = 4;
		ScreenToButtonFontSizeRatio = 16;
		ReturnButtonX = 10.0f / 16.0f;
		ReturnButtonY = 15.0f / 16.0f;
	
	
	}

	void OnGUI() {

		GUI.skin = guiSkin; 
		textSize = guiSkin.button.CalcSize(new GUIContent("Return")).x;
		if (GUI.Button(new Rect ((Screen.width - 2*textSize)/2, Screen.height * ReturnButtonY, 2*textSize, guiSkin.button.fontSize), "Return")) {
			Application.LoadLevel("menu");
		}


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
