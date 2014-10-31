using UnityEngine;
using System.Collections;
namespace AssemblyCSharp
	
{
public class TextoMoverCameraUsandoTeclado : MonoBehaviour {
	Personagem personagem;
	public 
	// Use this for initialization
	void Start () {
		personagem = GameObject.Find("ghostSheet_0").GetComponent<Personagem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (personagem.deveAndar == true) 
		{
			guiText.text = "";
		}
		else
		{ 
			guiText.text = "Use as setas do teclado para ver o estágio";
		}
	}
}
}
