using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GUISkin guiSkin;
	float textSize;
	Vector3 mousePos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Input.mousePosition;
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.label.fontSize = Screen.height*1/16;
		guiSkin.textArea.fontSize = Screen.height*1/16;
		textSize = guiSkin.label.CalcSize(new GUIContent("Hover over any element for a brief explanation!")).x;
		GUI.Label(new Rect((Screen.width - textSize)*1/2,0,Screen.width,Screen.height*1/2), "Hover over any element for a brief explanation!");

		if (mousePos.x < Screen.width*3/16 && mousePos.y < Screen.height*5/16) {
			GUI.TextArea(new Rect(mousePos.x, -mousePos.y+Screen.height*5/8, Screen.width*4/8, Screen.height*3/8),
			             "These are the GUI buttons.\n\n" +
			             "Task: Show/Hide Specification tables.\n" +
			             "Check: End circuit construction and simulate.\n" +
			             "Undo: Restart circuit from scratch.\n" +
			             "Main Menu: Returns to Main Menu.");
		}

		else if (mousePos.x < Screen.width*3/16 && mousePos.y > Screen.height*1/2) {
			GUI.TextArea(new Rect(mousePos.x, -mousePos.y+Screen.height, Screen.width*4/8, Screen.height*3/8),
			             "This is the Toolbox.\n\n" +
			             "It displays the type and quantity of Logic Gates at your disposal.\n" +
			             "Click and drag a tool onto the Playfield to use it.\n" +
			             "Once placed, click one of its inputs or outputs to draw wires and connect it to other components.");
		}

		else if (mousePos.x > Screen.width*3/16 && mousePos.x < Screen.width*5/16 && mousePos.y > Screen.height*1/4 && mousePos.y < Screen.height*3/4) {
			GUI.TextArea(new Rect(mousePos.x, -mousePos.y+Screen.height, Screen.width*4/8, Screen.height*3/8),
			             "These yellow arrows are your Input.\n\n" +
			             "At each verification step, they will automatically take on a logic value of 1 or 0, according to the specification.");
		}

		else if (mousePos.x > Screen.width*14/16 && mousePos.y > Screen.height*3/8 && mousePos.y < Screen.height*5/8) {
			GUI.TextArea(new Rect(mousePos.x-Screen.width*1/2, -mousePos.y+Screen.height, Screen.width*4/8, Screen.height*3/8),
			             "This yellow arrow is your Output.\n\n" +
			             "Your objective is to carry a logic value of 1 or 0 to it at each verification step, according to the specification.");
		}

		else if (mousePos.x > Screen.width*5/8 && mousePos.x < Screen.width*6/8 && mousePos.y < Screen.height*1/4) {
			GUI.TextArea(new Rect(mousePos.x-Screen.width*1/2, -mousePos.y+Screen.height*5/8, Screen.width*4/8, Screen.height*3/8),
			             "This is the Input table, part of the Specification.\n\n" +
			             "It displays, on each line, the values to be taken on by the inputs.");
		}
		else if (mousePos.x > Screen.width*6/8 && mousePos.x < Screen.width*7/8 && mousePos.y < Screen.height*1/4) {
			GUI.TextArea(new Rect(mousePos.x-Screen.width*1/2, -mousePos.y+Screen.height*5/8, Screen.width*4/8, Screen.height*3/8),
			             "This is the Expected table, part of the Specification.\n\n" +
			             "It displays, on each line, the logic value you should take to the output at each verification step.");
		}
		else if (mousePos.x > Screen.width*7/8 && mousePos.y < Screen.height*1/4) {
			GUI.TextArea(new Rect(mousePos.x-Screen.width*1/2, -mousePos.y+Screen.height*5/8, Screen.width*4/8, Screen.height*3/8),
			             "This is the Output table.\n\n" +
			             "It displays, on each line, the logic value you have actually brought to the output. Your objective is to make this exactly the same as the Expected table.\n" +
			             "Whenever there is a match, a tick will appear. If there is a problem, a cross will instead.");
		}
	}
}
