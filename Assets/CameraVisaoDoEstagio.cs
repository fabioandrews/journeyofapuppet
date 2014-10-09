using UnityEngine;
using System.Collections;

public class CameraVisaoDoEstagio : MonoBehaviour {
	public float speed = 5.0f;
	public int posicaoDiretaMaximo; //a camera so pode se deslocar para a direita ateh no maximo essa posicao. Para impedir o usuario de mexer a camera ate onde nao deve
	public int posicaoEsquerdaMaximo; //a camera so pode se deslocar para a esquerda ateh no maximo essa posicao. Para impedir o usuario de mexer a camera ate onde nao deve
	public int posicaoCimaMaximo; //a camera so pode se deslocar para cima ateh no maximo essa posicao. Para impedir o usuario de mexer a camera ate onde nao deve
	public int posicaoBaixoMaximo; //a camera so pode se deslocar para baixo ateh no maximo essa posicao. Para impedir o usuario de mexer a camera ate onde nao deve

	private Vector3 posicaoInicial;
	// Use this for initialization
	void Start () {
		posicaoInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
		{
			if(transform.position.x < posicaoDiretaMaximo)
			{
				transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
			}
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(transform.position.x > posicaoEsquerdaMaximo)
			{
				transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
			}
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			if(transform.position.y > posicaoBaixoMaximo)
			{
				transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
			}
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			if(transform.position.y < posicaoCimaMaximo)
			{
				transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
			}
		}
	
	}

	public void fazerCameraVoltarAPosicaoInicial()
	{
		transform.position = posicaoInicial;
	}
}
