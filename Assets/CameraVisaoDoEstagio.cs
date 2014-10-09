using UnityEngine;
using System.Collections;

public class CameraVisaoDoEstagio : MonoBehaviour {
	public float speed = 5.0f;
	private Vector3 posicaoInicial;
	// Use this for initialization
	void Start () {
		posicaoInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
		}
	
	}

	public void fazerCameraVoltarAPosicaoInicial()
	{
		transform.position = posicaoInicial;
	}
}
