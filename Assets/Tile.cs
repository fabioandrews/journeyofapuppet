//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.34014
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
namespace AssemblyCSharp

{
	public class Tile : MonoBehaviour
	{
				String acao;
				public GridPuzzle puzzle;
				String nomeTile;
				public Tile()
				{

				}
			// Use this for initialization
			void Start () {
			}

			public void setarAcao(String novaAcao)
			{
				acao = novaAcao;
			}
			public String getAcao()
			{
				return acao;
			}
			public void setarNome(String nome)
			{
				nomeTile = nome;
			}
			public String getNome()
			{
				return nomeTile;
			}

			void OnMouseDown()
			{
				puzzle.alguemClicouNumTile(nomeTile);
			}
			// Update is called once per frame
			void Update () 
			{
				/*if (Input.GetMouseButtonDown(0)) 
				{
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					if(Physics.Raycast(ray, out hit))
					{
						GameObject clickedGmObj = hit.transform.gameObject;
						if(clickedGmObj != null && clickedGmObj == this)
				   		{
							puzzle.alguemClicouNumTile(nomeTile);
						}
					}
				}*/
			}


			
		}
}
