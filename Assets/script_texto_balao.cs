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

	public string[] frasesBonecoParado;//{"VAI LOGO!", "PENSA BEM, VIU?", "EU VÔ MORRÊ!", "EU JÁ ERA!", "TÁ PENSANDO DEMAIS!BORA!"};

	public script_balao balaoDeFala;

	// Use this for initialization
	void Start () {
		frasesBonecoParado = new string[5];//{"VAI LOGO!", "PENSA BEM, VIU?", "EU VÔ MORRÊ!", "EU JÁ ERA!", "TÁ PENSANDO DEMAIS!BORA!"};
		frasesBonecoParado[0] = "VAI LOGO!";
		frasesBonecoParado[1] = "PENSA BEM, VIU?";
		frasesBonecoParado[2] = "EU VÔ MORRÊ";
		frasesBonecoParado[3] = "EU JÁ ERA!";
		frasesBonecoParado[4] = "TÁ PENSANDO DEMAIS!BORA";
		thisTransform = transform;
		if (useMainCamera)
			cam = Camera.main;
		else
			cam = cameraToUse;
		camTransform = cam.transform;
		guiTextTextoModificar.color = new Color (255, 0, 0, 0f);//texto vermelho, mas invisivel
	
	}

	public GUIText guiTextTextoModificar;

	public IEnumerator fazerTextoAparecer ()
	{
		Debug.Log ("fazerTexroAparecer chamado");
		double fontsize = 18;//bote aqui 0 se quiser o efeito da letra pequenininha e aumenta
		Debug.Log ("size=" + frasesBonecoParado.Length);
		int indiceNovaFraseDoBoneco = Random.Range (0, frasesBonecoParado.Length - 1);
		Debug.Log ("indice=" + indiceNovaFraseDoBoneco);
		guiTextTextoModificar.text = frasesBonecoParado [indiceNovaFraseDoBoneco];
		guiTextTextoModificar.color = new Color (255, 0, 0, 1f);
		//texto vermelho, mas visivel
		float secondsInAnimation = 0;
		while (secondsInAnimation < balaoDeFala.segBalaoDesaparecer) {
			if (fontsize < 18) {
				yield return new WaitForSeconds (0.10f);
				secondsInAnimation = secondsInAnimation + 0.10f;
				Debug.Log ("secondsInAnimation=" + secondsInAnimation);
				fontsize += 2;
				this.guiTextTextoModificar.fontSize = (int)fontsize;
			}
			else {
				yield return new WaitForSeconds (0.10f);
				secondsInAnimation = secondsInAnimation + 0.10f;
				Debug.Log ("secondsInAnimation=" + secondsInAnimation);
				fontsize -= 2;
				this.guiTextTextoModificar.fontSize = (int)fontsize;
			}
		}

	}

	public void fazerTextoDesaparecer()
	{
		guiTextTextoModificar.color = new Color (255, 0, 0, 0f);//texto vermelho, mas invisivel
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
