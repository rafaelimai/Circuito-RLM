using UnityEngine;
using System.Collections;

public class ReturnTutorialButton : MonoBehaviour {

	
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
		ReturnButtonX = 4.4f / 16.0f;
		ReturnButtonY = 14.0f / 16.0f;
		
		
	}
	
	void OnGUI() {
		
		GUI.skin = guiSkin; 
		textSize = guiSkin.button.CalcSize(new GUIContent("Return")).x;
		if (GUI.Button(new Rect (ReturnButtonX*Screen.width, Screen.height * ReturnButtonY, textSize, 1.8f*guiSkin.button.fontSize), "Off")) {
			Application.LoadLevel("menu");
		}

		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
