﻿using UnityEngine;
using System.Collections;

public class Menu_setup : MonoBehaviour {

	public AudioClip menuMusic;

	GameObject blackout;
	GameObject bubuttons;
	//GameObject barulhinhator;

	public Texture mute;
	public Texture unmute;
	Texture muteTexture;
	public int ScreenToLabelFontSizeRatio;
	public int ScreenToButtonFontSizeRatio;
	public int TitleTextHeight;
	public float StartTextHeight;
	public float TutorialTextHeight;
	public float SettingsTextHeight;
	public float CreditsTextHeight;
	public float MuteButtonHeight;
	Rect WindowRect;
	public int SCALE;
	public static float sfxSlider = 50;
	public static float musicSlider = 50;
	public int sliderSize;
	Vector3 GUIoffset;
	
	public GUISkin guiSkin;
	Camera mainCam;
	GameObject stageSelect;
	GameObject elevator;
	float textSize;
	bool settingsWindowOn;
	bool goingToStageSelect;
	bool toggleMute;
	float musicAux;
	float sfxAux;
	float timer;
	public static int levelUnlocked;


	
	// Use this for initialization
	void Start () {

		MusicScript.changeclip (menuMusic);


		if (PlayerPrefs.GetInt("levelUnlocked") == 0) {
			levelUnlocked = 1;
			PlayerPrefs.SetInt("levelUnlocked", 1);
		}
		else {
			levelUnlocked = PlayerPrefs.GetInt("levelUnlocked");
		}

		blackout = GameObject.Find("Blackout");
		bubuttons = GameObject.Find("Bubuttons");
		blackout.GetComponent<SpriteRenderer>().enabled = true;
		mainCam = GameObject.Find ("Main Camera").camera;
		stageSelect = GameObject.Find("Stage Select");
		elevator = GameObject.Find("Elevator");

		ScreenToLabelFontSizeRatio = 4;
		ScreenToButtonFontSizeRatio = 16;
		TitleTextHeight = 4;
		TutorialTextHeight = 10.0f / 16.0f;
		StartTextHeight = 11.0f/16.0f;
		SettingsTextHeight = 12.0f / 16.0f;
		CreditsTextHeight = 13.0f / 16.0f;
		settingsWindowOn = false;
		goingToStageSelect = false;

		WindowRect = new Rect (Screen.width/5, Screen.height/5, Screen.width/2, Screen.height/2);
		muteTexture = mute;

		timer = 0;

	}
	
	// Update is called once per frame
	void Update () {

		// Chat Code: Unlock all levels
		if (Input.GetKey("r") && Input.GetKey("l") && Input.GetKey("m")) {
			Menu_setup.levelUnlocked = 16;
			PlayerPrefs.SetInt("levelUnlocked", Menu_setup.levelUnlocked);
			PlayerPrefs.Save();
		}
		if (Input.GetKey("p") && Input.GetKey("e") && Input.GetKey("a")) {
			Menu_setup.levelUnlocked = 1;
			PlayerPrefs.SetInt("levelUnlocked", Menu_setup.levelUnlocked);
			PlayerPrefs.Save();
		}


		// Animation
		if (goingToStageSelect) {
			timer += Time.deltaTime;
		}

		// Fade in
		if (Time.timeSinceLevelLoad < 1) {
			blackout.GetComponent<SpriteRenderer>().color = new Color(0,0,0,1-Time.timeSinceLevelLoad);
		}
		else {
			blackout.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
		}

		// Camera movement in case of button press
		GUIoffset = 70f*mainCam.transform.position;
		if (goingToStageSelect) {
			if (mainCam.transform.position.x + 5*Time.deltaTime < 18f) {
				mainCam.transform.position += new Vector3(5,0.5f*(float)System.Math.Sin(10*Time.timeSinceLevelLoad),0)*Time.deltaTime;
			}
			else if (stageSelect.transform.localScale.x < 7) {
				mainCam.transform.position += new Vector3(0f,2f,0f)*Time.deltaTime;
				stageSelect.transform.localScale += new Vector3(2f,2f,0f)*Time.deltaTime;
				elevator.GetComponent<Animator>().SetTrigger("open");
			}
			else if (timer < 9.7) {
				bubuttons.GetComponent<SpriteRenderer>().enabled = true;
			}
		}
	}
	
	void OnGUI () {
		
		// Configura a GUI de acordo com o tamanho da tela
		GUI.skin = guiSkin;
		
		guiSkin.label.fontSize = Screen.height/ScreenToLabelFontSizeRatio;
		guiSkin.button.fontSize = Screen.height/ScreenToButtonFontSizeRatio;
		
		// CalcSize calcula o tamanho que um texto ocupa.
		textSize = guiSkin.label.CalcSize(new GUIContent("D I G I T V S")).x;
		// Os argumentos de uma Label sao: um retangulo, com centro x,y e arestas a,b, e um string
		// GUI.Label(new Rect(x,y,a,b), string)
		GUI.Label(new Rect ((Screen.width - textSize)/2 - GUIoffset.x, Screen.height/TitleTextHeight + GUIoffset.y, textSize, guiSkin.label.fontSize), "D I G I T V S");
		
		// Botoes sao como Labels, precisam de um retangulo e um string.
		// Sao colocados dentro do if, e, quando acionados, executam o laço
		
		textSize = guiSkin.button.CalcSize(new GUIContent("Tutorial")).x;
		if (GUI.Button(new Rect ((Screen.width - 2*textSize)/2 - GUIoffset.x, Screen.height * TutorialTextHeight + GUIoffset.y, 2*textSize, guiSkin.button.fontSize), "Tutorial")) {
			//barulhinhator.GetComponent<MusicScript>().playclic();
			MusicScript.playclic ();
			Application.LoadLevel("tutorial");
		}

		textSize = guiSkin.button.CalcSize(new GUIContent("Start Game")).x;
		if (GUI.Button(new Rect ((Screen.width - 2*textSize)/2 - GUIoffset.x, Screen.height * StartTextHeight + GUIoffset.y, 2*textSize, guiSkin.button.fontSize), "Start Game")) {
			MusicScript.playclic ();
			goingToStageSelect = true;
		}
		
		textSize = guiSkin.button.CalcSize(new GUIContent("Settings")).x;
		if (GUI.Button(new Rect ((Screen.width - 2*textSize)/2 - GUIoffset.x, Screen.height * SettingsTextHeight + GUIoffset.y, 2*textSize, guiSkin.button.fontSize), "Settings")) {
			settingsWindowOn = !settingsWindowOn;
			MusicScript.playclic ();

		}

		if (settingsWindowOn) {
			GUI.Window (0, WindowRect, SettingsWindowMaker, "Settings");

		}
		
		textSize = guiSkin.button.CalcSize(new GUIContent("Credits")).x;
		if (GUI.Button(new Rect ((Screen.width - 2*textSize)/2 - GUIoffset.x, Screen.height * CreditsTextHeight + GUIoffset.y, 2*textSize, guiSkin.button.fontSize), "Credits")) {
			MusicScript.playclic ();
			Application.LoadLevel("credits");
		}


		if (GUI.Button(new Rect ((Screen.width - 2*muteTexture.width)/2 - GUIoffset.x, Screen.height * MuteButtonHeight + GUIoffset.y, 2*muteTexture.width, guiSkin.button.fontSize), muteTexture) ) {
			if (!(toggleMute)) {

				musicAux = musicSlider;
				sfxAux = sfxSlider;
				musicSlider = 0;
				sfxSlider = 0;
				muteTexture = unmute;
			
			}

			else{

				sfxSlider = sfxAux;
				musicSlider = musicAux;
				muteTexture = mute;


			}
			toggleMute = !toggleMute;
		}

		if (timer > 9.7) {
			bubuttons.GetComponent<SpriteRenderer>().enabled = false;
			guiSkin.button.fontSize = Screen.height/16;
			float BUTTON_WIDTH = Screen.width/8;
			for (int i = 1; i <= 8; i++) {
				if (i > levelUnlocked) {
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect ((Screen.width - BUTTON_WIDTH)*21f/32f, Screen.height * (4+i)/16, BUTTON_WIDTH, guiSkin.button.fontSize), "Level "+System.Convert.ToString(i))) {
					Level_setup.currentLevel = i;
					Application.LoadLevel("leveleditor");
				}
				GUI.enabled = true;
			}
			for (int i = 9; i <= 16; i++) {
				if (i > levelUnlocked) {
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect ((Screen.width - BUTTON_WIDTH)*27f/32f, Screen.height * (i-4)/16, BUTTON_WIDTH, guiSkin.button.fontSize), "Level "+System.Convert.ToString(i))) {
					Level_setup.currentLevel = i;
					Application.LoadLevel("leveleditor");
				}
				GUI.enabled = true;
			}
		}
	}

	private void SettingsWindowMaker (int id) {

		guiSkin.label.fontSize = (int)WindowRect.height/(SCALE);
		guiSkin.button.fontSize = (int)WindowRect.height/(2*SCALE);
		
		// CalcSize calcula o tamanho que um texto ocupa.
		textSize = guiSkin.label.CalcSize(new GUIContent("Settings")).x;
		// Os argumentos de uma etiqueta (Label) sao: um retangulo, com centro x,y e arestas a,b, e um string
		// GUI.Label(new Rect(x,y,a,b), string)
		GUI.Label(new Rect ((int)(WindowRect.width - textSize)/2 , (int)WindowRect.height/1.5f*SCALE , textSize , guiSkin.label.fontSize), "Settings");
		
		// Etiqueta do slider do volume das musicas
		guiSkin.label.fontSize = (int)WindowRect.height/(2*SCALE);
		textSize = guiSkin.label.CalcSize (new GUIContent ("Music Volume")).x;
		GUI.Label (new Rect ((int)(WindowRect.width - textSize) / 2, 2.5f * (int)WindowRect.height/SCALE - guiSkin.label.fontSize, textSize, guiSkin.label.fontSize), "Music Volume");
		
		
		// Etiqueta do slider do volume dos SFX
		guiSkin.label.fontSize = (int)WindowRect.height/(2*SCALE);
		textSize = guiSkin.label.CalcSize (new GUIContent ("SFX Volume")).x;
		GUI.Label (new Rect ((int)(WindowRect.width - textSize) / 2, 2f*(int)WindowRect.height/SCALE - guiSkin.label.fontSize, textSize, guiSkin.label.fontSize), "SFX Volume");
		
		
		// Slider do volume da musica 
		musicSlider = GUI.HorizontalSlider (new Rect (((int)WindowRect.width - sliderSize) / 2, 2.5f * (int)WindowRect.height / SCALE, sliderSize, sliderSize / 10), musicSlider, 0, 100);
		
		
		// Slider do volume dos SFX
		sliderSize = (int)WindowRect.width / 4;
		sfxSlider = GUI.HorizontalSlider(new Rect (((int)WindowRect.width - sliderSize)/2, 2f*(int)WindowRect.height/SCALE, sliderSize, sliderSize/10), sfxSlider, 0, 100); 

		textSize = guiSkin.button.CalcSize(new GUIContent("Back")).x;
		if (GUI.Button(new Rect ((WindowRect.width - 2*textSize)/2 - GUIoffset.x, WindowRect.height * SettingsTextHeight + GUIoffset.y, 2*textSize, guiSkin.button.fontSize), "Back")) {
			settingsWindowOn = !settingsWindowOn;
			MusicScript.playclic ();

		}

	}
}


