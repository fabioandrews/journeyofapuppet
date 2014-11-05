using UnityEngine;
using System.Collections;

public class TextoExplicaControleAtual : MonoBehaviour {

	//esse script foi criado porque era a unica forma de adicionar uma segunda linha ao texto
	// Use this for initialization

	string textoAtual = "";
	void Start () 
	{
		guiText.text = "Clique apenas em uma peça perto do\ncanto vazio para\nfazer ela ficar no canto\nvazio";
		textoAtual = guiText.text;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) 
		{
			if(textoAtual == "Clique apenas em uma peça perto do\ncanto vazio para\nfazer ela ficar no canto\nvazio")
			{
				guiText.text = "Clique em uma peça qualquer e\ndepois clique em\noutra para trocar a posiçao\ndelas";
			}
			else
			{
				guiText.text = "Clique apenas em uma peça perto do\ncanto vazio para\nfazer ela ficar no canto\nvazio";
			}

			textoAtual = guiText.text;
		}
	}

	public void alternarTextoExplicacaoControles()
	{
		if(textoAtual == "Clique apenas em uma peça perto do\ncanto vazio para\nfazer ela ficar no canto\nvazio")
		{
			guiText.text = "Clique em uma peça qualquer e\ndepois clique em\noutra para trocar a posiçao\ndelas";
		}
		else
		{
			guiText.text = "Clique apenas em uma peça perto do\ncanto vazio para\nfazer ela ficar no canto\nvazio";
		}
		
		textoAtual = guiText.text;
	}
}
