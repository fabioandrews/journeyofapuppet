using UnityEngine;
using System.Collections;

public class PopupWindowGameOver : MonoBehaviour {
	static float larguraPopup = 350;
	static float AlturaPopup = 200;
	Rect _quitWindowRect = new Rect ( (Screen.width - larguraPopup)/2, (Screen.height - AlturaPopup)/2, larguraPopup, AlturaPopup );
	public bool mostrarPopupGameOver = false;

	
	void OnGUI()
	{
		if ( mostrarPopupGameOver == true )
		{
			Debug.Log("mostrar popup game over = true");
			GUI.Window ( 247879709, _quitWindowRect, QuitWindowFunction, "Game Over" );
		}
	}
	
	void QuitWindowFunction ( int id )
	{
		GUI.Label(new Rect(20, 40, larguraPopup - 40, 80),"<color=red><size=20>VOCÊ ME FEZ MORRER, POXA!</size></color>");
		if ( GUI.Button ( new Rect ( 10, 100, 150, 30 ), "Tentar de Novo" ))
		{
				Application.LoadLevel(Application.loadedLevel);
		}
		if ( GUI.Button ( new Rect ( larguraPopup - 160, 100, 150, 30 ), "Seleção de fases" ))
		{
				// TODO: return to game
		}
		
	}

	// Use this for initialization
	void Start () {
		mostrarPopupGameOver = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
