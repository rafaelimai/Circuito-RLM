using UnityEngine;
using System.Collections;

public class Level_setup : MonoBehaviour {

	public GUISkin guiSkin;
	public Texture2D pointer;
	public Texture2D hand;
	public GameObject toolbox;

	public static bool handCursor = false;
	public static bool verify = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Set custom cursor
		if (handCursor){
			Cursor.SetCursor(hand, new Vector2 (11,0), CursorMode.Auto);
		}
		else {
			Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
		}
		handCursor = false;
	
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.button.fontSize = Screen.height/16;

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*12/16, Screen.width*1/8, guiSkin.button.fontSize), "Help")) {
			
		}

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*13/16, Screen.width*1/8, guiSkin.button.fontSize), "Undo")) {
			
		}

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*14/16, Screen.width*1/8, guiSkin.button.fontSize), "Main Menu")) {
			Application.LoadLevel("menu");
		}

	}
}
