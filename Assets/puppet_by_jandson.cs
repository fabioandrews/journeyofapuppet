using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace AssemblyCSharp

{
public class puppet_by_jandson : MonoBehaviour {
		private Tile_by_jandson[] ordem_final;
		private bool walk;	//indica se esta andando
		private bool stair; //indica se esta subindo escada
		private int index;
		private PopupWindowGameOver gameOverWindow; //referenciado agora internamente ao popupgameover
		private float seconds = 20;

		// Use this for initialization
		void Start () {
		}

		void Awake()
		{
			ordem_final = new Tile_by_jandson[9];
			for (int i = 1; i <= ordem_final.Length; i++)
			{ordem_final [i-1] = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();}
			walk = false;
			stair = false;
			index = 0;
			gameOverWindow = (PopupWindowGameOver)GameObject.Find ("popupGameOver").GetComponent<PopupWindowGameOver> ();
		}

		//chamado apenas pelo botao go, e chamado apenas 1x
		public void setWalk(){walk = true;ordem_final[index].highlights ();}

		public bool getWalk() {return walk;}

		//nas colisoes, verifica o inimigo que causou a colisao,
		//se realizada a acao certa, tratar, senao, walk = false e chamar a janela de game over
		void OnCollisionEnter2D (Collision2D col)
		{
			switch (col.gameObject.name)
			{
				case "Lobo":
					switch (ordem_final[index].getAcao())
					{
						case "Pular":
							//tratamento para colisao com lobo, tile de pulo
							rigidbody2D.AddForce(new Vector2(0.0f,320.0f));
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
							index++;
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
						break;
						case "Atacar":
							//tratamento para colisao com lobo, tile de ataque
							GameObject.Destroy(col.gameObject);
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
							index++;
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
						break;
						default:
							//tratamento de gameover, personagem nao anda mais, e chama a janela de gameover
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;
							StartCoroutine("apenasFazerDelay");
						break;
					}
				break;
				case "urso":
					switch (ordem_final[index].getAcao())
					{
						case "Atacar":
							//tratamento para colisao com urso, tile de ataque
							GameObject.Destroy(col.gameObject);
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
							index++;
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
						break;
						default:
							//tratamento de gameover, personagem nao anda mais, e chama a janela de gameover
							walk = false;
							index = 0;
							gameOverWindow.mostrarPopupGameOver = true;
						break;
					}
				break;
				case "buraco":
					switch (ordem_final[index].getAcao())
					{
						case "Pular":
							//tratamento para colisao com buraco, tile de pulo
							rigidbody2D.AddForce(new Vector2(0.0f,630.0f));
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
							index++;
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
						break;
						default:
							//tratamento de gameover, personagem nao anda mais, e chama a janela de gameover
							col.collider.isTrigger = true;
							col.rigidbody.isKinematic = true;

						break;
					}
				break;
				case "escada":
					switch (ordem_final[index].getAcao())
					{
					case "Escada":
						//tratamento para colisao com escada, tile de escada
						//tira o efeito de rigidbody, movimentacao do personagem, e o arremessa no chao do prefab
						walk = false;
						stair = true;
						rigidbody2D.isKinematic = true;
						transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);
						break;
						default:
						//aqui da para tratar como quiser, eu escolhi que quando nao for subir, apenas faz nada
						break;
					}
				break;
			}
		}

		private IEnumerator apenasFazerDelay()
		{
			yield return new WaitForSeconds(0.4F);
			walk = false;
			index = 0;
			gameOverWindow.mostrarPopupGameOver = true;
		}

		void OnCollisionExit2D(Collision2D col)
		{
			//personagem arremessado pelo tratamento da escada, volta a ter atributos anteriores
			//esse metodo esta assim para caso haja mais tratamentos aqui
			if (col.gameObject.name == "escada")
			{
				rigidbody2D.isKinematic = false;
				walk = true;
				stair = false;
				if (index < ordem_final.Length){ordem_final[index].highlights ();}
				index++;
				if (index < ordem_final.Length){ordem_final[index].highlights ();}
			}
		}

	// Update is called once per frame
		void Update () {
			if (walk) {transform.position = new Vector2 (transform.position.x + 0.06f, transform.position.y);}
			if (stair) {transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);}
		}
	}
}