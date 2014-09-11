using UnityEngine;
using System.Collections;


public class pular_animacao : MonoBehaviour {
	public Sprite[] sprites;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % sprites.Length;
			spriteRenderer.sprite = sprites[ index ];
		}

	
	}
}
