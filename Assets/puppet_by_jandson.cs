using UnityEngine;
using System;
namespace AssemblyCSharp

{
public class puppet_by_jandson : MonoBehaviour {
		private Puzzle_by_jandson acoes;
		private String[] ordem_final;
		private bool walk;
		private bool stair;
		private int index;
		// Use this for initialization
		void Start () {
	
		}

		void Awake(){
			acoes = (Puzzle_by_jandson)GameObject.Find ("puzzle").GetComponent<Puzzle_by_jandson> ();
			walk = false;
			stair = false;
			index = 0;
		}

		public void setWalk(){walk = true;ordem_final = acoes.getAcoesNaOrdem ();}

		public bool getWalk() {return walk;}

		void OnCollisionEnter2D (Collision2D col)
		{
			switch (col.gameObject.name)
			{
				case "Lobo":
					switch (ordem_final[index])
					{
						case "pular alto":
							rigidbody2D.AddForce(new Vector2(0.0f,320.0f));
							index++;
						break;
						case "atacar":
							GameObject.Destroy(col.gameObject);
							index++;
						break;
						default:
						break;
					}
				break;
				case "urso":
					switch (ordem_final[index])
					{
						case "atacar":
							GameObject.Destroy(col.gameObject);
							index++;
						break;
						default:
						break;
					}
				break;
				case "buraco":
					switch (ordem_final[index])
					{
						case "pular alto":
							rigidbody2D.AddForce(new Vector2(0.0f,630.0f));
							index++;
						break;
						default:
						break;
					}
				break;
				case "escada":
					switch (ordem_final[index])
					{
					case "escada":
						walk = false;
						stair = true;
						rigidbody2D.isKinematic = true;
						transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);
						//rigidbody2D.AddForce(new Vector2(0.0f,700.0f));
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
			}
		}

	// Update is called once per frame
		void Update () {
			if (walk) {transform.position = new Vector2 (transform.position.x + 0.06f, transform.position.y);}
			if (stair) {transform.position = new Vector2 (transform.position.x, transform.position.y + 0.09f);}
		}
	}
}