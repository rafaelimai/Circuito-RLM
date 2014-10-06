using UnityEngine;
using System.Collections;

public class Mutebutton : MonoBehaviour {

	public GUISkin guiSkin;

	public Sprite onSprite;
	public Sprite offSprite;
	
	bool state = true;

	SpriteRenderer aux;


	// Use this for initialization
	void Start () {
		aux = GetComponent<SpriteRenderer>();
	}


	// Update is called once per frame
	void Update () {
		if (state) {
			aux.sprite = onSprite;
		}
		else {
			aux.sprite = offSprite;
		}
	}


	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.button.fontSize = Screen.height/16;

		
		if (GUI.Button(new Rect (0 , Screen.height * 11/12 , Screen.height/12 , Screen.height/12), "")) {
			state = !(state);
		}

	}
}
