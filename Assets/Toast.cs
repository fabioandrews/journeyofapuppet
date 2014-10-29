using UnityEngine;
using System.Collections;

public class Toast : MonoBehaviour {

	private bool mostrarToast; 
	private string textoToast;
	private float displayTime = 5.0f;
	float alpha  = 0.5f;



	public void setMostrarToast(bool novoValor)
	{
		mostrarToast = novoValor;
		if(novoValor == true)
		{
			float alpha  = 0.5f;
		}
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
			
			GUIStyle style = GUI.skin.label;
			style.fontSize = 20; // Set size of text to 20.
			style.normal.textColor = new Color(255, 0, 0, alpha); // Set color to white w/alpha.
			GUI.Label(new Rect(5.721395f , (-7.037542f), 
			                   1000, 200), textoToast, style);
			float startTime = Time.time;
			if ((Time.time - startTime) < displayTime) {
				GUI.Label(new Rect(5.721395f , (-7.037542f), 
				                   1000, 200), textoToast, style);GUI.Label(new Rect(5.721395f , (-7.037542f), 
			                   1000, 200), textoToast, style);
				style = GUI.skin.label;
				style.fontSize = 20;
				style.normal.textColor = new Color(255, 0, 0, alpha);
				//Debug.Log("alphaAntes=" + alpha);
				alpha = alpha - 0.001f;
				if(alpha < 0f)
				{
					//Debug.Log("Deixou mostrar toast=");
					mostrarToast = false;
				}
				//Debug.Log("alpha=" + alpha);
			}
			else
			{
				//Debug.Log("Deixou mostrar toast=");
				mostrarToast = false;
			}


		}
	}

	IEnumerator Fade(){
		Debug.Log("fade called");

		while (guiText.material.color.a > 0){
			Color guitexto = guiText.material.color;
			guitexto.a -= 0.1f * Time.deltaTime * 0.05f;
			yield return null;
		}
	}



}
