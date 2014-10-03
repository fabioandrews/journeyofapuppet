using UnityEngine;
using System.Collections;

public class BalaoDeFala : MonoBehaviour {

	public float segBalaoAparecer;
	public float segBalaoDesaparecer;
	public SpriteRenderer spriteDesaparecer;//sprite do balao
	public script_texto_balao textoDoBalao;
	public bool personagemEmMomentoDeAcao = false;
	// Use this for initialization


	//Copiado do script_texto_balao
	public Transform target;  // Object that this label should follow. NAO ESTA FUNCIONANDO AINDA
	public Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default
	public bool clampToScreen = false;  // If true, label will be visible even if object is off screen
	public float clampBorderSize = 0.05f;  // How much viewport space to leave at the borders when a label is being clamped
	public bool useMainCamera = true;   // Use the camera tagged MainCamera
	public Camera cameraToUse ;   // Only use this if useMainCamera is false
	Camera cam ;
	Transform thisTransform;
	Transform camTransform;

	void Start () {
		spriteDesaparecer.color = new Color (1f, 1f, 1f, 0f);//sprite invisivel no comeco
		thisTransform = transform;
		if (useMainCamera)
			cam = Camera.main;
		else
			cam = cameraToUse;
		camTransform = cam.transform;
		StartCoroutine("showBaloon");
	}
	IEnumerator showBaloon()
	{
		while (true) 
		{
			yield return new WaitForSeconds(segBalaoAparecer);
			//Debug.Log("showBaloon chamada");

			spriteDesaparecer.color = new Color (1f, 1f, 1f, 1f);
			textoDoBalao.StartCoroutine("fazerTextoQualquerAparecer");
			//Debug.Log("balao ficou visivel");
			int segundosPassados = 0;
			while(personagemEmMomentoDeAcao == false && segundosPassados < segBalaoDesaparecer)
			{
				yield return new WaitForSeconds(1);
				segundosPassados = segundosPassados + 1;
			}
			textoDoBalao.fazerTextoDesaparecer();
			spriteDesaparecer.color = new Color (1f, 1f, 1f, 0f);

			//Debug.Log("balao ficou invisivel");
		}

	}

	IEnumerator showBaloonOnImpact(string qualOObjetoDeImpacto)
	{

			//Debug.Log("showBaloonOnImpact chamada");
			
			spriteDesaparecer.color = new Color (1f, 1f, 1f, 1f);
			textoDoBalao.StartCoroutine("fazerBalaoAparecerNoImpacto", qualOObjetoDeImpacto);
			//Debug.Log("balao ficou visivel");
			int segundosPassados = 0;
			while(segundosPassados < segBalaoDesaparecer)
			{
				yield return new WaitForSeconds(1);
				segundosPassados = segundosPassados + 1;
			}
			textoDoBalao.fazerTextoDesaparecer();
			spriteDesaparecer.color = new Color (1f, 1f, 1f, 0f);
			
			//Debug.Log("balao ficou invisivel");
			this.personagemEmMomentoDeAcao = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (clampToScreen)
		{
			Vector3 relativePosition = camTransform.InverseTransformPoint(target.position);
			relativePosition.z =  Mathf.Max(relativePosition.z, 1.0f);
			thisTransform.position = cam.WorldToViewportPoint(camTransform.TransformPoint(relativePosition + offset));
			thisTransform.position = new Vector3(Mathf.Clamp(thisTransform.position.x, clampBorderSize, 1.0f - clampBorderSize),
			                                     Mathf.Clamp(thisTransform.position.y, clampBorderSize, 1.0f - clampBorderSize),
			                                     thisTransform.position.z);
			
		}
		else
		{
			thisTransform.position = cam.WorldToViewportPoint(target.position + offset);
		}*/
	
	}
}
