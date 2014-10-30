using UnityEngine;
using System.Collections;

public class Menu_setup : MonoBehaviour {
	
	public int ScreenToLabelFontSizeRatio;
	public int ScreenToButtonFontSizeRatio;
	public int TitleTextHeight;
	public float StartTextHeight;
	public float SettingsTextHeight;
	public float CreditsTextHeight;
	
	public GUISkin guiSkin;
	float textSize;
	
	
	// Use this for initialization
	void Start () {
		ScreenToLabelFontSizeRatio = 4;
		ScreenToButtonFontSizeRatio = 16;
		TitleTextHeight = 4;
		StartTextHeight = 11.0f/16.0f;
		SettingsTextHeight = 12.0f / 16.0f;
		CreditsTextHeight = 13.0f / 16.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		
		// Configura a GUI de acordo com o tamanho da tela
		GUI.skin = guiSkin;
		
		guiSkin.label.fontSize = Screen.height/ScreenToLabelFontSizeRatio;
		guiSkin.button.fontSize = Screen.height/ScreenToButtonFontSizeRatio;
		
		// CalcSize calcula o tamanho que um texto ocupa.
		textSize = guiSkin.label.CalcSize(new GUIContent("L o g i c  C i r c u i t s")).x;
		// Os argumentos de uma Label sao: um retangulo, com centro x,y e arestas a,b, e um string
		// GUI.Label(new Rect(x,y,a,b), string)
		GUI.Label(new Rect ((Screen.width - textSize)/2 , Screen.height/TitleTextHeight, textSize , guiSkin.label.fontSize), "L o g i c  C i r c u i t s");
		
		// Botoes sao como Labels, precisam de um retangulo e um string.
		// Sao colocados dentro do if, e, quando acionados, executam o laço
		textSize = guiSkin.button.CalcSize(new GUIContent("Start Game")).x;
		if (GUI.Button(new Rect ((Screen.width - textSize)/2, Screen.height * StartTextHeight, textSize, guiSkin.button.fontSize), "Start Game")) {
			Application.LoadLevel("stageselect");
		}
		
		textSize = guiSkin.button.CalcSize(new GUIContent("Settings")).x;
		if (GUI.Button(new Rect ((Screen.width - textSize)/2, Screen.height * SettingsTextHeight, textSize, guiSkin.button.fontSize), "Settings")) {
			Application.LoadLevel("settings");
		}
		
		textSize = guiSkin.button.CalcSize(new GUIContent("Credits")).x;
		if (GUI.Button(new Rect ((Screen.width - textSize)/2, Screen.height * CreditsTextHeight, textSize, guiSkin.button.fontSize), "Credits")) {
			Application.LoadLevel("credits");
		}
	}
}


