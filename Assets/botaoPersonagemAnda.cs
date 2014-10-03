using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
public class botaoPersonagemAnda : MonoBehaviour 
{
	public Personagem fantasminha;
	public Camera cameraPrincipal;
	// Use this for initialization
	public GridPuzzle puzzle;//NOVO ATRIBUTO PRO BOTAO
	void Start () {
	}
	
	//para onMouseDown ser chamado, tem de haver um collider no objeto
	void OnMouseDown()
	{
			puzzle.pegarPosicoesDosTilesAntesDeRestartCena();
			cameraPrincipal.gameObject.transform.parent = fantasminha.gameObject.transform; //a camera agora vai seguir o personagem. Entao ele vira pai da camera principal
			//Camera.SetupCurrent(cameraPersonagemAnda);
			fantasminha.fazerAndar();
	}
	// Update is called once per frame
	void Update () 
	{
		//transform.Translate(displacement); FAZ PERSONAGEM ANDAR PRA DIREITA CASO VOCE ALTERE X NO DISPLACEMENT NO inspector do objeto
	}

}
}
