using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;

public class DialogueManager : MonoBehaviour {
	// The Dialogue Manager initiates, controls, and terminates dialogue scenes

	string currentText;
	public static int currentNumber;
	public static int currentLine;
	public static float currentStep;
	public static bool isOn;

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
		dialogue = Regex.Split(dialoguetxt.text,"\r\n\r\n")[Level_setup.currentLevel];
		lines = Regex.Split(dialogue,"\r\n");

		isOn = true;
		currentNumber = 1;
		currentLine = 0;
		currentStep = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {

			dialogueBG.GetComponent<SpriteRenderer>().enabled = true;
			RightIcon.GetComponent<SpriteRenderer>().enabled = true;
			currentText = lines[currentLine];

			if (Input.GetKeyDown(pass)) {
				currentLine ++;
				currentStep = 0;
			}

			if (currentLine >= lines.Length || currentText == "") {
				isOn = false;
			}
			currentStep += 20*Time.deltaTime;
			if (currentStep > currentText.Length) {
				currentStep = currentText.Length;
			}
		}
		else {
			dialogueBG.GetComponent<SpriteRenderer>().enabled = false;
			RightIcon.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.textArea.fontSize = Screen.width/16;

		if (isOn) {
			GUI.TextArea (new Rect (0, Screen.height*3/4, Screen.width, Screen.height*1/4), currentText.Substring(0,Convert.ToInt32(Math.Round(currentStep))));
		}
	}
	
}
