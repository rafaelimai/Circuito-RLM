using UnityEngine;
using System.Collections;

public class GateInput : MonoBehaviour {

	public Camera mainCam;
	public GameObject Wire;
	public GameObject GateManager;

	Vector3 pos;
	int vertices = 0;
	bool start = false;
	bool valid = false;

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
			
			// If button is released
			if (Input.GetMouseButtonUp(0)) {

				// If EndPoint is valid, create new wire
				foreach (Transform Gate in GateManager.transform) {
					foreach (Transform StatePoint in Gate) {
						if (DetectMouseOver (StatePoint.gameObject)) {
							valid = true;
						}
					}
				}
				if (valid) {
					Wire = Instantiate(Wire) as GameObject;
				}

				// End drawing either way
				start = false;
				valid = false;
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

	bool DetectMouseOver (GameObject GO) {
		// Returns true if mouse is over GO
		CircleCollider2D collider = GO.GetComponent<CircleCollider2D>();
		bool ans;
		if ((collider.center + new Vector2 (GO.transform.position.x, GO.transform.position.y) - new Vector2 (mainCam.ScreenToWorldPoint(Input.mousePosition).x,mainCam.ScreenToWorldPoint(Input.mousePosition).y)).magnitude < 2*collider.radius) {
			ans = true;
		}
		else {
			ans = false;
		}
		return (ans);
	}
}
