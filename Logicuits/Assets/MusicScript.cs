using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {


	static AudioSource musicSource;
	static AudioSource sfxSource;
	public AudioClip[] sfxp;
	static public AudioClip[] sfx;
	public bool hascreated;


		

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(transform.gameObject);

		if (!hascreated) {

			musicSource = gameObject.AddComponent ("AudioSource") as AudioSource;
			sfxSource = gameObject.AddComponent ("AudioSource") as AudioSource;
			sfx = sfxp;
			hascreated = true;
		}


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

	public static void changeclip(AudioClip olar){

		if (musicSource.isPlaying) {

			musicSource.Pause();
			musicSource.Stop ();
		}

		musicSource.clip = olar;
		musicSource.loop = true;
		musicSource.Play ();
	}
}
