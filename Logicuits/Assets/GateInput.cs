using UnityEngine;
using System.Collections;

public class GateInput : MonoBehaviour {

	public Camera mainCam;
	public GameObject Wire;

	Vector3 pos;
	int vertices = 0;
	bool start = false;

	// Use this for initialization
	void Start () {

		vertices = 0;
		Wire.GetComponent<LineRenderer>().SetVertexCount(vertices);
	}
	
	// Update is called once per frame
	void Update () {

		// If drawing has started
		if (start) {
			
			// Draw if mouse is still pressed and has moved enough from last point
			if ((new Vector3 (pos.x,pos.y,-10) - mainCam.ScreenToWorldPoint(Input.mousePosition)).magnitude > 0.05) {
				vertices ++;
				Wire.GetComponent<LineRenderer>().SetVertexCount(vertices);
				pos = mainCam.ScreenToWorldPoint(Input.mousePosition);
				pos = new Vector3 (pos.x,pos.y,0);
				Wire.GetComponent<LineRenderer>().SetPosition(vertices-1,pos);
			}
			
			// Start over if, while drawing, user hits invalid area
			if (Input.mousePosition.x < Screen.width*3/16 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height) {
				vertices = 0;
				Wire.GetComponent<LineRenderer>().SetVertexCount(vertices);
				start = false;
			}
			
			// End drawing if mouse button is released , and ready new wire
			if (Input.GetMouseButtonUp(0)) {
				start = false;
				Wire = Instantiate(Wire) as GameObject;
				vertices = 0;
				Wire.GetComponent<LineRenderer>().SetVertexCount(vertices);
			}
		}
		
	}

	void OnMouseOver () {

		// Flash continuoulsy on mouse hover, if wire is not being drawn
	}

	void OnMouseDown () {

		// Start drawing if user clicks valid area
		start = true;
	}
}
