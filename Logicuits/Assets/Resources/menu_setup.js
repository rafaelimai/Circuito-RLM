#pragma strict

var guiSkin: GUISkin;
var textSize: float;

var startButton;
var settingsButton;
var creditsButton;


function Start () {


}

function Update () {

	
}

function OnGUI () {

	GUI.skin = guiSkin;
	
	guiSkin.label.fontSize = Screen.height/4;
	guiSkin.button.fontSize = Screen.height/16;
	
	textSize = guiSkin.label.CalcSize(GUIContent("L o g i c  C i r c u i t s")).x;
	GUI.Label(Rect ((Screen.width - textSize)/2 , Screen.height/4 , textSize , guiSkin.label.fontSize), "L o g i c  C i r c u i t s");

	textSize = guiSkin.button.CalcSize(GUIContent("Start Game")).x;
	startButton = GUI.Button(Rect ((Screen.width - textSize)/2, Screen.height * 9/16, textSize, guiSkin.button.fontSize), "Start Game");

	textSize = guiSkin.button.CalcSize(GUIContent("Settings")).x;
	settingsButton = GUI.Button(Rect ((Screen.width - textSize)/2, Screen.height * 11/16, textSize, guiSkin.button.fontSize), "Settings");

	textSize = guiSkin.button.CalcSize(GUIContent("Credits")).x;
	creditsButton = GUI.Button(Rect ((Screen.width - textSize)/2, Screen.height * 13/16, textSize, guiSkin.button.fontSize), "Credits");

	if (startButton) {
		Application.LoadLevel("stage select");
	}
	if (settingsButton) {
		Application.LoadLevel("settings");
	}
	if (creditsButton) {
		Application.LoadLevel("credits");
	}

}