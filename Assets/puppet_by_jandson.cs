﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace AssemblyCSharp

{
public class puppet_by_jandson : MonoBehaviour {
		private Tile_by_jandson[] ordem_final;
		private bool andando;	//indica se esta andando
		private bool subindo_escada; //indica se esta subindo escada
		private bool morto;
		private int indice_vetor;
		private PopupWindowGameOver janela_gui; //referenciado agora internamente ao popupgameover
		private CameraVisaoDoEstagio cameraPrincipal;

		// Use this for initialization
		void Start () {
		}

		void Awake()
		{
			ordem_final = new Tile_by_jandson[9];
			for (int i = 1; i <= ordem_final.Length; i++)
			{ordem_final [i-1] = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();}
			andando = false;
			subindo_escada = false;
			morto = false;
			indice_vetor = 0;
			janela_gui = (PopupWindowGameOver)GameObject.Find ("popupGameOver").GetComponent<PopupWindowGameOver> ();
			cameraPrincipal = (CameraVisaoDoEstagio)GameObject.Find("Main Camera").GetComponent<CameraVisaoDoEstagio>();
		}

		//chamado apenas pelo botao go, e chamado apenas 1x
		public void setWalk(){andando = true;ordem_final[indice_vetor].highlights ();}

		public bool getWalk() {return andando;}

		//nas colisoes, verifica o inimigo que causou a colisao,
		//se realizada a acao certa, tratar, senao, walk = false e chamar a janela de game over
		IEnumerator OnCollisionEnter2D (Collision2D col)
		{
			switch (col.gameObject.name)
			{
				case "Lobo":
					switch (ordem_final[indice_vetor].getAcao())
					{
						case "Pular":
							//tratamento para colisao com lobo, tile de pulo
							//aqui da para deixar objeto kinematic e trigger, sem perder as propriedades
							rigidbody2D.AddForce(new Vector2(0.0f,320.0f));
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							ordem_final[indice_vetor].highlights ();
							indice_vetor++;
							if (indice_vetor < ordem_final.Length){ordem_final[indice_vetor].highlights ();}
						break;
						case "Atacar":
							//tratamento para colisao com lobo, tile de ataque
							//aqui da para deixar objeto kinematic e trigger, sem perder as propriedades
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;
							//delay para realizar a açao apenas quando se aproximar o suficiente
							yield return new WaitForSeconds(0.4F);
							GameObject.Destroy(col.gameObject);
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							ordem_final[indice_vetor].highlights ();
							indice_vetor++;
							if (indice_vetor < ordem_final.Length){ordem_final[indice_vetor].highlights ();}
						break;
						default:
							//tratamento de gameover, personagem nao anda mais, e chama a janela de gameover
							//aqui da para deixar objeto kinematic e trigger, sem perder as propriedades
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;
							//delay para realizar a açao apenas quando se aproximar o suficiente
							yield return new WaitForSeconds(0.4F);
							andando = false;
							indice_vetor = 0;
							janela_gui.mostrarPopupGameOver = true;
						break;
					}
				break;
				case "urso":
					switch (ordem_final[indice_vetor].getAcao())
					{
						case "Atacar":
							//tratamento para colisao com urso, tile de ataque
							GameObject.Destroy(col.gameObject);
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							ordem_final[indice_vetor].highlights ();
							indice_vetor++;
							if (indice_vetor < ordem_final.Length){ordem_final[indice_vetor].highlights ();}
						break;
						default:
							//tratamento de gameover, personagem nao anda mais, e chama a janela de gameover
							andando = false;
							indice_vetor = 0;
							janela_gui.mostrarPopupGameOver = true;
						break;
					}
				break;
				case "buraco":
					switch (ordem_final[indice_vetor].getAcao())
					{
						case "Pular":
							//tratamento para colisao com buraco, tile de pulo
							//aqui da para deixar objeto kinematic e trigger, sem perder as propriedades
							rigidbody2D.AddForce(new Vector2(0.0f,320.0f));
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							ordem_final[indice_vetor].highlights ();
							indice_vetor++;
							if (indice_vetor < ordem_final.Length){ordem_final[indice_vetor].highlights ();}
						break;
						default:
							//tratamento de gameover, personagem nao anda mais, e chama a janela de gameover
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;
							//delay para realizar a açao apenas quando se aproximar o suficiente
							yield return new WaitForSeconds(0.6F);
							//camera volta a nao ter pai
							cameraPrincipal.gameObject.transform.parent = null;
							//andando = false para ele nao continuar indo para a direita
							//destruir box colider para ele poder cair
							Destroy (this.collider2D);
							andando = false;
							indice_vetor = 0;
							janela_gui.mostrarPopupGameOver = true;
						break;
					}
				break;
				case "escada":
					switch (ordem_final[indice_vetor].getAcao())
					{
					case "Escada":
						//tratamento para colisao com escada, tile de escada
						//tira o efeito de rigidbody, movimentacao do personagem, e o arremessa no chao do prefab
						andando = false;
						subindo_escada = true;
						rigidbody2D.isKinematic = true;
						transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);
						break;
						default:
						//aqui da para tratar como quiser, eu escolhi que quando nao for subir, apenas faz nada
						break;
					}
				break;
				case "finish":
					andando = false;
					janela_gui.mostrarCenaDeFinalDeFase = true;
					janela_gui.mostrarPopupGameOver = true;
				break;
			}
		}

		void OnCollisionExit2D(Collision2D col)
		{
			//personagem arremessado pelo tratamento da escada, volta a ter atributos anteriores
			//esse metodo esta assim para caso haja mais tratamentos aqui
			if (col.gameObject.name == "escada")
			{
				rigidbody2D.isKinematic = false;
				andando = true;
				subindo_escada = false;
				ordem_final[indice_vetor].highlights ();
				indice_vetor++;
				if (indice_vetor < ordem_final.Length){ordem_final[indice_vetor].highlights ();}
			}
		}

	// Update is called once per frame
		void Update ()
		{
			if (andando) {transform.position = new Vector2 (transform.position.x + 0.06f, transform.position.y);}
			if (subindo_escada) {transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);}
		}
	}
}