using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	int w;
	int h;

	// Use this for initialization
	void Start () {
		w = Screen.width;
		h = Screen.height;

		GetComponent<GUITexture>().pixelInset = new Rect
			(w*GetComponent<GUITexture>().pixelInset.x, h*GetComponent<GUITexture>().pixelInset.y,
			 w*GetComponent<GUITexture>().pixelInset.width, h*GetComponent<GUITexture>().pixelInset.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
