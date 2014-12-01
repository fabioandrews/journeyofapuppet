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

		string nomeDaCenaAtual = Application.loadedLevelName;
		if(nomeDaCenaAtual.CompareTo("Game_scene1_1") == 0 || nomeDaCenaAtual.CompareTo("cenaPraTestarPopupMoverBlocos") == 0)
		{
			//eh a primeira fase? se sim, tem de explicar como se joga. Entao precisamos ocultar textos seguintes do popup para que eles nao se sobreponham
			GameObject textoAsAcoesQueOBonecoPodeExecutarNaFase = GameObject.Find ("textoAsAcoesQueOBonecoPodeExecutarNaFase");
			if (textoAsAcoesQueOBonecoPodeExecutarNaFase != null) 
			{
				GUIText textoFazerSumir = textoAsAcoesQueOBonecoPodeExecutarNaFase.GetComponent<GUIText>();
				textoFazerSumir.enabled= false;
			}
			GameObject textoExplicaTilePularAlto = GameObject.Find ("textoExplicaTilePularAlto");
			if (textoExplicaTilePularAlto != null) 
			{
				GUIText textoFazerSumir = textoExplicaTilePularAlto.GetComponent<GUIText>();
				textoFazerSumir.enabled= false;
			}
			GameObject textoExplicaTileVazio = GameObject.Find ("textoExplicaTileVazio");
			if (textoExplicaTileVazio != null) 
			{
				GUIText textoFazerSumir = textoExplicaTileVazio.GetComponent<GUIText>();
				textoFazerSumir.enabled= false;
			}

			//fazer desaparecer textos sobre as explicacoes das acoes...
			GameObject textoTituloExplicaExecucaoDasAcoes = GameObject.Find ("tituloPopupExplicaExecucaoDasAcoes");
			if (textoTituloExplicaExecucaoDasAcoes != null) 
			{
				GUIText textoFazerSumir = textoTituloExplicaExecucaoDasAcoes.GetComponent<GUIText>();
					textoFazerSumir.enabled= false;
			}
			
			GameObject textoExplicaOrdemExecucaoDasAcoes = GameObject.Find ("explicacaoExecucaoDasAcoes");
			if (textoExplicaOrdemExecucaoDasAcoes != null) 
			{
				GUIText textoFazerSumir = textoExplicaOrdemExecucaoDasAcoes.GetComponent<GUIText>();
				textoFazerSumir.enabled= false;
			}






		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//para onMouseDown ser chamado, tem de haver um collider no objeto
	void OnMouseDown()
	{
		if (this.name == "botaoOkPopExplicaAcoesDoBonecoNaFase") 
		{
			Debug.Log("clicou no botao que explica as açoes do boneco");
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
		if (this.name == "botaoOkPopExplicaMovimentoBlocos") 
		{
			Debug.Log("clicou no botao que explica movimento dos blocos");
			//eh o botao OK para fazer o popup que mostra as acoes do boneco sumir!
			//vamos achar todos os objetos que fazem parte do popup que explica as acoes(se ele existir na cena) e faze-los ir para um local que o usuario nao pode ver
			GameObject gameObjectPopupExplicaAcoesDoBoneco = GameObject.Find ("popupExplicaMovimentoDosBlocos");
			if (gameObjectPopupExplicaAcoesDoBoneco != null)  
			{
				gameObjectPopupExplicaAcoesDoBoneco.transform.position = new Vector3( 999.23f , 999.7f , 0.0f);
			}
			
			//nao eh so o popup que vai ser movido. Lembre-se que os GuiText nao podem ser filhos de ninguem! Por isso, devemos tira-los da cena separadamente(se existirem)
			GameObject textoTituloExplicaMovimentoBlocos = GameObject.Find ("tituloPopupExplicaMovimentoBlocos");
			if (textoTituloExplicaMovimentoBlocos != null) 
			{
				textoTituloExplicaMovimentoBlocos.transform.position = new Vector3( 999.2f , 999.7f , 0.0f);
			}
			
			GameObject textoExplicaMovimentoBlocos = GameObject.Find ("explicacaoMovimentoDosBlocos");
			if (textoExplicaMovimentoBlocos != null) 
			{
				textoExplicaMovimentoBlocos.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			}
			GameObject videoExplicaMovimentoBlocos = GameObject.Find ("videoexplicacaoMoveBloco");
			if (videoExplicaMovimentoBlocos != null) 
			{
				videoExplicaMovimentoBlocos.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			}

			//fazer reaparecer as explicacoes do popup seguinte...
			//nao eh so o popup que vai ser movido. Lembre-se que os GuiText nao podem ser filhos de ninguem! Por isso, devemos tira-los da cena separadamente(se existirem)
			GameObject textoTituloExplicaExecucaoDasAcoes = GameObject.Find ("tituloPopupExplicaExecucaoDasAcoes");
			if (textoTituloExplicaExecucaoDasAcoes != null) 
			{
				GUIText textoFazerSumir = textoTituloExplicaExecucaoDasAcoes.GetComponent<GUIText>();
				textoFazerSumir.enabled= true;
			}
			
			GameObject textoExplicaOrdemExecucaoDasAcoes = GameObject.Find ("explicacaoExecucaoDasAcoes");
			if (textoExplicaOrdemExecucaoDasAcoes != null) 
			{
				GUIText textoFazerSumir = textoExplicaOrdemExecucaoDasAcoes.GetComponent<GUIText>();
				textoFazerSumir.enabled= true;
			}

			
			
			this.transform.position = new Vector3(999.2f , 999.7f , 0.0f);

		}
		if (this.name == "botaoOkPopExplicaExecucaoDasAcoes") 
		{
			Debug.Log("clicou no botao que explica a ordem de execucao das acoes");
			//eh o botao OK para fazer o popup que mostra as acoes do boneco sumir!
			//vamos achar todos os objetos que fazem parte do popup que explica as acoes(se ele existir na cena) e faze-los ir para um local que o usuario nao pode ver
			GameObject gameObjectPopupExplicaExecucaoDasAcoes = GameObject.Find ("popupExplicaExecucaoDasAcoes");
			if (gameObjectPopupExplicaExecucaoDasAcoes != null)  
			{
				gameObjectPopupExplicaExecucaoDasAcoes.transform.position = new Vector3( 999.23f , 999.7f , 0.0f);
			}
			
			//nao eh so o popup que vai ser movido. Lembre-se que os GuiText nao podem ser filhos de ninguem! Por isso, devemos tira-los da cena separadamente(se existirem)
			GameObject textoTituloExplicaExecucaoDasAcoes = GameObject.Find ("tituloPopupExplicaExecucaoDasAcoes");
			if (textoTituloExplicaExecucaoDasAcoes != null) 
			{
				textoTituloExplicaExecucaoDasAcoes.transform.position = new Vector3( 999.2f , 999.7f , 0.0f);
			}
			
			GameObject textoExplicaOrdemExecucaoDasAcoes = GameObject.Find ("explicacaoExecucaoDasAcoes");
			if (textoExplicaOrdemExecucaoDasAcoes != null) 
			{
				textoExplicaOrdemExecucaoDasAcoes.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			}
			GameObject videoExplicaExecucaoAcoesDoBoneco = GameObject.Find ("videoexplicacaoAcoesSequencia");
			if (videoExplicaExecucaoAcoesDoBoneco != null) 
			{
				videoExplicaExecucaoAcoesDoBoneco.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			}

			//fazer reaparecer as explicacoes do popup seguinte...
			GameObject textoAsAcoesQueOBonecoPodeExecutarNaFase = GameObject.Find ("textoAsAcoesQueOBonecoPodeExecutarNaFase");
			if (textoAsAcoesQueOBonecoPodeExecutarNaFase != null) 
			{
				GUIText textoFazerSumir = textoAsAcoesQueOBonecoPodeExecutarNaFase.GetComponent<GUIText>();
				textoFazerSumir.enabled= true;
			}
			GameObject textoExplicaTilePularAlto = GameObject.Find ("textoExplicaTilePularAlto");
			if (textoExplicaTilePularAlto != null) 
			{
				GUIText textoFazerSumir = textoExplicaTilePularAlto.GetComponent<GUIText>();
				textoFazerSumir.enabled= true;
			}
			GameObject textoExplicaTileVazio = GameObject.Find ("textoExplicaTileVazio");
			if (textoExplicaTileVazio != null) 
			{
				GUIText textoFazerSumir = textoExplicaTileVazio.GetComponent<GUIText>();
				textoFazerSumir.enabled= true;
			}
			
			
			this.transform.position = new Vector3(999.2f , 999.7f , 0.0f);
			
		}




	}
}
