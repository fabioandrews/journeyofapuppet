using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
public class GoButton : MonoBehaviour {
	public jump_ghost2 fantasminha;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				if (Input.GetMouseButtonDown (0) == true) {
					fantasminha.andar();
	
				}
		}
}
}