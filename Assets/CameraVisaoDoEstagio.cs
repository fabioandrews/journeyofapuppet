using UnityEngine;
using System.Collections;

public class CameraVisaoDoEstagio : MonoBehaviour {
	public float speed = 5.0f;
	public int posicaoDiretaMaximo; //a camera so pode se deslocar para a direita ateh no maximo essa posicao. Para impedir o usuario de mexer a camera ate onde nao deve
	public int posicaoEsquerdaMaximo; //a camera so pode se deslocar para a esquerda ateh no maximo essa posicao. Para impedir o usuario de mexer a camera ate onde nao deve
	public int posicaoCimaMaximo; //a camera so pode se deslocar para cima ateh no maximo essa posicao. Para impedir o usuario de mexer a camera ate onde nao deve
	public int posicaoBaixoMaximo; //a camera so pode se deslocar para baixo ateh no maximo essa posicao. Para impedir o usuario de mexer a camera ate onde nao deve
	private bool jogadorPodeMexerACameraComTeclado; //esse booleano sera false quando o usuario ainda nao clicou no botao GO e true quando ele clica
	private bool cameraDeveSeguirOBonecoHorizontalmente;

	private Vector3 posicaoInicial;
	// Use this for initialization
	void Start () {
		posicaoInicial = transform.position;
		jogadorPodeMexerACameraComTeclado = true;
		cameraDeveSeguirOBonecoHorizontalmente = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (jogadorPodeMexerACameraComTeclado == true)  
		{
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

		if(cameraDeveSeguirOBonecoHorizontalmente == true)
		{  
			//primeiro vamos achar o puppet
			GameObject puppet = GameObject.Find ("Puppet");
			transform.position = new Vector3(puppet.transform.position.x,this.transform.position.y,this.transform.position.z);
		}

	
	}

	public void fazerCameraVoltarAPosicaoInicial()
	{
		transform.position = posicaoInicial;
	}

	public void fazerCameraNaoPoderSerMaisControladaPeloUsuario()
	{
		this.jogadorPodeMexerACameraComTeclado = false;

		//vamos tirar a imagem e texto que diz que o usuario pode usar as setas para ver o estagio
		GameObject instrucaoUseTecladoParaMoverCamera = GameObject.Find("instrucaoUseTecladoParaMoverCamera");
		DestroyImmediate(instrucaoUseTecladoParaMoverCamera);
	}

	//essa funcao sera chamada pelo button_by_jandson assim que o botao for clicado. Ao inves de fazer a camera se tornar filha do boneco na hierarquia de
	//gameobjects, farei a camera atualizar sua posicao com base no boneco
	public void fazerCameraSeguirPersonagemApenasHorizontalmente()
	{
		this.cameraDeveSeguirOBonecoHorizontalmente = true;
	}
}
