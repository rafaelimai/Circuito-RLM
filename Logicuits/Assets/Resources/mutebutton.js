#pragma strict

var guiSkin: GUISkin;

var muteButton;

var onSprite: Sprite;
var offSprite: Sprite;

var state: boolean;

function Start () {

}

function Update () {

	if (state) {
		GetComponent(SpriteRenderer).sprite = offSprite;
	}
	else {
		GetComponent(SpriteRenderer).sprite = onSprite;
	}
}

function OnGUI () {

	GUI.skin = guiSkin;
	guiSkin.button.fontSize = Screen.height/16;
	
	muteButton = GUI.Button(Rect (0 , Screen.height * 11/12 , Screen.height/12 , Screen.height/12), "");

	if (muteButton) {
		state = !(state);
	}

}