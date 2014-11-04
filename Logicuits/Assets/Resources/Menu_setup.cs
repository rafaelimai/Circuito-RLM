using UnityEngine;
using System.Collections;

public class Menu_setup : MonoBehaviour {

	GameObject blackout;

	public int ScreenToLabelFontSizeRatio;
	public int ScreenToButtonFontSizeRatio;
	public int TitleTextHeight;
	public float StartTextHeight;
	public float SettingsTextHeight;
	public float CreditsTextHeight;
	public Rect WindowRect;
	public int SCALE;
	public static float sfxSlider = 75;
	public static float musicSlider = 75;
	public int sliderSize;
	
	public GUISkin guiSkin;
	float textSize;
	bool settingsWindowOn;
	
	
	// Use this for initialization
	void Start () {

		blackout = GameObject.Find("Blackout");
		blackout.GetComponent<SpriteRenderer>().enabled = true;

		ScreenToLabelFontSizeRatio = 4;
		ScreenToButtonFontSizeRatio = 16;
		TitleTextHeight = 4;
		StartTextHeight = 11.0f/16.0f;
		SettingsTextHeight = 12.0f / 16.0f;
		CreditsTextHeight = 13.0f / 16.0f;
		settingsWindowOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < 1) {
			blackout.GetComponent<SpriteRenderer>().color = new Color(0,0,0,1-Time.timeSinceLevelLoad);
		}
		else {
			blackout.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
		}
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
		if (GUI.Button(new Rect ((Screen.width - 2*textSize)/2, Screen.height * StartTextHeight, 2*textSize, guiSkin.button.fontSize), "Start Game")) {
			Application.LoadLevel("stageselect");
		}
		
		textSize = guiSkin.button.CalcSize(new GUIContent("Settings")).x;
		if (GUI.Button(new Rect ((Screen.width - 2*textSize)/2, Screen.height * SettingsTextHeight, 2*textSize, guiSkin.button.fontSize), "Settings")) {
			settingsWindowOn = !settingsWindowOn;
		}

		if (settingsWindowOn) {
			GUI.Window (0, WindowRect, SettingsWindowMaker, "SettingsWindow");
		}
		
		textSize = guiSkin.button.CalcSize(new GUIContent("Credits")).x;
		if (GUI.Button(new Rect ((Screen.width - 2*textSize)/2, Screen.height * CreditsTextHeight, 2*textSize, guiSkin.button.fontSize), "Credits")) {
			Application.LoadLevel("credits");
		}
	}

	private void SettingsWindowMaker (int id) {

		guiSkin.label.fontSize = Screen.height/(2*SCALE);
		guiSkin.button.fontSize = Screen.height/(SCALE*SCALE);
		
		// CalcSize calcula o tamanho que um texto ocupa.
		textSize = guiSkin.label.CalcSize(new GUIContent("Settings")).x;
		// Os argumentos de uma etiqueta (Label) sao: um retangulo, com centro x,y e arestas a,b, e um string
		// GUI.Label(new Rect(x,y,a,b), string)
		GUI.Label(new Rect ((Screen.width - textSize)/2 , Screen.height/(2*SCALE) , textSize , guiSkin.label.fontSize), "Settings");
		
		// Etiqueta do slider do volume das musicas
		guiSkin.label.fontSize = Screen.height/(4*SCALE);
		textSize = guiSkin.label.CalcSize (new GUIContent ("Music Volume")).x;
		GUI.Label (new Rect ((Screen.width - textSize) / 2, 2.5f * Screen.height/SCALE - guiSkin.label.fontSize, textSize, guiSkin.label.fontSize), "Music Volume");
		
		
		// Etiqueta do slider do volume dos SFX
		guiSkin.label.fontSize = Screen.height/(4*SCALE);
		textSize = guiSkin.label.CalcSize (new GUIContent ("SFX Volume")).x;
		GUI.Label (new Rect ((Screen.width - textSize) / 2, 2f*Screen.height/SCALE - guiSkin.label.fontSize, textSize, guiSkin.label.fontSize), "SFX Volume");
		
		
		// Slider do volume da musica 
		musicSlider = GUI.HorizontalSlider (new Rect ((Screen.width - sliderSize) / 2, 2.5f * Screen.height / SCALE, sliderSize, sliderSize / 32), musicSlider, 0, 100);
		
		
		// Slider do volume dos SFX
		sliderSize = Screen.width / 4;
		sfxSlider = GUI.HorizontalSlider(new Rect ((Screen.width - sliderSize)/2, 2f*Screen.height/SCALE, sliderSize, sliderSize/32), sfxSlider, 0, 100); 

	}
}


