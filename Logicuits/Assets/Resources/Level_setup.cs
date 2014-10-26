using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level_setup : MonoBehaviour {
	
	/* -----VARIAVEIS UNITY-----
	 * guiSkin: GUISkin padrao
	 * pointer: Sprite de ponteiro seta
	 * hand: Sprite de ponteiro 
	 * toolbox: Caixa de ferramentas (a que contem os botoes 
	 * gateManager: GO que contem todas as portas logicas (e o circuito em si, que eh meio que uma porta logica)
	 * circuit: Objeto que contem as entradas e saidas do circuito
	 * mainCam: Camera (usada aqui para conversao pixel-unidades, apenas)
	 */
	public GUISkin guiSkin;
	public Texture2D pointer;
	public Texture2D hand;
	public GameObject toolbox;
	public GameObject gateManager;
	public GameObject circuit;
	public Object Correct;
	public Object Wrong;
	public GameObject symbol;
	public Object LevelComplete;
	public GameObject endMessage;
	public Camera mainCam;

	/* -----VARIAVEIS NORMAIS-----
	 * currentLevel: String que representa o nivel atual. (currentLevel = "level1", etc)
	 * handCursor: Bool que indica se o mouse deve ter imagem de mao
	 * veify: Bool que indica se o programa esta em processo de verificar uma saida
	 * finish: Book que indica se o programa terminou de fazer todas as verificaçoes
	 * answer: Lista de listas que representam a saida do circuito construido (uma lista para cada entrada)
	 * aux: Lista auxiliar usada na construçao de answer
	 * answerString: Texto formatado a ser impresso no final da verificaçao
	 * zueira: Ao incluir zueiras, sempre usar if (zueira) {}
	 * iteration: Indica o numero do teste programado para o nivel
	 */
	public static string currentLevel;
	public static bool handCursor = false;
	public static bool verify = false;
	public static bool finish = false;
	public static List<string> answer;
	public string aux;
	public static string inputsString;
	public static string expectedString;
	public static string answerString;
	public static string auxString;
	public static bool zueira = false;
	public static int iteration;

	/*-----VARIAVEIS CRIADORAS DE NIVEL-----> Devem ser editadas por developers para criar niveis
	 * numberOfInputs/Outputs: numero de Inputs e outputs do circuito
	 * inputStateList: Lista de valores que os inputs assumem em cada teste (na ordem). Primeiro teste -> primeiro elemento...
	 * outputStateList: Lista de valores esperados no output do circuito, em cada teste (Sao a resposta do problema) }  SOB RISCO DE
	 * input/outputStateLists: Listas de listas, so para deixar mais facil iterar sobre elas                          }    EXTINÇAO
	 */
	public int numberOfInputs;
	public int numberOfOutputs;

	public string inputStateList1;
	public string inputStateList2;
	public string inputStateList3;
	public string inputStateList4;
	List<string> inputStateLists = new List<string>();

	public string outputStateList1;
	public string outputStateList2;
	public string outputStateList3;
	public string outputStateList4;
	List<string> outputStateLists = new List<string>();

	bool done;


	// Use this for initialization
	void Start () {

		/*
		 **************************************************
		 * REINICIALIZAÇAO DE VARIAVEIS
		 **************************************************
		 */

		verify = false;
		finish = false;
		answer = new List<string>();
		aux = "";
		inputsString = "Inputs:\n";
		expectedString = "Expected:\n";
		answerString = "Outputs:\n";
		iteration = 0;

		inputStateLists.Add(inputStateList1);
		inputStateLists.Add(inputStateList2);
		inputStateLists.Add(inputStateList3);
		inputStateLists.Add(inputStateList4);

		outputStateLists.Add(outputStateList1);
		outputStateLists.Add(outputStateList2);
		outputStateLists.Add(outputStateList3);
		outputStateLists.Add(outputStateList4);

		Correct = Resources.Load("Prefabs/Correct");
		Wrong = Resources.Load("Prefabs/Wrong");
		LevelComplete = Resources.Load("Prefabs/LevelComplete");

		/*
		 **************************************************
		 * POSICIONAMENTO DE INPUTS/OUTPUTS
		 **************************************************
		 */
		for (int index = 1; index <= numberOfInputs; index++) {
			GameObject inputCreated = Instantiate(Resources.Load("Prefabs/C-Input")) as GameObject;
			inputCreated.transform.parent = GameObject.Find ("Gate Manager/Circuit").transform;
			inputCreated.transform.position = new Vector3
				(-4F, mainCam.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y*(1f-2*(float)index/(numberOfInputs+1)), 0);
			inputCreated.GetComponent<StatePoint>().statelist = inputStateLists[index-1];
		}

		for (int index = 1; index <= numberOfOutputs; index++) {
			GameObject outputCreated = Instantiate(Resources.Load("Prefabs/C-Output")) as GameObject;
			outputCreated.transform.parent = GameObject.Find ("Gate Manager/Circuit").transform;
			outputCreated.transform.position = new Vector3
				(7F, mainCam.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y*(1f-2*(float)index/(numberOfInputs+1)), 0);
			outputCreated.GetComponent<StatePoint>().statelist = outputStateLists[index-1];
		}

		/*
		 **************************************************
		 * FORMATAÇAO DE STRINGS PARA FEEDBACK
		 **************************************************
		 */


		for (int i = 0; i < inputStateList1.Length; i++) {
			foreach(Transform statePoint in circuit.transform) {
				if (statePoint.gameObject.GetComponent<StatePoint>().type == "C-INPUT"){
					inputsString += statePoint.GetComponent<StatePoint>().statelist[i].ToString();
				}
				if (statePoint.gameObject.GetComponent<StatePoint>().type == "C-OUTPUT"){
					expectedString += statePoint.GetComponent<StatePoint>().statelist[i].ToString();
				}
			}
			inputsString += "\n";
			expectedString += "\n";
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 **************************************************
		 * CUSTOMIZAÇAO DO MOUSE
		 **************************************************
		 */
		if (handCursor){
			Cursor.SetCursor(hand, new Vector2 (11,0), CursorMode.Auto);
		}
		else {
			Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
		}
		handCursor = false;

		/*
		 **************************************************
		 * DETERMINAÇAO DE FIM DE TESTE (ITERAÇAO)
		 **************************************************
		 */
		if (verify) {
			done = true; // Beneficio da duvida
			foreach (Transform statePoint in circuit.transform) {
				if (statePoint.gameObject.GetComponent<StatePoint>().type == "C-OUTPUT" && statePoint.gameObject.GetComponent<StatePoint>().state == 2) {
					done = false;
				}
			}
		}

		/*
		 **************************************************
		 * PROCEDIMENTO DE FIM DE TESTE
		 **************************************************
		 * Salvar resultados no answerString, desativar verify
		 */
		if (done && verify) {

			// Add output
			foreach (Transform statePoint in circuit.transform) {
				if (statePoint.GetComponent<StatePoint>().type == "C-OUTPUT") {
					auxString += statePoint.GetComponent<StatePoint>().state.ToString ();
				}
			}
			// Next line
			answerString += auxString+"\n";
			if (auxString == expectedString.Substring(10+(numberOfOutputs+1)*iteration,numberOfOutputs)) {
				symbol = Instantiate (Correct, new Vector3(iteration, 4f, 0f), new Quaternion(0,0,0,0)) as GameObject;
			}
			else {
				symbol = Instantiate (Wrong, new Vector3(iteration, 4f, 0f), new Quaternion(0,0,0,0)) as GameObject;
			}
			auxString = "";
			verify = false;

			if (GameObject.FindGameObjectsWithTag("Correct").Length == inputStateList1.Length) {
				endMessage = Instantiate(LevelComplete, new Vector3 (0,2,0), new Quaternion(0,0,0,0)) as GameObject;
			}
		}
	}

	void OnGUI () {
		/*
		 **************************************************
		 * SETUP DA GUI (TAMANHO E FONTE)
		 **************************************************
		 */
		GUI.skin = guiSkin;
		guiSkin.button.fontSize = Screen.height/16;
		guiSkin.label.fontSize = Screen.height/16;
		guiSkin.textArea.fontSize = Screen.height/16;

		/*
		 **************************************************
		 * BOTAO CHECK / NEXT
		 **************************************************
		 */

		// Durante montagem de circuito, botao Check inicia verificaçao
		if (!verify && !done && GUI.Button (new Rect (Screen.width*1/64,  Screen.height*12/16, Screen.width*1/6, guiSkin.button.fontSize*1.1f), "Check")) {
			verify = true;
		}

		// Se esta no meio de um teste, botao (desativado) Testing... impede que o usuario faça caca
		GUI.enabled = false;
		if (verify && GUI.Button (new Rect (Screen.width*1/64,  Screen.height*12/16, Screen.width*1/6, guiSkin.button.fontSize*1.1f), "Testing...")) {}
		GUI.enabled = true;

		// Se terminou a presente iteraçao da checagem, botao Next passa para o proximo passo
		if (done && GUI.Button (new Rect (Screen.width*1/64,  Screen.height*12/16, Screen.width*1/6, guiSkin.button.fontSize*1.1f), "Next")) {

			// Move on to next iteration (if there are any to be done) or end verification (if not)
			if (iteration+1 < circuit.GetComponentInChildren<StatePoint>().statelist.Length) {
				done = false;
				verify = true;
				iteration ++;
				foreach(Object spark in GameObject.FindGameObjectsWithTag("Spark")) {
					Destroy(spark);
				}
				foreach (Transform Gate in gateManager.transform) {
					foreach (Transform statePoint in Gate) {
						statePoint.gameObject.GetComponent<StatePoint>().state = 2;
						statePoint.gameObject.GetComponent<StatePoint>().alreadyPropagated = false;
					}
				}
			}
			else {
				finish = true;
			}
		}

		/*
		 **************************************************
		 * BOTAO UNDO -> REINICIA O NIVEL ATUAL
		 **************************************************
		 */

		if (GUI.Button (new Rect (Screen.width*1/64,  Screen.height*13/16, Screen.width*1/6, guiSkin.button.fontSize*1.1f), "Undo")) {
			Application.LoadLevel(Level_setup.currentLevel);
		}

		/*
		 **************************************************
		 * BOTAO MENU -> RETORNA PARA O MENU PRINCIPAL
		 **************************************************
		 */

		if (GUI.Button (new Rect (Screen.width*1/64,  Screen.height*14/16, Screen.width*1/6, guiSkin.button.fontSize*1.1f), "Main Menu")) {
			Application.LoadLevel("menu");
		}

		/*
		 **************************************************
		 * PROCEDIMENTO DE FIM DE VERIFICAÇAO
		 **************************************************
		 */
		if (finish) {
			if (verify) {
				verify = false;
				for (int i = 0; i < answer.Count; i++) {

				}
			}
			finish = false;
		}
		/*
		 **************************************************
		 * FEEDBACK
		 **************************************************
		 */
		// Inputs
		GUI.TextArea(new Rect(Screen.width*10f/16f,Screen.height*3f/4f,Screen.width/8f,Screen.height/4f), inputsString);
		// Expected outputs
		GUI.TextArea(new Rect(Screen.width*12f/16f,Screen.height*3f/4f,Screen.width/8f,Screen.height/4f), expectedString);
		// Outputs
		GUI.TextArea(new Rect(Screen.width*14f/16f,Screen.height*3f/4f,Screen.width/8f,Screen.height/4f), answerString);
	}
}
