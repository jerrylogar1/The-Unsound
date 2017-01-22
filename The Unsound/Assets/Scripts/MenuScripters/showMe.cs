using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMe : MonoBehaviour {

	private SpriteRenderer spriteRenderer; 

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp () {
		print ("I'm here");
		spriteRenderer.enabled = true;
	}
}
