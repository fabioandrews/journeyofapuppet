using UnityEngine;
using System;
namespace AssemblyCSharp
	
{
	public class Tile_by_jandson : MonoBehaviour {
		private Puzzle_by_jandson my_grid;
		private Sprite[] sprites;
		private String acao; //basicamente o nome, que define a açao correspondente a tile(ordem nao importa)
		private bool highlight; //tile com highlight = true, sem = false

		private SpriteRenderer spriteRenderer;
	
		public Tile_by_jandson () {acao = "";}

		//retorna para grid, para trocar acao,
		//para o personagem saber quais acoes ele deve realizar
		public String getAcao () {return acao;}

		//chamado enquanto o botao go nao e pressionado, define ou troca acoes e seus sprites
		public void setAcao (String nova_acao)
		{
			acao = nova_acao;
			spriteRenderer = GetComponent<SpriteRenderer>();
			switch (acao)
			{
				//Melhor por o load aqui, pois ele so e feito 1x na vida, entao nao precisa carregar todos sprites
				case "Pular":
				case "Atacar":
				case "Escada":
				sprites = Resources.LoadAll<Sprite> ("tile"+acao);
					spriteRenderer.sprite = sprites[0];
					break;
				default:
				spriteRenderer.sprite = null;
				break;
			}
		}

		//chamado depois que botao go e pressionado, alterna entre com e sem highlight
		//faz nada, caso seja acao vazia
		public void highlights ()
		{
			if (acao != "")
			{
				if (highlight == false)
				{
					highlight = true;
					sprites = Resources.LoadAll<Sprite> ("tile" + acao + "Highlight");
					spriteRenderer.sprite = sprites [0];
				}
				else
				{
					highlight = false;
					sprites = Resources.LoadAll<Sprite> ("tile" + acao);
					spriteRenderer.sprite = sprites [0];
				}
			}
			else
			{ 
				if (highlight == false)
				{
					highlight = true;
					sprites = Resources.LoadAll<Sprite> ("tile" + "Nada" + "Highlight");
					spriteRenderer.sprite = sprites [0];
				}
				else
				{
					highlight = false;
					sprites = Resources.LoadAll<Sprite> ("tile" + "Nada");
					spriteRenderer.sprite = sprites [0];
				}
			}
		}

		//chama metodo de troca do grid
		private void OnMouseDown() {my_grid.Changer (this);}

		// Use this for initialization
		void Start ()
		{
			my_grid = (Puzzle_by_jandson)GameObject.Find ("puzzle").GetComponent<Puzzle_by_jandson> ();
			highlight = false;
			DontDestroyOnLoad (transform.gameObject);
		}
	
	// Update is called once per frame
		void Update () {}

		void Awake () {DontDestroyOnLoad (transform.gameObject);}
	}
}
