using UnityEngine;
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
		private SpriteRenderer spriteRenderer; //cara que muda os sprites do personagem
		protected Animator animacao;

		// Use this for initialization
		void Start () {
			//coisas relacionadas a troca de sprites do personagem
			spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
			animacao = GetComponent<Animator>();
			if (spriteRenderer.sprite == null) 
			{
				Sprite spritePersonagemComum = Resources.Load("bonecoPequeno", typeof(Sprite)) as Sprite;
				spriteRenderer.sprite = spritePersonagemComum; // set the sprite to sprite1
			}
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
		public void setWalk(){andando = true;ordem_final[indice_vetor].highlights ();this.animacao.SetBool ("Walk", true);}

		public bool getWalk() {return andando;}

		//nas colisoes, verifica o inimigo que causou a colisao,
		//se realizada a acao certa, tratar, senao, walk = false e chamar a janela de game over
		IEnumerator OnCollisionEnter2D (Collision2D col)
		{
			Debug.Log (col.gameObject.name);
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
							this.andando = false;//personagem fica parado pra atacar o inimigo
							//vamos acabar com esse monstro!
							Sprite spritePersonagemAtacou = Resources.Load("bonecoPequenoAtacando", typeof(Sprite)) as Sprite;
							spriteRenderer.sprite = spritePersonagemAtacou;
							StartCoroutine("fazerAnimacaoPersonagemMataInimigo");
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
							this.animacao.SetBool ("Walk", false);
							andando = false;
							Sprite spritePersonagemMorreu = Resources.Load("bonecoPequenoMorto", typeof(Sprite)) as Sprite;
							spriteRenderer.sprite = spritePersonagemMorreu;
							AudioClip sfxBatida = Resources.Load("comedy_music_run_fall_and_crash", typeof(AudioClip)) as AudioClip;
							audio.PlayOneShot(sfxBatida);
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
							this.andando = false;//personagem fica parado pra atacar o inimigo
							//vamos acabar com esse monstro!
							Sprite spritePersonagemAtacou = Resources.Load("bonecoPequenoAtacando", typeof(Sprite)) as Sprite;
							spriteRenderer.sprite = spritePersonagemAtacou;
							StartCoroutine("fazerAnimacaoPersonagemMataInimigo");
							GameObject.Destroy(col.gameObject);
							//chama metodo de troca de highlight para a tile atual, e a prox, caso haja
							ordem_final[indice_vetor].highlights ();
							indice_vetor++;
							if (indice_vetor < ordem_final.Length){ordem_final[indice_vetor].highlights ();}
						break;
						default:
							//tratamento de gameover, personagem nao anda mais, e chama a janela de gameover
							this.animacao.SetBool ("Walk", false);
							andando = false;
							Sprite spritePersonagemMorreu = Resources.Load("bonecoPequenoMorto", typeof(Sprite)) as Sprite;
							spriteRenderer.sprite = spritePersonagemMorreu;
							AudioClip sfxBatida = Resources.Load("comedy_music_run_fall_and_crash", typeof(AudioClip)) as AudioClip;
							audio.PlayOneShot(sfxBatida);
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
							yield return new WaitForSeconds(0.7F);
							this.animacao.SetBool ("Walk", false);
							AudioClip sfxBatida = Resources.Load("comedy_music_run_fall_and_crash", typeof(AudioClip)) as AudioClip;
							audio.PlayOneShot(sfxBatida);
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
						this.rigidbody2D.isKinematic = true;
						yield return new WaitForSeconds(0.6F);
						andando = true;
						subindo_escada = false;
						yield return new WaitForSeconds(3.2F);
						rigidbody2D.isKinematic = false;
						ordem_final[indice_vetor].highlights ();
						indice_vetor++;
						if (indice_vetor < ordem_final.Length){ordem_final[indice_vetor].highlights ();}
					//transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);
					break;
						default:
						//aqui da para tratar como quiser, eu escolhi que quando nao for subir, apenas faz nada
						col.collider.isTrigger = true;
						col.rigidbody.isKinematic = true;
						col.collider.isTrigger = true;
					break;
					}
				break;
				case "finish":
					this.animacao.SetBool ("Walk", false);
					andando = false;
					janela_gui.mostrarCenaDeFinalDeFase = true;
					janela_gui.mostrarPopupGameOver = true;
					Button_by_jandson botaoFazPersonagemAndar = GameObject.Find ("botao1").GetComponent<Button_by_jandson> ();
					AudioClip musicaVitoria = Resources.Load("a_day_in_the_sun", typeof(AudioClip)) as AudioClip;
					botaoFazPersonagemAndar.audio.clip = musicaVitoria;
					botaoFazPersonagemAndar.audio.loop = true;
					botaoFazPersonagemAndar.audio.Play (0);
				break;
			}
		}

	// Update is called once per frame
		void Update ()
		{
			if (andando) {transform.position = new Vector2 (transform.position.x + 0.06f, transform.position.y);}
			if (subindo_escada) {transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);}
		}

		public IEnumerator fazerAnimacaoPersonagemMataInimigo()
		{
			yield return new WaitForSeconds(0.2F);
			Sprite spritePersonagemComum = Resources.Load("bonecoPequeno", typeof(Sprite)) as Sprite;
			spriteRenderer.sprite = spritePersonagemComum;
			this.andando = true;
		}
	}
}