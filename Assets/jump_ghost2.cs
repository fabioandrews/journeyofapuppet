using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class jump_ghost2 : MonoBehaviour 
{
	public Vector3 displacement;
	public Sprite spritePersonagemComum;
	public Sprite spritePersonagemMorreu; //um sprite para quando o sprite atual deve fazer animacao de morrer
	public Sprite spritePersonagemAtacou; //um sprite para quando o personagem ataca um inimigo
	public bool bateuEmAlgo;
	public bool deveAndar;
	Boolean personagemEstaSubindoEscada;
	Boolean personagemVaiAtacarOMonstro; //quando um personagem alcanca o collider mais externo do monstro, 
	//caso a proxima acao seja atacar, esse booleano muda porque quando o personagem estiver colado no monstro,
	//ele ataca!
	private SpriteRenderer spriteRenderer; //cara que muda os sprites do personagem
	public BalaoDeFala balaoDeFala;//NOVO balao que fica seguindo personagem
	public PopupWindowGameOver popupGameOver;//NOVO popup de game over
	public AudioClip sfxBatida;//NOVO sfx batida
	// Use this for initialization
	void Start () 
	{
		bateuEmAlgo = false;
		deveAndar = false;
		personagemEstaSubindoEscada = false;
		personagemVaiAtacarOMonstro = false;
	
	}

	public void andar()
	{
		transform.Translate(displacement);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey (KeyCode.RightArrow))
		{
			transform.Translate(displacement); //FAZ PERSONAGEM ANDAR PRA DIREITA CASO VOCE ALTERE X NO DISPLACEMENT NO inspector do objeto
		}
		//transform.Translate(displacement); FAZ PERSONAGEM ANDAR PRA DIREITA CASO VOCE ALTERE X NO DISPLACEMENT NO inspector do objeto
		if (Input.GetKey (KeyCode.Space)) 
		{
			rigidbody2D.AddForce(new Vector2(0.0f,50.0f));
		}
	}

	void OnCollisionEnter2D(Collision2D col)//ALGO NOVO 
	{
		if (col.gameObject.name.CompareTo("chao") != 0) 
		{
			//o personagem estah o tempo todo batendo no chao, por isso ele n conta
			bateuEmAlgo = true;
			
			if(col.gameObject.name.Contains("inimigo") == true)
			{
				if(personagemVaiAtacarOMonstro == false)
				{
					//uh oh. Ele encostou no monstro e nao vai atacar? Entao morre, descracado!
					//spriteRenderer.sprite = spritePersonagemMorreu;
					//NOVO ANDREWS - BALAO DE MORTE APARECE
					balaoDeFala.personagemEmMomentoDeAcao = true;
					balaoDeFala.StartCoroutine("showBaloonOnImpact", "inimigo");
					popupGameOver.mostrarPopupGameOver = true;
					audio.PlayOneShot(sfxBatida);
					Debug.Log("jump ghost mudou o mostrar popup para true");
				}
			}
		}
	}

	 
}
