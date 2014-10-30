using UnityEngine;
using System.Collections;

public class LogicGate : MonoBehaviour {

	bool drag;
	public string type;

	Camera mainCam;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.Find ("Main Camera").camera;
	}
	
	// Update is called once per frame
	void Update () {
		if (drag) {
			transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
			if (Input.GetMouseButtonUp(0)) {
				drag = false;
			}
		}
	}

	void OnMouseDown () {
		if (!Level_setup.verify && !Level_setup.itterationComplete) {
			drag = true;
		}
	}
}
