using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Background_by_jandson : MonoBehaviour {
	private Tile_by_jandson[] inicio;
	private string[] acoes;
	private bool modo_facil;

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
		inicio = new Tile_by_jandson[9];
		acoes = new string[9] {"pular alto", "pular alto", "pular alto", "atacar", "pular alto", "atacar", "atacar", "atacar",""};
		for (int i = 1; i <= 9; i++)
		{inicio [i-1] = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();}
		inicializador ();
	}


	public void inicializador ()
	{
		for (int i = 1; i <= 9; i++)
		{inicio[i-1].setAcao(acoes[i-1]);}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {modo_facil = !modo_facil;}
		if (Input.GetKeyDown (KeyCode.I)) {inicializador();}
	}
}
