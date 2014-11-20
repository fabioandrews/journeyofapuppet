using UnityEngine;
using System.Collections;
namespace AssemblyCSharp
	
{
public class TextoMoverCameraUsandoTeclado : MonoBehaviour {
		puppet_by_jandson personagem;
	public 
	// Use this for initialization
	void Start () {
			personagem = (puppet_by_jandson)GameObject.Find("Puppet").GetComponent<puppet_by_jandson>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (personagem.getWalk() == false)
		{ 
			guiText.text = "Use as setas do teclado para ver o estágio";
		}
	}
}
}
