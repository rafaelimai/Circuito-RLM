using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level_setup : MonoBehaviour {

	// Unity Engine stuff
	public GUISkin guiSkin;
	public Texture2D pointer;
	public Texture2D hand;
	public GameObject toolbox;
	public GameObject gateManager;
	public GameObject circuit;
	public Camera mainCam;

	// Execution variables
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

	// Level-creating parameters
	public int numberOfInputs;
	public int numberOfOutputs;

	public List<int> inputStateList1;
	public List<int> inputStateList2;
	public List<int> inputStateList3;
	public List<int> inputStateList4;
	List<List<int>> inputStateLists = new List<List<int>>();

	public List<int> outputStateList1;
	public List<int> outputStateList2;
	public List<int> outputStateList3;
	public List<int> outputStateList4;
	List<List<int>> outputStateLists = new List<List<int>>();


	// Use this for initialization
	void Start () {
		// Reset variables
		verify = false;
		finish = false;
		answer = new List<List<int>>();
		aux = new List<int>();
		answerString = "";
		iteration = 0;

		// Create the level
		inputStateLists.Add(inputStateList1);
		inputStateLists.Add(inputStateList2);
		inputStateLists.Add(inputStateList3);
		inputStateLists.Add(inputStateList4);

		outputStateLists.Add(outputStateList1);
		outputStateLists.Add(outputStateList2);
		outputStateLists.Add(outputStateList3);
		outputStateLists.Add(outputStateList4);


		for (int index = 1; index <= numberOfInputs; index++) {
			GameObject inputCreated = Instantiate(Resources.Load("Prefabs/C-Input")) as GameObject;
			inputCreated.transform.parent = GameObject.Find ("Gate Manager/Circuit").transform;
			inputCreated.transform.position = new Vector3(-5f, mainCam.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y*(1f-2*(float)index/(numberOfInputs+1)), 0);
			inputCreated.GetComponent<StatePoint>().statelist = inputStateLists[index-1];
		}

		for (int index = 1; index <= numberOfOutputs; index++) {
			GameObject outputCreated = Instantiate(Resources.Load("Prefabs/C-Output")) as GameObject;
			outputCreated.transform.parent = GameObject.Find ("Gate Manager/Circuit").transform;
			outputCreated.transform.position = new Vector3(8f, mainCam.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y*(1f-2*(float)index/(numberOfInputs+1)), 0);
			outputCreated.GetComponent<StatePoint>().statelist = outputStateLists[index-1];
		}


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
			}
		}
	
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.button.fontSize = Screen.height/16;
		guiSkin.label.fontSize = Screen.height/16;
		guiSkin.textArea.fontSize = Screen.height/16;

		if (!verify) {
			if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*12/16, Screen.width*1/8, guiSkin.button.fontSize), "Check")) {
				answerString = "";
				verify = true;
			}
		}
		else if (iteration+1 < circuit.GetComponentInChildren<StatePoint>().statelist.Capacity) {
			if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*12/16, Screen.width*1/8, guiSkin.button.fontSize), "Next")) {
				// Move on to next iteration or end verification
				if (iteration+1 < circuit.GetComponentInChildren<StatePoint>().statelist.Capacity) {
					iteration ++;
					foreach(Object spark in GameObject.FindGameObjectsWithTag("Spark")) {
						Destroy(spark);
					}
					foreach (Transform Gate in gateManager.transform) {
						foreach (Transform statePoint in Gate) {
							statePoint.gameObject.GetComponent<StatePoint>().state = 2;
							statePoint.gameObject.GetComponent<StatePoint>().alreadyPropagated = false;
						}
					}
				}
			}
		}
		else {
			finish = true;
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
				for (int i = 0; i < answer.Count; i++) {
					// Add input
					foreach(Transform statePoint in circuit.transform) {
						if (statePoint.gameObject.GetComponent<StatePoint>().type == "C-INPUT"){
							answerString += statePoint.GetComponent<StatePoint>().statelist[counter].ToString();
						}
					}

					// Add space
					answerString += " ";
					// Add output
					foreach (int bit in answer[i]) {
						answerString += bit.ToString();
					}

					// Next line
					answerString += "\n";

					counter ++;

				}
			}
			finish = false;
		}
		GUI.TextArea(new Rect(Screen.width*3f/4f,Screen.height*3f/4f,Screen.width/4f,Screen.height/4f), answerString);
	}
}
