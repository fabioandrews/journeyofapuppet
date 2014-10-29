using UnityEngine;
using System.Collections;

public class Item_mover_blocos_livremente : MonoBehaviour {
	private bool possuiItem;
	private bool itemEstahAtivo;
	public Sprite spriteItemDesativado;
	public Sprite spriteItemAtivado;
	public Background_by_jandson sabeSeEstahJogandoNoNivelNormal;//quem gurda esse dado
	public Toast toastDoJogo;//serve pra mostrar infos temporariamente

	// Use this for initialization
	void Start () {
		if(sabeSeEstahJogandoNoNivelNormal.getModoFacil() == false)
		{
			//jogador joga no modo normal...
			possuiItem = false;
			itemEstahAtivo = false;
			mudarIconeDoItem();
		}
		else
		{
			possuiItem = false;
			itemEstahAtivo = false;
			mudarIconeDoItem();
		}
	}

	public void mudarModoDeJogo(string nomeModo)
	{
		if(nomeModo.CompareTo("normal") == 0)
		{
			//jogador joga no modo normal...
			possuiItem = true;
			itemEstahAtivo = false;
			mudarIconeDoItem();
		}
		else
		{
			possuiItem = false;
			itemEstahAtivo = false;
			mudarIconeDoItem();
		}
	}

	public bool jogadorPossuiItem()
	{
		return possuiItem;
	}

	public bool jogadorUsouItem()
	{
		return itemEstahAtivo;
	}

	public void desativarItem()
	{
		this.itemEstahAtivo = false;
	}

	void mudarIconeDoItem()
	{
		if(possuiItem == true)
		{
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = spriteItemAtivado;
		}
		else
		{
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = spriteItemDesativado;
		}
	}

	void OnMouseDown()
	{
		if(possuiItem == true)
		{
			this.toastDoJogo.setTextoToast("Item usado: mova 2 peças livremente");
			this.toastDoJogo.setMostrarToast(true);
			//usuario possui item
			itemEstahAtivo = true;
			possuiItem = false;//perdeu item
			this.mudarIconeDoItem();
			
		}
		
	}

	//funcao serah chamada por Timer, pois depois de 1 minuto e meio, o jogador ganha esse item
	public void fazerJogadorGanharItem()
	{
		if(sabeSeEstahJogandoNoNivelNormal.getModoFacil() == false)
		{
			//jogador estah no modo normal...
			this.possuiItem = true;
			this.mudarIconeDoItem();
		}
	}
	// Update is called once per frame
	void Update () {
		/*if(Input.GetMouseButtonDown(0))
		{
			Debug.Log("OnMouseDown ativado");
			if(possuiItem == true)
			{
				this.toastDoJogo.setTextoToast("jogador usou item");
				this.toastDoJogo.setMostrarToast(true);
				//usuario possui item
				itemEstahAtivo = true;
				possuiItem = false;//perdeu item
				this.mudarIconeDoItem();
				
			}
		}*/
	
	}
}
