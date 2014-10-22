using UnityEngine;
using System.Collections;

public class Toast : MonoBehaviour {

	private bool mostrarToast; 
	private string textoToast;

	public void setMostrarToast(bool novoValor)
	{
		mostrarToast = novoValor;
	}

	public void setTextoToast(string novoValor)
	{
		textoToast = novoValor;
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{	
		if ( mostrarToast == true )
		{
			float alpha  = 0.5f;
			
			GUIStyle style = GUI.skin.label;
			style.fontSize = 20; // Set size of text to 20.
			style.normal.textColor = new Color(255, 0, 0, alpha); // Set color to white w/alpha.
			GUI.Label(new Rect(5.721395f , (-7.037542f), 
			                   1000, 200), textoToast, style);
		}
	}


}
