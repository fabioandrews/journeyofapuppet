using UnityEngine;
using System;
namespace AssemblyCSharp

{
	public class Puzzle_by_jandson : MonoBehaviour {

		private static Tile_by_jandson[] ordem; // vetor de referencias as tiles criadas
		private Tile_by_jandson auxiliar = null; // referencia a tile clicada
		private static Background_by_jandson cenario;
		static String [] acoesDosTilesEmOrdem;//NOVO vou armazenar os tiles antes do restart para manter eles na ordem
		private static Vector3 [] posicoesDosTiles;
		public Item_mover_blocos_livremente itemMoverBlocoLivremente;//NOVO preciso dele pra saber se o item estah ativo no modo normal
		public int contador_quantas_vezes_moveu_blocos_com_item = 0;//	NOVO 

		public void resetarOrdemParaNovaFase()
		{ordem = null;}

		void Start(){}

		// Use this for initialization
		void Awake ()
		{
			if(ordem == null) 
			{
				ordem = new Tile_by_jandson[9];
				acoesDosTilesEmOrdem = new String[9];
				cenario = (Background_by_jandson)GameObject.Find ("background").GetComponent<Background_by_jandson> ();
				for (int i = 1; i <= 9; i++)
				{
					ordem [i-1] = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();
					//int numTile = i - 1;
					Tile_by_jandson umTile = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();
					acoesDosTilesEmOrdem[i - 1] = umTile.getAcao();
				}// inicia referencia as tiles criadas
			}
			else
			{
				//eh o caso de quando da reload no estagio(personagem morre uma vez e o jogador quer reiniciar a fase)
				ordem = new Tile_by_jandson[9];
				for (int i = 1; i <= 9; i++)
				{
					ordem [i-1] = (Tile_by_jandson)GameObject.Find ("tile" + i).GetComponent<Tile_by_jandson> ();
				}// inicia referencia as tiles criadas

				cenario = (Background_by_jandson)GameObject.Find ("background").GetComponent<Background_by_jandson> ();
				cenario.setAcoes(acoesDosTilesEmOrdem);
				cenario.inicializador();

			}

			DontDestroyOnLoad (this);
		}

		public void Changer (Tile_by_jandson entrada)
		{
			if (cenario.getModoFacil ())
			{Changer_easy (entrada);}
			else {Changer_normal(entrada);}
		}

		// modo facil
		private void Changer_easy ( Tile_by_jandson entrada ) // se aux1 for null, aux1 = entrada, senao, troca e depois aux1 = null novamente
		{
			if (auxiliar == null) {auxiliar = entrada;} // use aux1.setAcao("pular alto"); se quiser para testar
			else
			{
				String string_temp = auxiliar.getAcao();
				auxiliar.setAcao(entrada.getAcao());
				entrada.setAcao(string_temp);
				auxiliar = null;

				if(cenario.getModoFacil() == false && contador_quantas_vezes_moveu_blocos_com_item < 1)
				{
					contador_quantas_vezes_moveu_blocos_com_item = contador_quantas_vezes_moveu_blocos_com_item + 1;
				}
				else if(cenario.getModoFacil() == false && contador_quantas_vezes_moveu_blocos_com_item >= 1)
				{
					//tah no modo normal e ele ja mudou dois tiles de posiçao com o item?desativa o item, oras!
					itemMoverBlocoLivremente.desativarItem();//item nao fica mais ativo em uma jogada
					contador_quantas_vezes_moveu_blocos_com_item = 0;//reseta esse contador
					TextoExplicaControleAtual explicacaoControleAtual = GameObject.Find("TextoExplicaControleAtual").GetComponent<TextoExplicaControleAtual>();
					explicacaoControleAtual.alternarTextoExplicacaoControles();
				}
			}
		}

		private void Changer_normal ( Tile_by_jandson entrada )
		{
			if(itemMoverBlocoLivremente.jogadorUsouItem() == true)
			{
				Changer_easy(entrada);//puzzle funciona como modo facil
			}
			else
			{
				int temp = 0;
				for (int i = 0; i < 9; i++)
				{
					if (entrada == ordem[i])
					{temp = i;}
				}
				if (temp % 3 < 2 && ordem [temp + 1].getAcao () == "")
				{ordem[temp + 1].setAcao(ordem[temp].getAcao());ordem[temp].setAcao("");}
				else if (temp % 3 > 0 && ordem [temp - 1].getAcao () == "")
				{ordem[temp - 1].setAcao(ordem[temp].getAcao());ordem[temp].setAcao("");}
				else if (temp > 2 && ordem [temp - 3].getAcao () == "")
				{ordem[temp - 3].setAcao(ordem[temp].getAcao());ordem[temp].setAcao("");}
				else if (temp < 6 && ordem [temp + 3].getAcao () == "")
				{ordem[temp + 3].setAcao(ordem[temp].getAcao());ordem[temp].setAcao("");}

			}

		}

		// Update is called once per frame
		void Update () {
		}

		public void pegarPosicoesAntesRestast()
		{
			if(ordem != null)
			{
				//falta pegar os nomes dos tiles em ordem
				acoesDosTilesEmOrdem = new String[ordem.Length];
				for(int j = 0; j < ordem.Length; j++)
				{
					acoesDosTilesEmOrdem[j] = ordem[j].getAcao();
				}
				
				DontDestroyOnLoad(this);
			}
			
		}
	}
}