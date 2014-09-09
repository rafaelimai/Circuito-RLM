using UnityEngine;
using System.Collections;

public class Menu_setup : MonoBehaviour {

	public GUISkin guiSkin;
	float textSize;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI () {

		// Configura a GUI de acordo com o tamanho da tela
		GUI.skin = guiSkin;

		guiSkin.label.fontSize = Screen.height/4;
		guiSkin.button.fontSize = Screen.height/16;

		// CalcSize calcula o tamanho que um texto ocupa.
		textSize = guiSkin.label.CalcSize(new GUIContent("L o g i c  C i r c u i t s")).x;
		// Os argumentos de uma Label sao: um retangulo, com centro x,y e arestas a,b, e um string
		// GUI.Label(new Rect(x,y,a,b), string)
		GUI.Label(new Rect ((Screen.width - textSize)/2 , Screen.height/4 , textSize , guiSkin.label.fontSize), "L o g i c  C i r c u i t s");

		// Botoes sao como Labels, precisam de um retangulo e um string.
		// Sao colocados dentro do if, e, quando acionados, executam o laço
		textSize = guiSkin.button.CalcSize(new GUIContent("Start Game")).x;
		if (GUI.Button(new Rect ((Screen.width - textSize)/2, Screen.height * 11/16, textSize, guiSkin.button.fontSize), "Start Game")) {
			Application.LoadLevel("stageselect");
		}

		textSize = guiSkin.button.CalcSize(new GUIContent("Settings")).x;
		if (GUI.Button(new Rect ((Screen.width - textSize)/2, Screen.height * 12/16, textSize, guiSkin.button.fontSize), "Settings")) {
			Application.LoadLevel("settings");
		}

		textSize = guiSkin.button.CalcSize(new GUIContent("Credits")).x;
		if (GUI.Button(new Rect ((Screen.width - textSize)/2, Screen.height * 13/16, textSize, guiSkin.button.fontSize), "Credits")) {
			Application.LoadLevel("credits");
		}
	}
}
