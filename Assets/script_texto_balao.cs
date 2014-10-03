using UnityEngine;
using System.Collections;

public class script_texto_balao : MonoBehaviour {

	public Transform target;  // Object that this label should follow
	public Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default
	public bool clampToScreen = false;  // If true, label will be visible even if object is off screen
	public float clampBorderSize = 0.05f;  // How much viewport space to leave at the borders when a label is being clamped
	public bool useMainCamera = true;   // Use the camera tagged MainCamera
	public Camera cameraToUse ;   // Only use this if useMainCamera is false
	Camera cam ;
	Transform thisTransform;
	Transform camTransform;

	public string[] frasesBonecoParado;//{"VAI LOGO!", "PENSA BEM, VIU?", "EU V� MORR�!", "EU J� ERA!", "T� PENSANDO DEMAIS!BORA!"};

	public BalaoDeFala balaoDeFala;

	// Use this for initialization
	void Start () {
		frasesBonecoParado = new string[5];//{"VAI LOGO!", "PENSA BEM, VIU?", "EU V� MORR�!", "EU J� ERA!", "T� PENSANDO DEMAIS!BORA!"};
		frasesBonecoParado[0] = "VAI LOGO!";
		frasesBonecoParado[1] = "PENSA BEM!";
		frasesBonecoParado[2] = "V� MORR�";
		frasesBonecoParado[3] = "EU J� ERA!";
		frasesBonecoParado[4] = "BORA!";
		thisTransform = transform;
		if (useMainCamera)
			cam = Camera.main;
		else
			cam = cameraToUse;
		camTransform = cam.transform;
		guiTextTextoModificar.color = new Color (255, 0, 0, 0f);//texto vermelho, mas invisivel
	
	}

	public GUIText guiTextTextoModificar;

	public IEnumerator fazerTextoQualquerAparecer ()
	{
		//Debug.Log ("fazerTexroAparecer chamado");
		double fontsize = 18;//bote aqui 0 se quiser o efeito da letra pequenininha e aumenta
		//Debug.Log ("size=" + frasesBonecoParado.Length);
		int indiceNovaFraseDoBoneco = Random.Range (0, frasesBonecoParado.Length - 1);
		//Debug.Log ("indice=" + indiceNovaFraseDoBoneco);
		guiTextTextoModificar.text = frasesBonecoParado [indiceNovaFraseDoBoneco];
		guiTextTextoModificar.color = new Color (255, 0, 0, 1f);
		//texto vermelho, mas visivel
		float secondsInAnimation = 0;
		while (secondsInAnimation < balaoDeFala.segBalaoDesaparecer) {
			if (fontsize < 18) {
				yield return new WaitForSeconds (0.10f);
				secondsInAnimation = secondsInAnimation + 0.10f;
				//Debug.Log ("secondsInAnimation=" + secondsInAnimation);
				fontsize += 2;
				this.guiTextTextoModificar.fontSize = (int)fontsize;
			}
			else {
				yield return new WaitForSeconds (0.10f);
				secondsInAnimation = secondsInAnimation + 0.10f;
				//Debug.Log ("secondsInAnimation=" + secondsInAnimation);
				fontsize -= 2;
				this.guiTextTextoModificar.fontSize = (int)fontsize;
			}
		}

	}

	public void fazerTextoDesaparecer()
	{
		guiTextTextoModificar.color = new Color (255, 0, 0, 0f);//texto vermelho, mas invisivel
	}

	public IEnumerator fazerBalaoAparecerNoImpacto(string noQuePersonagemTocou)
	{
		//Debug.Log("fazerBalaoAparecerNoImpacto chamada");
		string mensagemAparecerNoBalao = "";
		if(noQuePersonagemTocou.Contains("inimigo") == true)
		{
			mensagemAparecerNoBalao = "SEU IN�TIL!";
		}
		else if(noQuePersonagemTocou.Contains("buraco") == true)
		{
			mensagemAparecerNoBalao = "V� CAIR, ANTA!";
		}
		//fazer balao aparecer no impacto por tempoAteBalaoDesaparecer segundos
		guiTextTextoModificar.text = mensagemAparecerNoBalao;
		guiTextTextoModificar.color = new Color (255, 0, 0, 1f);
		//fazer anima�ao texto oscilar por um tempo
		float secondsInAnimation = 0;
		double fontsize = 18;
		while (secondsInAnimation < balaoDeFala.segBalaoDesaparecer) {
			if (fontsize < 18) {
				yield return new WaitForSeconds (0.10f);
				secondsInAnimation = secondsInAnimation + 0.10f;
				//Debug.Log ("secondsInAnimation=" + secondsInAnimation);
				fontsize += 2;
				this.guiTextTextoModificar.fontSize = (int)fontsize;
			}
			else {
				yield return new WaitForSeconds (0.10f);
				secondsInAnimation = secondsInAnimation + 0.10f;
				//Debug.Log ("secondsInAnimation=" + secondsInAnimation);
				fontsize -= 2;
				this.guiTextTextoModificar.fontSize = (int)fontsize;
			}
		}

	}






	
	
	
	// Update is called once per frame
	void Update () {
		if (clampToScreen)
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
		}
	
	}
}
