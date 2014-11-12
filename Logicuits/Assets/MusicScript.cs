using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {


	AudioSource musicSource;
	static AudioSource sfxSource;
	public AudioClip music;
	static public AudioClip[] sfx;


		

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(transform.gameObject);

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

	public static void playclic () {

		sfxSource.clip = sfx[(int)Random.Range (0, sfx.Length)];
		sfxSource.PlayOneShot (sfxSource.clip);
	}
}
