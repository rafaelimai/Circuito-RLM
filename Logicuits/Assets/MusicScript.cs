using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {


	AudioSource musicSource;
	AudioSource sfxSource;
	public AudioClip music;
	public AudioClip[] sfx;


		

	// Use this for initialization
	void Start () {

		musicSource = gameObject.AddComponent ("AudioSource") as AudioSource;
		musicSource.clip = music;
		musicSource.loop = true;
		musicSource.Play ();
		sfxSource = gameObject.AddComponent ("AudioSource") as AudioSource;


	}



	
	// Update is called once per frame
	void Update () {
		musicSource.volume = Menu_setup.musicSlider/100;
		sfxSource.volume = Menu_setup.sfxSlider/100;


	}
}
