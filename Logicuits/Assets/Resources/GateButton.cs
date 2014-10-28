using UnityEngine;
using System.Collections;

public class GateButton : MonoBehaviour {

	public Camera mainCam;
	public GUISkin guiSkin;
	
	public Sprite ANDSprite;
	GameObject ANDGate;
	Sprite ORSprite;
	GameObject ORGate;
	Sprite NOTSprite;
	GameObject NOTGate;
	Sprite XORSprite;
	GameObject XORGate;
	GameObject GateManager;
	GameObject Gate;
	GameObject GateOnMouse;


	public string type;
	public int qtty;
	public bool start = false;
	

	// Use this for initialization
	void Start () {

		// Load Sprites, Prefabs, GO's
		ANDGate = Resources.Load("Prefabs/ANDGate") as GameObject;
		ORGate = Resources.Load("Prefabs/ORGate") as GameObject;
		NOTGate = Resources.Load("Prefabs/NOTGate") as GameObject;
		XORGate = Resources.Load("Prefabs/XORGate") as GameObject;
		ANDSprite = Resources.Load("Images/AND", typeof(Sprite)) as Sprite;
		ORSprite = Resources.Load("Images/OR", typeof(Sprite)) as Sprite;
		NOTSprite = Resources.Load("Images/NOT", typeof(Sprite)) as Sprite;
		XORSprite = Resources.Load("Images/XOR", typeof(Sprite)) as Sprite;
		GateManager = GameObject.Find("Gate Manager");
		mainCam = GameObject.Find("Main Camera").camera;


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
		if (type == "XOR") {
			GetComponent<SpriteRenderer>().sprite = XORSprite;
			Gate = XORGate;
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
			Level_setup.handCursor = true;


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
			GateOnMouse.transform.parent = GateManager.transform;
			qtty --;
			start = true;
		}

	}

	void OnMouseOver() {
		Level_setup.handCursor = true;
	}

	void OnGUI () {
		GUI.skin = guiSkin;
		guiSkin.label.fontSize = Screen.height/12;

		if (!DialogueManager.isOn) {
			GUI.Label (new Rect (mainCam.WorldToScreenPoint(transform.position).x+Screen.width/16, mainCam.WorldToScreenPoint(-transform.position).y-Screen.height/20, guiSkin.label.fontSize*10, guiSkin.label.fontSize), "x " + qtty.ToString());
		}
	}
}
