﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	private int segundos;
	private int horas;
	private int minutos;
	public GUIText timer;

	void Start()
	{
		horas = 0;
		minutos = 0;
		segundos = 0;
		StartCoroutine (aumentarOTempo());
	}
	
	IEnumerator aumentarOTempo()
	{
		while (true) 
		{
				yield return new WaitForSeconds (1);
				segundos = segundos + 1;
				if(segundos > 59)
				{
					minutos = minutos + 1;
					segundos = 0;
				}	
				
				if(minutos > 59)
				{
					minutos = 0;
					horas = horas + 1;
				}
				
				string segundosEmString = segundos.ToString();
				if(segundos < 10)
				{
					segundosEmString = "0" + segundosEmString;
				}
				
				string minutosEmString = minutos.ToString();
				if(minutos < 10)
				{
					minutosEmString = "0" + minutosEmString;
				}

				timer.text = horas.ToString () + ":" + minutosEmString + ":" + segundosEmString;

			if(minutos == 1 && segundos > 30)
			{
				//eh para dar o item ao usuario. Para isso, Timer deve conhecer a classe do item que phillip estah criando
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}




}
