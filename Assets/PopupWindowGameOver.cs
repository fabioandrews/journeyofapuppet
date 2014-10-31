using UnityEngine;
using System.Collections;
using System;

namespace AssemblyCSharp
{

public class PopupWindowGameOver : MonoBehaviour {
	static float larguraPopup = 350;
	static float AlturaPopup = 200;
	Rect _quitWindowRect = new Rect ( (Screen.width - larguraPopup)/2, (Screen.height - AlturaPopup)/2, larguraPopup, AlturaPopup );
	public bool mostrarPopupGameOver = false;
	public script_texto_balao textoDoBalao;
	public bool mostrarCenaDeFinalDeFase = false;//ele vira true quando o jogador ganha a fase


	
	void OnGUI()
	{	
		if ( mostrarPopupGameOver == true )
		{
			string tituloDoPopup = "Game Over";
			if(mostrarCenaDeFinalDeFase == true)
			{
					tituloDoPopup = "Fim de Fase";
			}

			GUI.Window ( 247879709, _quitWindowRect, QuitWindowFunction, tituloDoPopup);
		}
	}
	
	void QuitWindowFunction ( int id )
	{
		string textoBotao1 = "Tentar de Novo";
		string textoBotao2 = "Seleção de fases";
			string textoFraseFinal = "<color=red><size=20>VOCÊ ME FEZ MORRER, POXA!</size></color>";
		if(mostrarCenaDeFinalDeFase == true)
		{
			textoBotao1 = "Próxima Fase";
			textoFraseFinal = "<color=red><size=20>NÃO MORRI! ALELUIA!</size></color>";
		}
		GUIStyle centeredTextStyle = new GUIStyle("label");
		centeredTextStyle.alignment=TextAnchor.MiddleCenter;
		GUI.Label(new Rect(20, 40, larguraPopup - 40, 80),textoFraseFinal, centeredTextStyle);
		if ( GUI.Button ( new Rect ( 10, 100, 150, 30 ), textoBotao1 ))
		{
				if(mostrarCenaDeFinalDeFase == false)
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				else if(mostrarCenaDeFinalDeFase == true)
				{
					string nomeDaCenaAtual = Application.loadedLevelName;
					string [] nomeDaCenaSeparadoPorUnderlines = nomeDaCenaAtual.Split('_');
					string nivel_atual = nomeDaCenaSeparadoPorUnderlines[nomeDaCenaSeparadoPorUnderlines.Length - 1];
					int nivelEmNumero = Int32.Parse(nivel_atual);
					int novoNivel = nivelEmNumero + 1;
					string nomeDaProximaCena = nomeDaCenaSeparadoPorUnderlines[0] + "_" + nomeDaCenaSeparadoPorUnderlines[1] +  "_" + novoNivel;
					//LEMBRAR: PRA MUDAR DE MUNDO, nomeDaCenaSeparadoPorUnderlines[1] TEM DE MUDAR NESSA STRING
					Background_by_jandson backgroundJandson = (Background_by_jandson) GameObject.Find("background").GetComponent<Background_by_jandson>();
					backgroundJandson.resetarCenaSemGuardarPosicoesBlocos();
					Puzzle_by_jandson puzzleJandson = (Puzzle_by_jandson) GameObject.Find("puzzle").GetComponent<Puzzle_by_jandson>();
					puzzleJandson.resetarOrdemParaNovaFase();
					Application.LoadLevel(nomeDaProximaCena);


				}
		}
		if ( GUI.Button ( new Rect ( larguraPopup - 160, 100, 150, 30 ), textoBotao2 ))
		{
				// TODO: return to game
		}
		
	}

	// Use this for initialization
	void Start () {
		mostrarPopupGameOver = false;
		mostrarCenaDeFinalDeFase = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

}