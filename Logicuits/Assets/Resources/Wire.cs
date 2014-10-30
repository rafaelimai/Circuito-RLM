using UnityEngine;
using System.Collections;

public class Wire : MonoBehaviour {

	public bool isDrawing;
	bool valid;

	Vector3 mousePos;
	public GameObject startPoint;
	public GameObject endPoint;
	GameObject newStatePoint;
	GameObject Circuit;
	Object INPUT;

	Camera mainCam;

	// Use this for initialization
	void Start () {
		GetComponent<LineRenderer>().SetVertexCount(152);
		mainCam = GameObject.Find("Main Camera").camera;
		Circuit = GameObject.Find("Circuit") as GameObject;
		INPUT = Resources.Load("Prefabs/Input");
	}
	
	// Update is called once per frame
	void Update () {
		if (isDrawing) {
			// Get mouse position
			mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
			
			// Snap Mouse Position when over valid StatePoint
			foreach (GameObject statePoint in GameObject.FindGameObjectsWithTag("StatePoint")) {
				if (DetectMouseOver (statePoint)&& !(startPoint.GetComponent<StatePoint>().isAssigned && statePoint.GetComponent<StatePoint>().isAssigned)) {
					mousePos = statePoint.transform.position;
				}
			}

			// Continuously draw preview of wire
			for (int index = 0; index <= 50; index++){
				GetComponent<LineRenderer>().SetPosition(index,new Vector3 (startPoint.transform.position.x+(((float)index/150)*(mousePos.x-startPoint.transform.position.x)),startPoint.transform.position.y,0));
			}
			for (int index = 51; index <= 100; index++) {
				GetComponent<LineRenderer>().SetPosition(index,new Vector3 (startPoint.transform.position.x+(((float)index/150)*(mousePos.x-startPoint.transform.position.x)),startPoint.transform.position.y+((((float)index-50)/50)*(mousePos.y-startPoint.transform.position.y)),0));
			}
			for (int index = 101; index <= 150; index++) {
				GetComponent<LineRenderer>().SetPosition(index,new Vector3 ((startPoint.transform.position.x+mousePos.x)/2+((((float)index-50)/200)*(mousePos.x-startPoint.transform.position.x)),mousePos.y,0));
			}
			GetComponent<LineRenderer>().SetPosition(151,mousePos);
			
			// Start over if, while drawing, user hits invalid area
			if (Input.mousePosition.x < Screen.width*3/16 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height) {
				Destroy(this.gameObject);
				isDrawing = false;
			}

			// If button is released
			if (Input.GetMouseButtonUp(0)) {
				
				// If EndPoint is valid, set up connetion create new wire
				valid = false;
				foreach (GameObject statePoint in GameObject.FindGameObjectsWithTag("StatePoint")) {
					if (DetectMouseOver (statePoint) && !(startPoint.GetComponent<StatePoint>().isAssigned && statePoint.GetComponent<StatePoint>().isAssigned)) {
						GetComponent<LineRenderer>().SetColors(Color.green,Color.green);
						startPoint.GetComponent<StatePoint>().connections.Add(statePoint);
						statePoint.GetComponent<StatePoint>().connections.Add(startPoint);
						StatePoint.PropagateAssignment(statePoint);
						valid = true;
						endPoint = statePoint;
					}
				}
				
				// End drawing
				isDrawing = false;
				if (!valid) {
					Destroy(gameObject);
				}
			}
			
			// If right click
			if (Input.GetMouseButtonDown(1)) {
				GetComponent<LineRenderer>().SetColors(Color.green,Color.green);
				newStatePoint = Instantiate(INPUT) as GameObject;
				newStatePoint.transform.position = new Vector3 (mousePos.x, mousePos.y, 0);
				newStatePoint.transform.parent = Circuit.transform;
				startPoint.GetComponent<StatePoint>().connections.Add(newStatePoint);
				newStatePoint.gameObject.GetComponent<StatePoint>().connections.Add(this.gameObject);
				StatePoint.PropagateAssignment(this.gameObject);
				valid = true;
				isDrawing = false;
				newStatePoint.GetComponent<StatePoint>().OnMouseDown();
				
			}
		}

		else {
			for (int index = 0; index <= 50; index++){
				GetComponent<LineRenderer>().SetPosition(index,new Vector3 (startPoint.transform.position.x+(((float)index/150)*(endPoint.transform.position.x-startPoint.transform.position.x)),startPoint.transform.position.y,0));
			}
			for (int index = 51; index <= 100; index++) {
				GetComponent<LineRenderer>().SetPosition(index,new Vector3 (startPoint.transform.position.x+(((float)index/150)*(endPoint.transform.position.x-startPoint.transform.position.x)),startPoint.transform.position.y+((((float)index-50)/50)*(endPoint.transform.position.y-startPoint.transform.position.y)),0));
			}
			for (int index = 101; index <= 150; index++) {
				GetComponent<LineRenderer>().SetPosition(index,new Vector3 ((startPoint.transform.position.x+endPoint.transform.position.x)/2+((((float)index-50)/200)*(endPoint.transform.position.x-startPoint.transform.position.x)),endPoint.transform.position.y,0));
			}
			GetComponent<LineRenderer>().SetPosition(151,endPoint.transform.position);
		}
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
}
