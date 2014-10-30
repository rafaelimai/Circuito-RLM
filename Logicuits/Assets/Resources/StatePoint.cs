using UnityEngine;
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
	public Object WIRE;
	GameObject wire;
	public GameObject statePoint;
	public Object INPUT;
	public GameObject GateManager;
	public GameObject Circuit;
	public GameObject Spark;
	GameObject spark;

	public string type;
	public bool isAssigned;
	public string statelist;
	public int state;
	public List<GameObject> connections = new List<GameObject>();

	Vector3 mousePos;
	
	bool start;
	bool valid;
	bool done;
	public bool alreadyPropagated = false;

	
	void Start () {
		/*
		 **************************************************
		 * INICIALIZA VARIAVEIS
		 **************************************************
		 */
		WIRE = Resources.Load("Prefabs/Wire");
		Spark = Resources.Load("Prefabs/Spark") as GameObject;
		INPUT = Resources.Load ("Prefabs/Input");
		mainCam = GameObject.Find("Main Camera").camera;
		GateManager = GameObject.Find("Gate Manager");
		Circuit = GameObject.Find("Gate Manager/Circuit");
	}
	
	// Update is called once per frame
	void Update () {



		// VERIFICATION
		if (Level_setup.verify) {
			// C-INPUTS: at the beginning of iteration, take up next value on list and
			//           propagate it through connections
			if (type == "C-INPUT" && state == 2) {
				state = System.Convert.ToInt32(statelist[Level_setup.iteration].ToString());
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
				if (done && !alreadyPropagated) {
					alreadyPropagated = true;
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
						state = 0;
						foreach (Transform statePoint in transform.parent) {
							if (statePoint.gameObject.GetComponent<StatePoint>().type == "INPUT") {
								state = 1-statePoint.gameObject.GetComponent<StatePoint>().state;
							}
						}
					}
					if (transform.parent.GetComponent<LogicGate>().type == "XOR") {
						state = 0;
						foreach (Transform statePoint in transform.parent) {
							if (statePoint.gameObject.GetComponent<StatePoint>().type == "INPUT") {
								state -= statePoint.gameObject.GetComponent<StatePoint>().state;
								state = System.Math.Abs(state);
							}
						}
					}
					PropagateState(this.gameObject);
					done = false;
				}
			}

			// C-OUTPUTS: If all have acquired states, take answer and move on 
			//            to next iteration. If maximum iteration is reached, compare
			//            results, pass / reject solution and end verification
			//            THIS SHOULD BE HANDLED BY THE LEVEL SETUP

		}

	}

	void OnMouseOver () {

	}

	public void OnMouseDown () {

		// Start drawing if user clicks valid area
		wire = Instantiate(WIRE) as GameObject;
		wire.GetComponent<Wire>().isDrawing = true;
		wire.transform.parent = transform;
		wire.GetComponent<Wire>().startPoint = gameObject;
	}


	public static void PropagateAssignment (GameObject SP) {
		// Propagates assignment state of current StatePoint to the ones connected to it
		foreach (GameObject statePoint in SP.GetComponent<StatePoint>().connections) {
			if (SP.GetComponent<StatePoint>().isAssigned != statePoint.GetComponent<StatePoint>().isAssigned) {
				SP.GetComponent<StatePoint>().isAssigned = true;
				statePoint.GetComponent<StatePoint>().isAssigned = true;
				PropagateAssignment (statePoint);
			}
		}
	}

	public void PropagateState (GameObject SP) {
		// Propagates state of current StatePoint to the ones connected to it
		foreach (GameObject statePoint in SP.GetComponent<StatePoint>().connections) {
			if (statePoint.GetComponent<StatePoint>().state == 2) {
				spark = Instantiate(Spark) as GameObject;
				spark.transform.position = SP.transform.position;
				spark.GetComponent<Spark>().startPoint = SP;
				spark.GetComponent<Spark>().endPoint = statePoint;
				spark.GetComponent<Spark>().state = SP.GetComponent<StatePoint>().state;

			}
		}
	}
}
