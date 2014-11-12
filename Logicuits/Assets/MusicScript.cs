using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {


	static AudioSource musicSource;
	static AudioSource sfxSource;
	static public AudioClip music;
	public AudioClip[] sfxp;
	static public AudioClip[] sfx;


		

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(transform.gameObject);

		musicSource = gameObject.AddComponent ("AudioSource") as AudioSource;
		musicSource.clip = music;
		musicSource.loop = true;
		musicSource.Play ();
		sfxSource = gameObject.AddComponent ("AudioSource") as AudioSource;
		sfx = sfxp;


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
