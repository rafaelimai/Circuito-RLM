using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level_setup : MonoBehaviour {

	public GUISkin guiSkin;
	public Texture2D pointer;
	public Texture2D hand;
	public GameObject toolbox;
	public GameObject gateManager;
	public GameObject circuit;

	public static string currentLevel;
	public static bool handCursor = false;
	public static bool verify = false;
	public static bool finish = false;
	public static List<List<int>> answer;
	public List<int> aux;
	public static string answerString;
	public static bool zueira = false;
	public static int iteration;
	int counter;



	// Use this for initialization
	void Start () {
		// Reset variables
		verify = false;
		finish = false;
		answer = new List<List<int>>();
		aux = new List<int>();
		answerString = "";
		iteration = 0;

	}
	
	// Update is called once per frame
	void Update () {
		//Set custom cursor
		if (handCursor){
			Cursor.SetCursor(hand, new Vector2 (11,0), CursorMode.Auto);
		}
		else {
			Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
		}
		handCursor = false;

		// VERIFICATION
		if (verify) {

			// Check if iteration is complete
			bool done = true;
			foreach (Transform statePoint in circuit.transform) {
				if (statePoint.gameObject.GetComponent<StatePoint>().type == "C-OUTPUT" && statePoint.gameObject.GetComponent<StatePoint>().state == 2) {
					done = false;
				}
			}

			// If so, take results
			if (done) {
				foreach (Transform statePoint in circuit.transform) {
					if (statePoint.GetComponent<StatePoint>().type == "C-OUTPUT") {
						aux.Add (statePoint.GetComponent<StatePoint>().state);
					}
				}

				Level_setup.answer.Add(new List<int>(aux));
				aux.Clear();

				// Move on to next iteration or end verification
				if (iteration+1 < circuit.GetComponentInChildren<StatePoint>().statelist.Capacity) {
					iteration ++;
					foreach (Transform Gate in gateManager.transform) {
						foreach (Transform statePoint in Gate) {
							statePoint.gameObject.GetComponent<StatePoint>().state = 2;
						}
					}
				}
				else {
					finish = true;
				}
			}
		}
	
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.button.fontSize = Screen.height/16;
		guiSkin.label.fontSize = Screen.height/16;
		guiSkin.textArea.fontSize = Screen.height/16;

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*12/16, Screen.width*1/8, guiSkin.button.fontSize), "Check")) {
			verify = true;
		}

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*13/16, Screen.width*1/8, guiSkin.button.fontSize), "Undo")) {
			Application.LoadLevel(Level_setup.currentLevel);
		}

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*14/16, Screen.width*1/8, guiSkin.button.fontSize), "Main Menu")) {
			Application.LoadLevel("menu");
		}

		if (finish) {
			if (verify) {
				verify = false;
				counter = 0;
				foreach(List<int> ans in answer) {
					// Add input
					foreach(Transform statePoint in circuit.transform) {
						if (statePoint.gameObject.GetComponent<StatePoint>().type == "C-INPUT"){
							answerString += statePoint.GetComponent<StatePoint>().statelist[counter].ToString();
						}
					}

					// Add space
					answerString += " ";

					// Add output
					foreach (int bit in ans) {
						answerString += bit.ToString();
					}

					// Next line
					answerString += "\n";

					counter ++;
				}
			}
			GUI.TextArea(new Rect(Screen.width*1/4,Screen.height*1/4,Screen.width/2,Screen.height/2), answerString);
		}
	}
}
