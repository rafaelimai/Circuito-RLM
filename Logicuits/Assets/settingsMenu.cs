using UnityEngine;
using System.Collections;

public class settingsMenu : MonoBehaviour {

	public int SCALE;
	public static float sfxSlider = 75;
	public static float musicSlider = 75;
	public int sliderSize;

	public GUISkin guiSkin;
	float textSize;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		// Configura a GUI de acordo com o tamanho da tela
		GUI.skin = guiSkin;
		
		guiSkin.label.fontSize = Screen.height/(2*SCALE);
		guiSkin.button.fontSize = Screen.height/(SCALE*SCALE);

		// CalcSize calcula o tamanho que um texto ocupa.
		textSize = guiSkin.label.CalcSize(new GUIContent("Settings")).x;
		// Os argumentos de uma etiqueta (Label) sao: um retangulo, com centro x,y e arestas a,b, e um string
		// GUI.Label(new Rect(x,y,a,b), string)
		GUI.Label(new Rect ((Screen.width - textSize)/2 , Screen.height/(2*SCALE) , textSize , guiSkin.label.fontSize), "Settings");

		// Etiqueta do slider do volume das musicas
		guiSkin.label.fontSize = Screen.height/(4*SCALE);
		textSize = guiSkin.label.CalcSize (new GUIContent ("Music Volume")).x;
		GUI.Label (new Rect ((Screen.width - textSize) / 2, 2.5f * Screen.height/SCALE - guiSkin.label.fontSize, textSize, guiSkin.label.fontSize), "Music Volume");


		// Etiqueta do slider do volume dos SFX
		guiSkin.label.fontSize = Screen.height/(4*SCALE);
		textSize = guiSkin.label.CalcSize (new GUIContent ("SFX Volume")).x;
		GUI.Label (new Rect ((Screen.width - textSize) / 2, 2f*Screen.height/SCALE - guiSkin.label.fontSize, textSize, guiSkin.label.fontSize), "SFX Volume");


		// Slider do volume da musica 
		musicSlider = GUI.HorizontalSlider (new Rect ((Screen.width - sliderSize) / 2, 2.5f * Screen.height / SCALE, sliderSize, sliderSize / 32), musicSlider, 0, 100);


		// Slider do volume dos SFX
		sliderSize = Screen.width / 4;
		sfxSlider = GUI.HorizontalSlider(new Rect ((Screen.width - sliderSize)/2, 2f*Screen.height/SCALE, sliderSize, sliderSize/32), sfxSlider, 0, 100); 

	}
}
