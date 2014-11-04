using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;

public class DialogueManager : MonoBehaviour {
	// The Dialogue Manager initiates, controls, and terminates dialogue scenes

	string currentText;
	public static int currentLine;
	public static float currentStep;
	public static bool isOn;
	bool hasReturned;

	string dialogue;
	string[] lines;

	public GameObject LeftIcon;
	public GameObject RightIcon;
	public GameObject dialogueBG;
	public TextAsset dialoguetxt;
	public KeyCode pass;

	public Sprite manjubatorSprite;

	public GUISkin guiSkin;


	// Use this for initialization
	void Start () {
		dialoguetxt = Resources.Load("Dialogues") as TextAsset;
		dialogue = Regex.Split(dialoguetxt.text,"\r\n\r\n")[2*Level_setup.currentLevel];
		lines = Regex.Split(dialogue,"\r\n");

		if (lines[0] != "") {
			isOn = true;
		}
		hasReturned = false;
		currentLine = 0;
		currentStep = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {

			dialogueBG.GetComponent<SpriteRenderer>().enabled = true;
			RightIcon.GetComponent<SpriteRenderer>().enabled = true;
			currentText = lines[currentLine];

			currentStep += 20*Time.deltaTime;
			if (currentStep > currentText.Length) {
				currentStep = currentText.Length;
			}

			if (Input.GetKeyDown(pass)) {
				currentLine ++;
				currentStep = 0;
			}
			
			if (currentLine >= lines.Length || currentText == "") {
				isOn = false;
			}

		}
		else {
			dialogueBG.GetComponent<SpriteRenderer>().enabled = false;
			RightIcon.GetComponent<SpriteRenderer>().enabled = false;
		}

		if (Level_setup.won && !hasReturned) {
			dialogue = Regex.Split(dialoguetxt.text,"\r\n\r\n")[2*Level_setup.currentLevel+1];
			lines = Regex.Split(dialogue,"\r\n");
			currentLine = 0;
			currentStep = 0;
			if (lines[0] != "") {
				isOn = true;
				currentText = lines[currentLine];
			}
			hasReturned = true;
		}
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.textArea.fontSize = Screen.width/16;

		if (isOn) {
			GUI.TextArea (new Rect (0, Screen.height*11/16, Screen.width, Screen.height*5/16), currentText.Substring(0,Convert.ToInt32(Math.Round(currentStep))));
		}
	}
	
}
