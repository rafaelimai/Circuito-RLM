using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
	GUISkin guiSkin;
	Texture2D pointer;
	Texture2D hand;
	public Sprite manjubator;
	GameObject gateManager;
	GameObject circuit;
	GameObject toolbox;
	GameObject gateButton;
	Object GATEBUTTON;
	static TextAsset LevelsInfo;
	Object Correct;
	Object Wrong;
	GameObject symbol;
	Object LevelComplete;
	GameObject endMessage;
	Camera mainCam;

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
	public static int currentLevel = 16;
	public static bool handCursor = false;
	public static bool verify = false;
	public static bool itterationComplete;
	public static bool finish = false;
	public static bool won;
	public static List<string> answer;
	string[] LevelList;
	string[] currentLevelInfo;
	string aux;
	string inputsString;
	string expectedString;
	string answerString;
	string auxString;
	public static bool zueira = false;
	public static int iteration;
	bool taskOn;

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


	public static float BUTTON_WIDTH;
	public static float BUTTON_HEIGHT;
	// Use this for initialization
	void Start () {

		/*
		 **************************************************
		 * REINICIALIZAÇAO DE VARIAVEIS
		 **************************************************
		 */

		// Carregamento de elementos do Unity
		mainCam = GameObject.Find("Main Camera").camera;
		guiSkin = Resources.Load ("Pixel Font") as GUISkin;
		pointer = Resources.Load("Images/pointer") as Texture2D;
		hand = Resources.Load("Images/hand") as Texture2D;
		circuit = GameObject.Find("Gate Manager/Circuit");
		gateManager = GameObject.Find ("Gate Manager");
		toolbox = GameObject.Find("Toolbox");
		GATEBUTTON = Resources.Load("Prefabs/Gate Button");
		LevelsInfo = Resources.Load("LevelsInfo") as TextAsset;
		Correct = Resources.Load("Prefabs/Correct");
		Wrong = Resources.Load("Prefabs/Wrong");
		LevelComplete = Resources.Load("Prefabs/LevelComplete");

		// Tomada de informaçoes do arquivo txt
		LevelList = Regex.Split(LevelsInfo.text, "\r\n");
		currentLevelInfo = Regex.Split(LevelList[currentLevel], ",");

		// Variaveis de dialogo
		DialogueManager.dialoguetxt = Resources.Load("Dialogues") as TextAsset;
		DialogueManager.dialogue = Regex.Split(DialogueManager.dialoguetxt.text,"\r\n\r\n")[2*Level_setup.currentLevel];
		DialogueManager.lines = Regex.Split(DialogueManager.dialogue,"\r\n");
		DialogueManager.currentLine = 0;
		DialogueManager.currentStep = 0;
		DialogueManager.RightIcon.GetComponent<SpriteRenderer>().sprite = manjubator;

		if (DialogueManager.lines[0] != "") {
			DialogueManager.isOn = true;
		}

		// Atribuiçao de valores a variaveis
		verify = false;
		itterationComplete = false;
		finish = false;
		won = false;
		taskOn = true;
		answer = new List<string>();
		aux = "";
		inputsString = "Inputs:\n";
		expectedString = "Expected:\n";
		answerString = "Outputs:\n";
		iteration = 0;

		numberOfInputs = System.Convert.ToInt32(currentLevelInfo[1]);
		numberOfOutputs = System.Convert.ToInt32(currentLevelInfo[2]);
		inputStateList1 = currentLevelInfo[3];
		inputStateList2 = currentLevelInfo[4];
		inputStateList3 = currentLevelInfo[5];
		inputStateList4 = currentLevelInfo[6];
		outputStateList1 = currentLevelInfo[7];
		outputStateList2 = currentLevelInfo[8];
		outputStateList3 = currentLevelInfo[9];
		outputStateList4 = currentLevelInfo[10];
		for (int i = 0; i < 6; i += 2) {
			gateButton = Instantiate(GATEBUTTON) as GameObject;
			gateButton.transform.parent = toolbox.transform;
			gateButton.transform.position = toolbox.transform.position + new Vector3(-0.5f,0.75f-(float)i/2f,0f);
			gateButton.GetComponent<GateButton>().type = currentLevelInfo[i+11];
			gateButton.GetComponent<GateButton>().qtty = System.Convert.ToInt32(currentLevelInfo[i+12]);
		}


		inputStateLists.Add(inputStateList1);
		inputStateLists.Add(inputStateList2);
		inputStateLists.Add(inputStateList3);
		inputStateLists.Add(inputStateList4);

		outputStateLists.Add(outputStateList1);
		outputStateLists.Add(outputStateList2);
		outputStateLists.Add(outputStateList3);
		outputStateLists.Add(outputStateList4);


		/*
		 **************************************************
		 * POSICIONAMENTO DE INPUTS/OUTPUTS
		 **************************************************
		 */
		for (int index = 1; index <= numberOfInputs; index++) {
			GameObject inputCreated = Instantiate(Resources.Load("Prefabs/C-Input")) as GameObject;
			inputCreated.transform.parent = GameObject.Find ("Gate Manager/Circuit").transform;
			inputCreated.transform.position = new Vector3
				(-4.5f, mainCam.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y*(1f-2*(float)index/(numberOfInputs+1)), 0);
			inputCreated.GetComponent<StatePoint>().statelist = inputStateLists[index-1];
		}

		for (int index = 1; index <= numberOfOutputs; index++) {
			GameObject outputCreated = Instantiate(Resources.Load("Prefabs/C-Output")) as GameObject;
			outputCreated.transform.parent = GameObject.Find ("Gate Manager/Circuit").transform;
			outputCreated.transform.position = new Vector3
				(7.5f, mainCam.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y*(1f-2*(float)index/(numberOfOutputs+1)), 0);
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
		BUTTON_WIDTH = Screen.width*1/6;
		BUTTON_HEIGHT = guiSkin.button.fontSize*1.1f;
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
			itterationComplete = true; // Beneficio da duvida
			foreach (Transform statePoint in circuit.transform) {
				if (statePoint.gameObject.GetComponent<StatePoint>().type == "C-OUTPUT" && statePoint.gameObject.GetComponent<StatePoint>().state == 2) {
					itterationComplete = false;
				}
			}
		}

		/*
		 **************************************************
		 * PROCEDIMENTO DE FIM DE TESTE
		 **************************************************
		 * Salvar resultados no answerString, desativar verify
		 */
		if (itterationComplete && verify) {

			// Add output
			foreach (Transform statePoint in circuit.transform) {
				if (statePoint.GetComponent<StatePoint>().type == "C-OUTPUT") {
					auxString += statePoint.GetComponent<StatePoint>().state.ToString ();
				}
			}
			// Next line
			answerString += auxString+"\n";
			if (auxString == expectedString.Substring(10+(numberOfOutputs+1)*iteration,numberOfOutputs)) {
				symbol = Instantiate (Correct, new Vector3(1.5f+iteration-(float)inputStateList1.Length/2f, 4f, 0f), new Quaternion(0,0,0,0)) as GameObject;
			}
			else {
				symbol = Instantiate (Wrong, new Vector3(1.5f+iteration-(float)inputStateList1.Length/2f, 4f, 0f), new Quaternion(0,0,0,0)) as GameObject;
			}
			auxString = "";
			verify = false;

			if (GameObject.FindGameObjectsWithTag("Correct").Length == inputStateList1.Length) {
				endMessage = Instantiate(LevelComplete, new Vector3 (0,2,0), new Quaternion(0,0,0,0)) as GameObject;
				won = true;
				if (Menu_setup.levelUnlocked == currentLevel) {
					Menu_setup.levelUnlocked++;
					PlayerPrefs.SetInt("levelUnlocked", Menu_setup.levelUnlocked);
					PlayerPrefs.Save();
				}
				DialogueManager.dialogue = Regex.Split(DialogueManager.dialoguetxt.text,"\r\n\r\n")[2*Level_setup.currentLevel+1];
				DialogueManager.lines = Regex.Split(DialogueManager.dialogue,"\r\n");
				DialogueManager.currentLine = 0;
				DialogueManager.currentStep = 0;
				if (DialogueManager.lines[0] != "") {
					DialogueManager.isOn = true;
				}
			}
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
		 * BOTAO TASK -> MOSTRA / ESCONDE TAREFA
		 **************************************************
		 */
		if (GUI.Button (new Rect (Screen.width*1/10-BUTTON_WIDTH/2,  Screen.height*12/16-BUTTON_HEIGHT, BUTTON_WIDTH, BUTTON_HEIGHT), "Task")) {
			taskOn = !taskOn;
		}

		/*
		 **************************************************
		 * BOTAO CHECK / NEXT
		 **************************************************
		 */

		// Durante montagem de circuito, botao Check inicia verificaçao
		if (!verify && !itterationComplete && GUI.Button (new Rect (Screen.width*1/10-BUTTON_WIDTH/2,  Screen.height*12/16, BUTTON_WIDTH, BUTTON_HEIGHT), "Check")) {
			verify = true;
		}

		// Se esta no meio de um teste, botao (desativado) Testing... impede que o usuario faça caca
		GUI.enabled = false;
		if (verify && GUI.Button (new Rect (Screen.width*1/10-BUTTON_WIDTH/2,  Screen.height*12/16, BUTTON_WIDTH, BUTTON_HEIGHT), "Testing...")) {}
		GUI.enabled = true;

		// Se terminou a presente iteraçao da checagem, botao Next passa para o proximo passo
		if (itterationComplete) { // && GUI.Button (new Rect (Screen.width*1/10-BUTTON_WIDTH/2,  Screen.height*12/16, BUTTON_WIDTH, BUTTON_HEIGHT), "Next")) {

			// Move on to next iteration (if there are any to be done) or end verification (if not)
			if (iteration+1 < circuit.GetComponentInChildren<StatePoint>().statelist.Length) {
				itterationComplete = false;
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

		if (GUI.Button (new Rect (Screen.width*1/10-BUTTON_WIDTH/2,  Screen.height*12/16+BUTTON_HEIGHT, BUTTON_WIDTH, BUTTON_HEIGHT), "Undo")) {

			foreach (GameObject gatebutton in GameObject.FindGameObjectsWithTag("GateButton")) {
				Destroy(gatebutton);
			}
			foreach (GameObject gate in GameObject.FindGameObjectsWithTag("LogicGate")) {
				Destroy(gate);
			}
			foreach (GameObject wire in GameObject.FindGameObjectsWithTag("Wire")) {
				Destroy(wire);
			}
			foreach (GameObject spark in GameObject.FindGameObjectsWithTag("Spark")) {
				Destroy(spark);
			}
			foreach (GameObject correct in GameObject.FindGameObjectsWithTag("Correct")) {
				Destroy(correct);
			}
			foreach (GameObject wrong in GameObject.FindGameObjectsWithTag("Wrong")) {
				Destroy(wrong);
			}
			foreach (GameObject statePoint in GameObject.FindGameObjectsWithTag("StatePoint")) {
				statePoint.GetComponent<StatePoint>().connections.Clear();
				if (statePoint.GetComponent<StatePoint>().type != "C-INPUT") {
					statePoint.GetComponent<StatePoint>().isAssigned = false;
				}
				statePoint.GetComponent<StatePoint>().state = 2;
				if (statePoint.GetComponent<StatePoint>().type == "INPUT") {
					Destroy(statePoint);
				}
			}
			for (int i = 0; i < 6; i += 2) {
				gateButton = Instantiate(GATEBUTTON) as GameObject;
				gateButton.transform.parent = toolbox.transform;
				gateButton.transform.position = toolbox.transform.position + new Vector3(-0.5f,0.75f-(float)i/2f,0f);
				gateButton.GetComponent<GateButton>().type = currentLevelInfo[i+11];
				gateButton.GetComponent<GateButton>().qtty = System.Convert.ToInt32(currentLevelInfo[i+12]);
			}
			verify = false;
			itterationComplete = false;
			finish = false;
			won = false;
			taskOn = true;
			answer = new List<string>();
			aux = "";
			answerString = "Outputs:\n";
			iteration = 0;

		}

		/*
		 **************************************************
		 * BOTAO MENU -> RETORNA PARA O MENU PRINCIPAL
		 **************************************************
		 */

		if (GUI.Button (new Rect (Screen.width*1/10-BUTTON_WIDTH/2,  Screen.height*12/16+2*BUTTON_HEIGHT, BUTTON_WIDTH, BUTTON_HEIGHT), "Main Menu")) {
			Application.LoadLevel("menu");
		}

		/*
		 **************************************************
		 * BOTAO NEXT LEVEL -> AVANÇA PARA O PROXIMO NIVEL (APENAS SE GANHOU)
		 **************************************************
		 */

		if (won && !DialogueManager.isOn &&GUI.Button(new Rect((Screen.width-BUTTON_WIDTH)*1/2, Screen.height*5/8, BUTTON_WIDTH, BUTTON_HEIGHT), "Next Level")) {

			if (currentLevel < 16){
				currentLevel++;
				Application.LoadLevel("leveleditor");
			}
			else {
				Application.LoadLevel("cutscene");
			}


		}

		/*
		 **************************************************
		 * FEEDBACK
		 **************************************************
		 */
		if (taskOn) {
		// Inputs
			GUI.TextArea(new Rect(Screen.width*10f/16f,Screen.height-guiSkin.textArea.fontSize*(inputStateList1.Length+1)*0.85f,Screen.width/8f,guiSkin.textArea.fontSize*(inputStateList1.Length+1)*0.85f), inputsString);
			// Expected outputs
			GUI.TextArea(new Rect(Screen.width*12f/16f,Screen.height-guiSkin.textArea.fontSize*(inputStateList1.Length+1)*0.85f,Screen.width/8f,guiSkin.textArea.fontSize*(inputStateList1.Length+1)*0.85f), expectedString);
			// Outputs
			GUI.TextArea(new Rect(Screen.width*14f/16f,Screen.height-guiSkin.textArea.fontSize*(inputStateList1.Length+1)*0.85f,Screen.width/8f,guiSkin.textArea.fontSize*(inputStateList1.Length+1)*0.85f), answerString);
	
		}
	}
}
