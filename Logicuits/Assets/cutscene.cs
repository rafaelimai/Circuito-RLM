using UnityEngine;
using System.Collections;

public class cutscene : MonoBehaviour {

	public static int cutsceneNumber;
	public GameObject levelBackground;

	// Use this for initialization
	void Start () {

		levelBackground = GameObject.Find ("Level Background");
		if (cutsceneNumber == 1) {
			levelBackground.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
