using UnityEngine;
using System;
namespace AssemblyCSharp	
{
	public class Button_by_jandson : MonoBehaviour {
		private Tile_by_jandson[] ordem; // vetor de referencias as tiles criadas
		private puppet_by_jandson puppet;

		// Use this for initialization
		void Start () {
		}
		// Update is called once per frame
		void Update () {
	
		}

		void Awake(){
			ordem = new Tile_by_jandson[9];
			for (int i = 1; i <= ordem.Length; i++)
			{
				ordem [i-1] = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();
			}
			puppet = (puppet_by_jandson)GameObject.Find("Puppet").GetComponent<puppet_by_jandson>();
		}

		private void OnMouseDown()
		{
			for (int i = 0; i < ordem.Length; i++) {Destroy(ordem[i].collider2D);}
			Destroy (this.collider2D);
			puppet.setWalk ();
		}
	}
}
