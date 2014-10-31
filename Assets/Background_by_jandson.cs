using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Background_by_jandson : MonoBehaviour {
	private Tile_by_jandson[] inicio;
	private string[] acoes;
	private bool modo_facil;
	private static bool awake_deve_ser_chamado = true; //da primeira vez que o usuario entra na fase, deve-se chamar a funcao Awake. 
													   //Mas Awake seria chamado de novo ao fazer restart da fase(quando o boneco morre). 
													   //Nao queremos isso! Jah fazemos inicializador() fora do Awake no Puzzle_by_jandson.cs(o else da funcao Awake() desse cs)

	
	public void resetarCenaSemGuardarPosicoesBlocos()
	{
		awake_deve_ser_chamado = true;
	}
	// Use this for initialization

	public string[] getAcoes(){return acoes;}
	public void setAcoes(string[] novasAcoes)
	{
		acoes = novasAcoes;
	}
	public bool getModoFacil(){return modo_facil;}

	void start (){}

	void Awake ()
	{
		if (awake_deve_ser_chamado == true) 
		{
			inicio = new Tile_by_jandson[9];
			string nomeDaCenaAtual = Application.loadedLevelName;
			//Debug.Log("nomedaCenaAtual=" + nomeDaCenaAtual);
			if(nomeDaCenaAtual == "Game_scene1_1")
			{
				acoes = new string[9] {"pular alto", "pular alto", "pular alto", "pular alto", "", "pular alto", "pular alto", "pular alto","pular alto"};
			}
			else if(nomeDaCenaAtual == "Game_scene1_2")
			{
				acoes = new string[9] {"atacar", "pular alto", "pular alto", "atacar", "pular alto", "pular alto", "atacar", "atacar",""};
			}
			else if(nomeDaCenaAtual == "Game_scene1_3")
			{
				acoes = new string[9] {"pular alto", "pular alto", "pular alto", "atacar", "pular alto", "atacar", "atacar", "atacar",""};
			}
			else if(nomeDaCenaAtual == "Game_scene1_4")
			{
				//detonado da fase: pula pula ataca escada escada pula ataca ataca
				acoes = new string[9] {"pular alto", "pular alto", "atacar", "escada", "atacar", "escada", "atacar", "","pular alto"};
			}
			else
			{
				acoes = new string[9] {"pular alto", "pular alto", "pular alto", "pular alto", "", "pular alto", "pular alto", "pular alto","pular alto"};
			}

			for (int i = 1; i <= 9; i++)
			{inicio [i-1] = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();}
			inicializador ();

			awake_deve_ser_chamado = false;
		}
	}


	public void inicializador ()
	{
		if (inicio == null)  
		{
			inicio = new Tile_by_jandson[9];
		}
		for (int i = 1; i <= 9; i++)
		{
			inicio [i-1] = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();
			inicio[i-1].setAcao(acoes[i-1]);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {modo_facil = !modo_facil;}
		if (Input.GetKeyDown (KeyCode.I)) {inicializador();}
	}
}
