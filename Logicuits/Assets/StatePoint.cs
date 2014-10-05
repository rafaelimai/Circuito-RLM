﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatePoint : MonoBehaviour {
	// A StatePoint is either an Input or Output region delimited by a circle collider.
	// It propagates assignment state to all adjacent statepoints
	// When verification is triggered, propagates information to verify answer
	// Four types: INPUT, OUTPUT, C-INPUT, C-OUTPUT
	// INPUTS pass their value onto OUTPUTS, according to LogicGate.type
	// C-INPUTS take on a set of to-be-propagated values
	// C-OUTPUTS, once they acquire values, associate them with C-INPUTS and sends results

	public Camera mainCam;
	public GameObject Wire;
	public GameObject GateManager;

	public string type;
	public bool isAssigned;
	public List<int> statelist = new List<int>();
	public int state;
	public List<GameObject> connections = new List<GameObject>();

	Vector3 mousePos;

	bool start;
	bool done;

	
	void Start () {
		Wire = transform.FindChild("Wire").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		// DRAWING
		if (start) {

			// Get mouse position
			mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

			// Snap mouse position when over valid StatePoint
			foreach (Transform Gate1 in GateManager.transform) {
				foreach (Transform statePoint1 in Gate1) {
					if (DetectMouseOver (statePoint1.gameObject)&& !(isAssigned && statePoint1.gameObject.GetComponent<StatePoint>().isAssigned)) {
						mousePos = statePoint1.position;
					}
				}
			}
			// Continuously draw preview of wire
			Wire.GetComponent<LineRenderer>().SetVertexCount(152);
			for (int index = 0; index <= 50; index++){
				Wire.GetComponent<LineRenderer>().SetPosition(index,new Vector3 (gameObject.transform.position.x+(((float)index/100)*(mousePos.x-gameObject.transform.position.x)),gameObject.transform.position.y,0));
			}
			for (int index = 51; index <= 100; index++) {
				Wire.GetComponent<LineRenderer>().SetPosition(index,new Vector3 ((gameObject.transform.position.x+mousePos.x)/2,gameObject.transform.position.y+((((float)index-50)/50)*(mousePos.y-gameObject.transform.position.y)),0));
			}
			for (int index = 101; index <= 150; index++) {
				Wire.GetComponent<LineRenderer>().SetPosition(index,new Vector3 ((gameObject.transform.position.x+mousePos.x)/2+((((float)index-100)/100)*(mousePos.x-gameObject.transform.position.x)),mousePos.y,0));
			}
			Wire.GetComponent<LineRenderer>().SetPosition(151,mousePos);
			
			// Start over if, while drawing, user hits invalid area
			if (Input.mousePosition.x < Screen.width*3/16 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height) {
				Wire.GetComponent<LineRenderer>().SetVertexCount(0);
				start = false;
			}
			
			// If button is released
			if (Input.GetMouseButtonUp(0)) {

				// If EndPoint is valid, set up connetion create new wire
				foreach (Transform Gate2 in GateManager.transform) {
					foreach (Transform statePoint2 in Gate2) {
						if (DetectMouseOver (statePoint2.gameObject) && !(isAssigned && statePoint2.gameObject.GetComponent<StatePoint>().isAssigned)) {
							Wire.GetComponent<LineRenderer>().SetColors(Color.red,Color.red);
							connections.Add(statePoint2.gameObject);
							statePoint2.gameObject.GetComponent<StatePoint>().connections.Add(this.gameObject);
							PropagateAssignment(this.gameObject);
							Wire = Instantiate(Wire) as GameObject;
						}
					}
				}

				// End drawing
				start = false;
				Wire.GetComponent<LineRenderer>().SetVertexCount(0);
				Wire.GetComponent<LineRenderer>().SetColors(Color.red,Color.blue);
			}
		}

		// VERIFICATION
		if (Level_setup.verify) {
			// C-INPUTS: at the beginning of iteration, take up next value on list and
			//           propagate it through connections
			if (type == "C-INPUT" && state == 2) {
				state = statelist[Level_setup.iteration];
				PropagateState(this.gameObject);
			}

			// INPUTS: DO NOTHING


			// OUTPUTS: If all INPUTS have acquired states, take up state accordingly
			//          if so, propagate state through connections
			if (type == "OUTPUT") {
				done = true;
				foreach (Transform statePoint in transform.parent) {
					if (statePoint.gameObject.GetComponent<StatePoint>().type == "INPUT" && statePoint.gameObject.GetComponent<StatePoint>().state == 2) {
						done = false;
					}
				}
				if (done) {
					if (transform.parent.GetComponent<LogicGate>().type == "AND") {
						state = 1;
						foreach (Transform statePoint in transform.parent) {
							if (statePoint.gameObject.GetComponent<StatePoint>().type == "INPUT") {
								state = state & statePoint.gameObject.GetComponent<StatePoint>().state;
							}
						}
					}

					if (transform.parent.GetComponent<LogicGate>().type == "OR") {
						state = 0;
						foreach (Transform statePoint in transform.parent) {
							if (statePoint.gameObject.GetComponent<StatePoint>().type == "INPUT") {
								state = state | statePoint.gameObject.GetComponent<StatePoint>().state;
							}
						}
					}

					if (transform.parent.GetComponent<LogicGate>().type == "NOT") {
						foreach (Transform statePoint in transform.parent) {
							if (statePoint.gameObject.GetComponent<StatePoint>().type == "INPUT") {
								state = 1-statePoint.gameObject.GetComponent<StatePoint>().state;
							}
						}
					}
					PropagateState(this.gameObject);
				}
			}

			// C-OUTPUTS: If all have acquired states, take answer and move on 
			//            to next iteration. If maximum iteration is reached, compare
			//            results, pass / reject solution and end verification
			//            THIS SHOULD BE HANDLED BY THE LEVEL SETUP

		}

	}

	void OnMouseOver () {

		// Flash continuoulsy on mouse hover, if wire is not being drawn
	}

	void OnMouseDown () {

		// Start drawing if user clicks valid area
		start = true;
	}

	bool DetectMouseOver (GameObject GO) {
		// Returns true if mouse is over GO
		CircleCollider2D collider = GO.GetComponent<CircleCollider2D>();
		bool ans;
		if ((collider.center + new Vector2 (GO.transform.position.x, GO.transform.position.y) - new Vector2 (mainCam.ScreenToWorldPoint(Input.mousePosition).x,mainCam.ScreenToWorldPoint(Input.mousePosition).y)).magnitude < collider.radius) {
			ans = true;
		}
		else {
			ans = false;
		}
		return (ans);
	}

	void PropagateAssignment (GameObject SP) {
		// Propagates assignment state of current StatePoint to the ones connected to it
		foreach (GameObject statePoint in SP.GetComponent<StatePoint>().connections) {
			if (SP.GetComponent<StatePoint>().isAssigned != statePoint.GetComponent<StatePoint>().isAssigned) {
				SP.GetComponent<StatePoint>().isAssigned = true;
				statePoint.GetComponent<StatePoint>().isAssigned = true;
				PropagateAssignment (statePoint);
			}
		}
	}

	void PropagateState (GameObject SP) {
		// Propagates state of current StatePoint to the ones connected to it
		foreach (GameObject statePoint in SP.GetComponent<StatePoint>().connections) {
			if (statePoint.GetComponent<StatePoint>().state == 2) {
				statePoint.GetComponent<StatePoint>().state = SP.GetComponent<StatePoint>().state;
				PropagateState (statePoint);
			}
		}
	}
}
