using UnityEngine;
using System;
namespace AssemblyCSharp
	
{
	public class Tile_by_jandson : MonoBehaviour {
		private String acao;
		private Vector3 posicao;
		private Boolean clicado;
	
	
		public Tile_by_jandson(Vector3 posicao_inicial)
		{
			clicado = false;
			posicao = posicao_inicial;
			transform.position = posicao;
		}

		public void setarAcao(String novaAcao)
		{
			acao = novaAcao;
		}
		public String getAcao()
		{
			return acao;
		}
	
		public Vector3 getPosicao()
		{
			return posicao;
		}

		public void setPosicao(Vector3 novaposicao)
		{
			posicao = novaposicao;
			transform.position = posicao;
		}
		public void OnMouseDown()
		{
			clicado = true;
		}
	
		public Boolean getClicado()
		{
			return clicado;
		}

		public void setClicado()
		{
			clicado = !clicado;
		}

		// Use this for initialization
		void Start () {
	
		}
	
	// Update is called once per frame
		void Update () {
	
		}
	}
}
