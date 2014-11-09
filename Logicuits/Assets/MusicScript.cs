using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Menu_setup.musicSlider);
		audio.volume = Menu_setup.musicSlider/100;

	}
}
