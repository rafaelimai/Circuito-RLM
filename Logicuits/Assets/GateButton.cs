using UnityEngine;
using System.Collections;

public class GateButton : MonoBehaviour {

	public Camera mainCam;
	public GUISkin guiSkin;

	public Sprite ANDSprite;
	public GameObject ANDGate;
	public Sprite ORSprite;
	public GameObject ORGate;
	public Sprite NOTSprite;
	public GameObject NOTGate;
	GameObject Gate;
	GameObject GateOnMouse;

	public string type;
	public int qtty;
	public bool start = false;
	bool flag = true;
	

	// Use this for initialization
	void Start () {

		// Set sprite according to type chosen
		if (type == "AND") {
			GetComponent<SpriteRenderer>().sprite = ANDSprite;
			Gate = ANDGate;
		}
		if (type == "OR") {
			GetComponent<SpriteRenderer>().sprite = ORSprite;
			Gate = ORGate;
		}
		if (type == "NOT") {
			GetComponent<SpriteRenderer>().sprite = NOTSprite;
			Gate = NOTGate;
		}
		// Add collider only after setting sprite (this is important)
		gameObject.AddComponent("PolygonCollider2D");

	}
	
	// Update is called once per frame
	void Update () {

		// If procedure has started, keep Logic Gate attached to mouse
		if (start) {
			GateOnMouse.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
			GateOnMouse.transform.position = new Vector3 (GateOnMouse.transform.position.x,GateOnMouse.transform.position.y,0);


			// If the user releases click during procedure
			if (Input.GetMouseButtonUp(0)) {

				// If position is invalid, destroy gate and restore counter
				if (Input.mousePosition.x < Screen.width*3/16 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height) {
					qtty ++;
					Destroy(GateOnMouse);
				}

				// End procedure either way
				start = false;
			}
		}
	}
	
	void OnMouseDown() {

		// If Gate Button is clicked, create Logic Gate and begin procedure 
		//(if there isn't already one in progress)
		
		if (!start && qtty > 0) {
			GateOnMouse = Instantiate(Gate) as GameObject;
			qtty --;
			start = true;
		}

	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.label.fontSize = Screen.height/12;


		GUI.Label (new Rect (mainCam.WorldToScreenPoint(transform.position).x+Screen.width/16, mainCam.WorldToScreenPoint(-transform.position).y-Screen.height/20, guiSkin.label.fontSize, guiSkin.label.fontSize), "x " + qtty.ToString());
	}
}
