using UnityEngine;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour {
	// The Dialogue Manager initiates, controls, and terminates dialogue scenes

	string currentText;
	public static int currentNumber;
	public static int currentLine;
	public static float currentStep;
	public static bool isOn = false;

	public GameObject LeftIcon;
	public GameObject RightIcon;
	public GameObject dialogueBG;
	public KeyCode pass;

	public Sprite manjutronSprite;

	public GUISkin guiSkin;


	// Use this for initialization
	void Start () {
		currentNumber = 1;
		currentLine = 1;
		currentStep = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {
			if (currentNumber == 1) {
				if (currentLine == 1) {
					dialogueBG.GetComponent<SpriteRenderer>().enabled = true;
					currentText = "Welcome, Test Subject 377.";
					LeftIcon.GetComponent<SpriteRenderer>().sprite = null;
					RightIcon.GetComponent<SpriteRenderer>().sprite = manjutronSprite;
				}
				if (currentLine == 2) {
					currentText = "I am Manjubator5000. I will aid you during your tests.";
				}
				if (currentLine == 3) {
					currentText = "The challenges ahead of you will test your thinking, speed, willpower, and ultimately, your ability to build logic circuits.";
				}
				if (currentLine == 4) {
					currentText = "Begin by connecting the input, on the left of the screen, to the output, on the right.";
				}
				if (currentLine == 5) {
					dialogueBG.GetComponent<SpriteRenderer>().enabled = false;
					LeftIcon.GetComponent<SpriteRenderer>().sprite = null;
					RightIcon.GetComponent<SpriteRenderer>().sprite = null;
					isOn = false;
				}
			}

			if (Input.GetKeyDown(pass)) {
				currentLine ++;
				currentStep = 0;
			}
			currentStep += 20*Time.deltaTime;
			if (currentStep > currentText.Length) {
				currentStep = currentText.Length;
			}
		}
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.textArea.fontSize = Screen.width/16;

		if (isOn) {
			CreateDialogue(currentText, currentNumber, currentLine, currentStep);
		}
	}

	void CreateDialogue (string text, int number, int line, float step) {
		// Creates a dialogue interface according to current paramaters
		if (number == currentNumber) {
			GUI.TextArea (new Rect (0, Screen.height*3/4, Screen.width, Screen.height*1/4), text.Substring(0,Convert.ToInt32(Math.Round(currentStep))));
		}
	}
}
