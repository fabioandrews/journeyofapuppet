using UnityEngine;
using System.Collections;

public class StartLabel : MonoBehaviour {
	static float larguraLabel = 350;
	static float AlturaLabel = 200;
	public float duracaoAnimacao;
	static float starty = Screen.height;
	static float startTime;
	static float endy = (Screen.height - AlturaLabel)/2;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		float fracTime = (Time.time - startTime) / duracaoAnimacao;
		float yPos = Mathf.Lerp(starty, endy, fracTime);
		if(float.IsNaN(yPos) == false)
		{
			//float nao e vazio
			GUI.Label(new Rect((Screen.width - larguraLabel)/2, yPos, 200, 20), "<color=red><size=20>Get Ready</size></color>");
		}
		Debug.Log("ypos=" + yPos);


	}
	void OnGUI()
	{

	}
}
