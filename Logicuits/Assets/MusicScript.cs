using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {


	AudioSource[] audioSources;
	public AudioClip[] clips;
		

	// Use this for initialization
	void Start () {

		clips = new AudioClip[2];
		audioSources = new AudioSource[2];
		for (int i = 0; i<1; i++) {
			audioSources[i] = new AudioSource;
			audioSources[i].clip = clips[i];

		}
	}


	
	// Update is called once per frame
	void Update () {

		audioSources[0].volume = Menu_setup.musicSlider/100;
		audioSources[1].volume = Menu_setup.sfxSlider/100;
	}
}
