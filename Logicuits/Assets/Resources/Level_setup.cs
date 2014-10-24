using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level_setup : MonoBehaviour {

	/*

 	  ________                           _             _  __ _              _____       ____  _    _ _______ _____  _    _ _______ ___  
     / / / __ \                         (_)           (_)/ _(_)            / ____|     / __ \| |  | |__   __|  __ \| |  | |__   __|__ \ 
    / / / |  | |   __ _ _   _  ___   ___ _  __ _ _ __  _| |_ _  ___ __ _  | |   ______| |  | | |  | |  | |  | |__) | |  | |  | |     ) |
   / / /| |  | |  / _` | | | |/ _ \ / __| |/ _` | '_ \| |  _| |/ __/ _` | | |  |______| |  | | |  | |  | |  |  ___/| |  | |  | |    / / 
  / / / | |__| | | (_| | |_| |  __/ \__ \ | (_| | | | | | | | | (_| (_| | | |____     | |__| | |__| |  | |  | |    | |__| |  | |   |_|  
 /_/_/   \____/   \__, |\__,_|\___| |___/_|\__, |_| |_|_|_| |_|\___\__,_|  \_____|     \____/ \____/   |_|  |_|     \____/   |_|   (_)  
                     | |                    __/ |                                                                                       
                     |_|                   |___/                                                                                        



Escreve um pouco descrevendo o padrao de nomenclatura das variaveis. Pode cair muito bem para o desenvolvimento.
	 */



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
	public static List<List<int>> answer;
	public List<int> aux;
	public static string answerString;
	public static bool zueira = false;
	public static int iteration;
	int counter;

	/*-----VARIAVEIS CRIADORAS DE NIVEL-----> Devem ser editadas por nos developers para criar niveis
	 * numberOfInputs/Outputs: numero de Inputs e outputs do circuito
	 * inputStateList: Lista de valores que os inputs assumem em cada teste (na ordem). Primeiro teste -> primeiro elemento...
	 * outputStateList: Lista de valores esperados no output do circuito, em cada teste (Sao a resposta do problema) }  SOB RISCO DE
	 * input/outputStateLists: Listas de listas, so para deixa mais facil iterar sobre elas                          }    EXTINÇAO
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

	//Da pra dar um tapa, se criarmos uma classe Resposta, por exemplo. Essa classe encapsularia coisas como os valores de input e output.
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
		answer = new List<List<int>>();
		aux = new List<int>();
		answerString = "";
		iteration = 0;

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
				(-5f, mainCam.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y*(1f-2*(float)index/(numberOfInputs+1)), 0);
			inputCreated.GetComponent<StatePoint>().statelist = inputStateLists[index-1];
		}

		for (int index = 1; index <= numberOfOutputs; index++) {
			GameObject outputCreated = Instantiate(Resources.Load("Prefabs/C-Output")) as GameObject;
			outputCreated.transform.parent = GameObject.Find ("Gate Manager/Circuit").transform;
			outputCreated.transform.position = new Vector3
				(8f, mainCam.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y*(1f-2*(float)index/(numberOfInputs+1)), 0);
			outputCreated.GetComponent<StatePoint>().statelist = outputStateLists[index-1];
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
		 * BOTAO DE CHECAGEM / PROXIMO PASSO
		 **************************************************
		 */

		// Se nao esta verificando, nem terminou a verificaçao de um teste, botao Check inicia verificaçao
		if (!verify && !done && GUI.Button (new Rect (Screen.width*1/32,  Screen.height*12/16, Screen.width*1/8, guiSkin.button.fontSize), "Check")) {
			answerString = "";
			verify = true;
		}

		// Se esta no meio de um teste, botao (desativado) Testing... impede que o usuario faça caca
		GUI.enabled = false;
		if (!done && verify && GUI.Button (new Rect (Screen.width*1/32,  Screen.height*12/16, Screen.width*1/8, guiSkin.button.fontSize), "Testing...")) {
		}
		GUI.enabled = true;

		// Se terminou a presente iteraçao da checagem, botao Next passa para o proximo passo
		if (done && GUI.Button (new Rect (Screen.width*1/32,  Screen.height*12/16, Screen.width*1/8, guiSkin.button.fontSize), "Next")) {
			foreach (Transform statePoint in circuit.transform) {
				if (statePoint.GetComponent<StatePoint>().type == "C-OUTPUT") {
					aux.Add (statePoint.GetComponent<StatePoint>().state);
				}
			}


			Level_setup.answer.Add(new List<int>(aux));
			aux.Clear();
			
			// Move on to next iteration or end verification
			//Explica um pouco aqui do porque do if abaixo.
			if (iteration+1 < circuit.GetComponentInChildren<StatePoint>().statelist.Length) {
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

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*13/16, Screen.width*1/8, guiSkin.button.fontSize), "Undo")) {
			Application.LoadLevel(Level_setup.currentLevel);
		}

		/*
		 **************************************************
		 * BOTAO MENU -> RETORNA PARA O MENU PRINCIPAL
		 **************************************************
		 */

		if (GUI.Button (new Rect (Screen.width*1/32,  Screen.height*14/16, Screen.width*1/8, guiSkin.button.fontSize), "Main Menu")) {
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
				counter = 0;
				for (int i = 0; i < answer.Count; i++) {
					// Add input
					foreach(Transform statePoint in circuit.transform) {
						if (statePoint.gameObject.GetComponent<StatePoint>().type == "C-INPUT"){
							answerString += statePoint.GetComponent<StatePoint>().statelist[counter].ToString();
						}
					}

					// Add space
					answerString += " ";
					// Add output
					foreach (int bit in answer[i]) {
						answerString += bit.ToString();
					}

					// Next line
					answerString += "\n";
					counter ++;
				}
			}
			finish = false;
		}
		GUI.TextArea(new Rect(Screen.width*3f/4f,Screen.height*3f/4f,Screen.width/4f,Screen.height/4f), answerString);
	}
}
