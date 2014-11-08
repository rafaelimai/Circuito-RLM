using UnityEngine;
using System.Collections;

public class ElevatorButton : MonoBehaviour {

	public int number;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Level_setup.currentLevel = number;
		Application.LoadLevel("leveleditor");
	}
}
