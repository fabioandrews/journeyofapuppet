using UnityEngine;
using System;
namespace AssemblyCSharp

{
public class puppet_by_jandson : MonoBehaviour {
		private Tile_by_jandson[] ordem_final;
		private bool walk;
		private bool stair;
		private int index;
		private PopupWindowGameOver gameOverWindow;

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
							rigidbody2D.AddForce(new Vector2(0.0f,320.0f));
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
							index++;
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
						break;
						case "Atacar":
							GameObject.Destroy(col.gameObject);
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
							index++;
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
						break;
						default:
							walk = false;
							index = 0;
							gameOverWindow.mostrarPopupGameOver = true;
						break;
					}
				break;
				case "urso":
					switch (ordem_final[index].getAcao())
					{
						case "Atacar":
							GameObject.Destroy(col.gameObject);
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
							index++;
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
						break;
						default:
						break;
					}
				break;
				case "buraco":
					switch (ordem_final[index].getAcao())
					{
						case "Pular":
							rigidbody2D.AddForce(new Vector2(0.0f,630.0f));
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
							index++;
							if (index < ordem_final.Length){ordem_final[index].highlights ();}
						break;
						default:
						break;
					}
				break;
				case "escada":
					switch (ordem_final[index].getAcao())
					{
					case "Escada":
						walk = false;
						stair = true;
						rigidbody2D.isKinematic = true;
						transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);
						break;
						default:
						break;
					}
				break;
			}
		}

		void OnCollisionExit2D(Collision2D col)
		{
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