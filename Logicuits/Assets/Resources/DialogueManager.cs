using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;

public class DialogueManager : MonoBehaviour {
	// The Dialogue Manager initiates, controls, and terminates dialogue scenes

	public static string currentText;
	public static int currentLine;
	public static float currentStep;
	public static bool isOn;
	public static float timer;
	public float DIALOGUE_TIME;

	public static string dialogue;
	public static string[] lines;

	public static GameObject LeftIcon;
	public static GameObject RightIcon;
	public static GameObject dialogueBG;
	public static TextAsset dialoguetxt;
	public KeyCode pass;

	public Sprite manjubatorSprite;
	public Sprite K;

	public GUISkin guiSkin;


	// Use this for initialization
	void Start () {
		dialogueBG = GameObject.Find("Dialogue BG");
		LeftIcon = GameObject.Find("Left Icon");
		RightIcon = GameObject.Find("Right Icon");
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (isOn) {

			dialogueBG.GetComponent<SpriteRenderer>().enabled = true;

			RightIcon.transform.position += (new Vector3(5,-1,0) - RightIcon.transform.position)*5*Time.deltaTime;

			if (RightIcon.transform.position.magnitude < 6) {
				currentStep += 20*Time.deltaTime;
				if (currentStep > currentText.Length) {
					currentStep = currentText.Length;
				}

				if (Application.loadedLevel == 5 && timer >= DIALOGUE_TIME) {
					currentLine ++;
					currentStep = 0;
					timer = 0;
				}

				if (Input.GetKeyDown(pass)) {
					currentLine ++;
					currentStep = 0;
				}
				
				if (currentLine >= lines.Length || currentText == "") {
					isOn = false;
				}
			}

		}
		else {
			dialogueBG.GetComponent<SpriteRenderer>().enabled = false;
			RightIcon.transform.position += (new Vector3(15,-1,0) - RightIcon.transform.position)*5*Time.deltaTime;
		}

	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.textArea.fontSize = Screen.width/16;

		if (isOn) {
			currentText = lines[currentLine];
			GUI.TextArea (new Rect (0, Screen.height*11/16, Screen.width, Screen.height*5/16), currentText.Substring(0,Convert.ToInt32(Math.Round(currentStep))));
		}
	}
	
}
