using UnityEngine;
using System.Collections;

public class Drawing : MonoBehaviour {

	public Camera mainCam;
	public LineRenderer lineRenderer;
	public int vertices;
	public Vector3 pos;
	bool start = false;
	bool end = false;

	public GameObject Wire;

	// Use this for initialization
	void Start () {
		vertices = 0;
		lineRenderer.SetVertexCount(vertices);
	}
	
	// Update is called once per frame
	void Update () {
		// Start drawing procedure if click occurs in valid area
		if (!start && !end && Input.GetMouseButtonDown (0)) {
			start = true;
		}

		// If drawing has started, but not ended
		if (start && !end) {

			// Draw if mouse is still pressed and has moved enough from last point
			if (Input.GetMouseButton(0) && (new Vector3 (pos.x,pos.y,-10) - mainCam.ScreenToWorldPoint(Input.mousePosition)).magnitude > 0.05) {
				vertices ++;
				lineRenderer.SetVertexCount(vertices);
				pos = mainCam.ScreenToWorldPoint(Input.mousePosition);
				pos = new Vector3 (pos.x,pos.y,0);
				lineRenderer.SetPosition(vertices-1,pos);
			}

			// Start over if, while drawing, user hits invalid area
			if (Input.mousePosition.x < Screen.width*3/16 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height) {
				vertices = 0;
				lineRenderer.SetVertexCount(vertices);
				start = false;
			}

			// End drawing if mouse button is released (and wire is valid, to be added), and ready new wire
			if (!Input.GetMouseButton(0)) {
				end = true;
				Instantiate(Wire);
			}
		}

	}
}
