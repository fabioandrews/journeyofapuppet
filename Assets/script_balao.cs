using UnityEngine;
using System.Collections;

public class script_balao : MonoBehaviour {

	public float segBalaoAparecer;
	public float segBalaoDesaparecer;
	public SpriteRenderer spriteDesaparecer;
	public script_texto_balao textoDoBalao;
	// Use this for initialization
	void Start () {
		spriteDesaparecer.color = new Color (1f, 1f, 1f, 0f);//sprite invisivel no comeco
		StartCoroutine("showBaloon");
	}
	IEnumerator showBaloon()
	{
		while (true) 
		{
			yield return new WaitForSeconds(segBalaoAparecer);
			//Debug.Log("showBaloon chamada");

			spriteDesaparecer.color = new Color (1f, 1f, 1f, 1f);
			textoDoBalao.StartCoroutine("fazerTextoAparecer");
			//Debug.Log("balao ficou visivel");
			yield return new WaitForSeconds(segBalaoDesaparecer);
			textoDoBalao.fazerTextoDesaparecer();
			spriteDesaparecer.color = new Color (1f, 1f, 1f, 0f);

			//Debug.Log("balao ficou invisivel");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
