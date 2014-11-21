using UnityEngine;
using System.Collections;

public class BotaoOkFazPopupSumir : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//assim que o botao aparecer na tela, significa que existe uma janela popup na tela com esse botao, certo? Como guiText eh um componente que
		//sempre fica acima de todos os gameobjects e o guitext do texto do balao aparece assim que o jogo comeca, eh melhor fazer o texto do balao sumir
		//por um tempo e soh quando a popup window desaparecer(ou seja, quando for clicado no botao OK), faremos o texto do balao reaparecer
		GUIText texto_do_balao = (GUIText)GameObject.Find ("texto_do_balao").GetComponent<GUIText> ();
		texto_do_balao.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//para onMouseDown ser chamado, tem de haver um collider no objeto
	void OnMouseDown()
	{
		if (this.name == "botaoOkPopExplicaAcoesDoBonecoNaFase") 
		{
			//eh o botao OK para fazer o popup que mostra as acoes do boneco sumir!
			//vamos achar todos os objetos que fazem parte do popup que explica as acoes(se ele existir na cena) e faze-los ir para um local que o usuario nao pode ver
			GameObject gameObjectPopupExplicaAcoesDoBoneco = GameObject.Find ("popupExplicaAsAcoesDoBonecoNaFase");
			if (gameObjectPopupExplicaAcoesDoBoneco != null)  
			{
				gameObjectPopupExplicaAcoesDoBoneco.transform.position = new Vector3( 999.23f , 999.7f , 0.0f);
			}
			
			//nao eh so o popup que vai ser movido. Lembre-se que os GuiText nao podem ser filhos de ninguem! Por isso, devemos tira-los da cena separadamente(se existirem)
			GameObject textoAsAcoesQueOBonecoPodeExecutarNaFase = GameObject.Find ("textoAsAcoesQueOBonecoPodeExecutarNaFase");
			if (textoAsAcoesQueOBonecoPodeExecutarNaFase != null) 
			{
				textoAsAcoesQueOBonecoPodeExecutarNaFase.transform.position = new Vector3( 999.2f , 999.7f , 0.0f);
			}
			
			GameObject textoExplicaTilePularAlto = GameObject.Find ("textoExplicaTilePularAlto");
			if (textoExplicaTilePularAlto != null) 
			{
				textoExplicaTilePularAlto.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			}
			GameObject textoExplicaTileVazio = GameObject.Find ("textoExplicaTileVazio");
			if (textoExplicaTileVazio != null) 
			{
				textoExplicaTileVazio.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			}
			GameObject textoExplicaTileAtacar = GameObject.Find ("textoExplicaTileAtacar");
			if (textoExplicaTileAtacar != null) 
			{
				textoExplicaTileAtacar.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			}

			
			this.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			
			//agora faremos o texto do balao reaparecer, ja que o popup deve ter sumido
			GUIText texto_do_balao = (GUIText)GameObject.Find ("texto_do_balao").GetComponent<GUIText> ();
			texto_do_balao.enabled = true;
		}



	}
}
