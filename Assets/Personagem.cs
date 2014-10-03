﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace AssemblyCSharp
{
public class Personagem : MonoBehaviour 
{
	public Sprite spritePersonagemComum;
	public Sprite spritePersonagemMorreu; //um sprite para quando o sprite atual deve fazer animacao de morrer
	public Sprite spritePersonagemAtacou; //um sprite para quando o personagem ataca um inimigo
	private SpriteRenderer spriteRenderer; //cara que muda os sprites do personagem
	
	public Vector3 displacement;
	public bool bateuEmAlgo;
	public bool deveAndar;
	float tempoAteProximaAcaoDoBoneco; //tempo que se passou desde o comeco da acao do boneco
	int delay=1;//one seconds delay.Delay dado ate proxima acao do boneco
	public GridPuzzle puzzle;
	String[] acoes;
	int percorredorAcoes = 0;
	GameObject gameObjectQueBonecoColidiuAntesDaAcao; //sempre que o boneco estiver perto de algum obstaculo, esse objeto sera modificado
	
	Boolean personagemEstaSubindoEscada;
	Boolean personagemVaiAtacarOMonstro; //quando um personagem alcanca o collider mais externo do monstro, 
										//caso a proxima acao seja atacar, esse booleano muda porque quando o personagem estiver colado no monstro,
										//ele ataca!
	

	// Use this for initialization
	void Start () 
	{
		bateuEmAlgo = false;
		deveAndar = false;
		//a acao do boneco comeca do start
		tempoAteProximaAcaoDoBoneco = Time.time + delay;
		percorredorAcoes = 0;
		gameObjectQueBonecoColidiuAntesDaAcao = null;
		personagemEstaSubindoEscada = false;
		personagemVaiAtacarOMonstro = false;

		//coisas relacionadas a troca de sprites do personagem
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) 
		{
				spriteRenderer.sprite = spritePersonagemComum; // set the sprite to sprite1
		}
	}

	public void fazerAndar()
	{
		//transform.Translate (new Vector2 (0.1f, 0.0f));
		deveAndar = true;
		//devemos setar as acoes que serao realizadas com o tempo tambem
		acoes = puzzle.pegarOrdemDasAcoes();


	}

	void OnCollisionEnter2D(Collision2D col) 
		{
			if (col.gameObject.name.CompareTo("chao") != 0) 
			{
				//o personagem estah o tempo todo batendo no chao, por isso ele n conta
				bateuEmAlgo = true;

				if(col.gameObject.name.Contains("inimigo") == true)
				{
					if(personagemVaiAtacarOMonstro == false)
					{
						//uh oh. Ele encostou no monstro e nao vai atacar? Entao morre, descracado!
						spriteRenderer.sprite = spritePersonagemMorreu;
					}
					else
					{
						//vamos acabar com esse monstro!
						spriteRenderer.sprite = spritePersonagemAtacou;

						StartCoroutine("fazerAnimacaoPersonagemMataInimigo");

					}
				}
				else if (col.gameObject.name.CompareTo("campopersonagemMorreDeCaidaInfinita") != 0) 
				{
					//o personagem caiu em alguma parte do estagio e deveria morrer com isso. O jogador tem de reiniciar a fase
					Application.LoadLevel(Application.loadedLevel);
					//Debug.Log("caiu no buraco");
					
				}
			}
		}

		/*funcao eh chamada assim que o personagem morre e o jogo reseta*/
		void Awake() 
		{
			//apos o reset da cena, queremos que os tiles permaneçam na mesma posicao
			/*GameObject[] tilesDoPuzzle = GameObject.FindGameObjectsWithTag("tile");
			for (int i = 0; i < tilesDoPuzzle.Length; i++) 
			{
				DontDestroyOnLoad(tilesDoPuzzle[i]);
			}*/
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			bateuEmAlgo = true;
			gameObjectQueBonecoColidiuAntesDaAcao = other.gameObject;
			realizarProximaAcao(); //assim que o personagem encostar em algum obstaculo, ele faz a proxima acao. Essa linha daqui n existia quando a acao era definida pelo tempo
		}

		void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.name.Contains ("escada") == true)  
			{
				personagemEstaSubindoEscada = false;
				bateuEmAlgo = false; //o personagem pode andar novamente
				gameObjectQueBonecoColidiuAntesDaAcao = null;
			}
		}

	void realizarProximaAcao()
	{
			string acao = acoes[percorredorAcoes];
			if(acao.CompareTo("pularbaixo") == 0)
			{
				rigidbody2D.AddForce(new Vector2(0.0f,150.0f));
			}
			else if(acao.CompareTo("pularalto") == 0)
			{
				rigidbody2D.AddForce(new Vector2(0.0f,300.0f));
			}
			else if(acao.CompareTo("subirescada") == 0)
			{ 
				if(gameObjectQueBonecoColidiuAntesDaAcao.name.Contains("escada") == true)
				{
					//eh uma escada e o boneco ira subir nela
					personagemEstaSubindoEscada = true;
				}
			}
			else if(acao.CompareTo("atacar") == 0)
			{ 

				if(gameObjectQueBonecoColidiuAntesDaAcao.name.Contains("inimigo") == true)
				{
					personagemVaiAtacarOMonstro = true; //a acao de atacar mesmo fica por conta do OnCollisionEnter2d
				}

			}
			percorredorAcoes = percorredorAcoes + 1;
			if(percorredorAcoes >= acoes.Length)
			{
				percorredorAcoes = 0;
			}

			if (personagemEstaSubindoEscada == false && personagemVaiAtacarOMonstro == false) 
			{
				//caso o personagem esteja suindo a escada, eh melhor fazer ele terminar a acao antes de permitir que ele ande p frente novamente
				bateuEmAlgo = false;
				gameObjectQueBonecoColidiuAntesDaAcao = null;
			}
			else if(personagemVaiAtacarOMonstro)
			{ 
				//vamos fazer ele andar mais um pouquinho ate o monstro, mas nada de deletar o gameobject ainda
				bateuEmAlgo = false;
			}
	}
	
		public IEnumerator fazerAnimacaoPersonagemMataInimigo()
		{
			yield return new WaitForSeconds(0.2F);

			Destroy(gameObjectQueBonecoColidiuAntesDaAcao);
			spriteRenderer.sprite = spritePersonagemComum;
			
			personagemVaiAtacarOMonstro = false;
			bateuEmAlgo = false;
			gameObjectQueBonecoColidiuAntesDaAcao = null;
		}


	// Update is called once per frame
	void Update() 
	{
		if (bateuEmAlgo == false && deveAndar == true) 
		{
				transform.Translate(5f * Time.deltaTime, 0f, 0f);
		} 
		else if(personagemEstaSubindoEscada == true)
		{ 
				float heightFactor = (float) 3.5; //3.2 fica bem rapido e ele consegue subir
				transform.position += Vector3.up / heightFactor;
		}
		


		//transform.Translate(displacement); FAZ PERSONAGEM ANDAR PRA DIREITA CASO VOCE ALTERE X NO DISPLACEMENT NO inspector do objeto
		/*if (Input.GetKey (KeyCode.Space)) 
		{
			rigidbody2D.AddForce(new Vector2(0.0f,50.0f));
		}*/

	}

		/*Faz o personagem executar a proxima acao de x em x segundos e ele para caso bata em algo*/
		void updateVelho() 
		{
			if (bateuEmAlgo == false && deveAndar == true) 
			{
				transform.Translate(5f * Time.deltaTime, 0f, 0f);
				
				if (Time.time > tempoAteProximaAcaoDoBoneco)
				{
					//passou um tempo desde q ele comecou a andar? Ele pula!Executa outra açao!
					//rigidbody2D.AddForce(new Vector2(0.0f,150.0f));
					string acao = acoes[percorredorAcoes];
					if(acao.CompareTo("pularbaixo") == 0)
					{
						rigidbody2D.AddForce(new Vector2(0.0f,150.0f));
					}
					else if(acao.CompareTo("pularalto") == 0)
					{
						rigidbody2D.AddForce(new Vector2(0.0f,300.0f));
					}
					percorredorAcoes = percorredorAcoes + 1;
					if(percorredorAcoes >= acoes.Length)
					{
						percorredorAcoes = 0;
					}
					tempoAteProximaAcaoDoBoneco = Time.time + delay; //vamos repetir o pulo daqui a um tempinho
					
				}
			}
			
			
			//transform.Translate(displacement); FAZ PERSONAGEM ANDAR PRA DIREITA CASO VOCE ALTERE X NO DISPLACEMENT NO inspector do objeto
			/*if (Input.GetKey (KeyCode.Space)) 
		{
			rigidbody2D.AddForce(new Vector2(0.0f,50.0f));
		}*/
			
		}
	 
}
}
