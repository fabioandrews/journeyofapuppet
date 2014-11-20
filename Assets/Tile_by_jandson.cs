using UnityEngine;
using System;
namespace AssemblyCSharp
	
{
	public class Tile_by_jandson : MonoBehaviour {
		private Puzzle_by_jandson my_grid;
		private Sprite[] sprites;
		private String acao;
		private String nome;
		private bool highlight;

		private SpriteRenderer spriteRenderer;
	
		public Tile_by_jandson () {acao = "";}

		public String getNome() {return nome;}

		public void setNome(String nomeNovo) {this.nome = nomeNovo;}

		public String getAcao () {return acao;}
		
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

		public void highlights ()
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


		private void OnMouseDown() {my_grid.Changer (this);}

		// Use this for initialization
		void Start ()
		{
			my_grid = (Puzzle_by_jandson)GameObject.Find ("puzzle").GetComponent<Puzzle_by_jandson> ();
			highlight = false;
			DontDestroyOnLoad (transform.gameObject);
		}
	
	// Update is called once per frame
		void Update () {
	
		}

		void Awake () {DontDestroyOnLoad (transform.gameObject);}
	}
}
