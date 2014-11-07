using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class cutscene : MonoBehaviour {

	public static int cutsceneNumber = 1;
	int cutsceneStep = 1;
	float timer;
	public GameObject levelBackground;
	GameObject blackout;
	Camera mainCam;
	public Sprite manjubator;
	public Sprite K;
	public Sprite none;
	public KeyCode pass;


	// Use this for initialization
	void Start () {

		DialogueManager.dialoguetxt = Resources.Load("Cutscenes") as TextAsset;
		levelBackground = GameObject.Find ("Level Background");
		blackout = GameObject.Find("Blackout");
		mainCam = GameObject.Find("Main Camera").camera;

		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;


		if (cutsceneNumber == 1) {

			if (Time.timeSinceLevelLoad % 4 > 2) {
				mainCam.transform.position = new Vector3(0.1f*(float)Math.Sin(20*Time.timeSinceLevelLoad-100),0,-10);
			}
			
			if (!DialogueManager.isOn && cutsceneStep == 1) {
				foreach (Transform child in levelBackground.transform) {
					child.GetComponent<SpriteRenderer>().enabled = true;
				}
				PrepareDialogue(manjubator);
			}

			if (!DialogueManager.isOn && cutsceneStep == 2 && timer > 1) {
				PrepareDialogue(none);
			}

			if (!DialogueManager.isOn && cutsceneStep == 3 && timer > 1) {
				PrepareDialogue(manjubator);
			}

			if (!DialogueManager.isOn && cutsceneStep == 4 && timer > 1) {
				blackout.GetComponent<SpriteRenderer>().enabled = true;
				PrepareDialogue(none);
			}
		}
	}

	void OnGUI() {
		if (DialogueManager.isOn && Input.GetKeyDown(pass)) {
			timer = 0;
		}
	}

	void PrepareDialogue(Sprite sprite) {
		DialogueManager.dialogue = Regex.Split(DialogueManager.dialoguetxt.text,"\r\n\r\n")[cutsceneStep];
		DialogueManager.lines = Regex.Split(DialogueManager.dialogue,"\r\n");
		DialogueManager.currentLine = 0;
		DialogueManager.currentStep = 0;
		DialogueManager.currentText = DialogueManager.lines[0];
		DialogueManager.RightIcon.GetComponent<SpriteRenderer>().sprite = sprite;
		DialogueManager.isOn = true;
		cutsceneStep ++;
	}
}
