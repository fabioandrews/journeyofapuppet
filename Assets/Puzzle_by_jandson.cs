using UnityEngine;
using System;
namespace AssemblyCSharp
	
{
	public class Puzzle_by_jandson : MonoBehaviour {

		private Tile_by_jandson[] ordem;
		Vector3 auxiliar;
		void  start(){

			ordem = new Tile_by_jandson[9];
			auxiliar.Set ((float)-1.1,(float) 1.1,(float) -1);

			for (int counter1 = 0; counter1 < 3; counter1++)
			{
				for (int counter2 = 0; counter2 < 3; counter2++)
				{
					ordem[counter2+(counter1*3)].setPosicao(auxiliar);
					auxiliar.Set(auxiliar.x+(float)1.08,auxiliar.y,auxiliar.z);
				}
				auxiliar.Set((float)-1.1,auxiliar.y+(float)1.05,auxiliar.z);
			}
		}
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
	
		}
	}
}