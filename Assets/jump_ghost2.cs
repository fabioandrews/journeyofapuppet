using UnityEngine;
using System.Collections;

public class jump_ghost2 : MonoBehaviour 
{
	public Vector3 displacement;
	// Use this for initialization
	void Start () 
	{
	
	}

	public void andar()
	{
		transform.Translate(displacement);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.Translate(displacement); FAZ PERSONAGEM ANDAR PRA DIREITA CASO VOCE ALTERE X NO DISPLACEMENT NO inspector do objeto
		if (Input.GetKey (KeyCode.Space)) 
		{
			rigidbody2D.AddForce(new Vector2(0.0f,50.0f));
		}
	}
	 
}
