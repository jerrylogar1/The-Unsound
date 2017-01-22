using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMe2 : MonoBehaviour {

	private SpriteRenderer spriteRenderer; 
	private int panditas = 0;

	public GameObject uno;
	public GameObject dos;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp () {
		if (panditas > 1) {
			print ("I'm here 2");
			spriteRenderer.enabled = true;
		} else {
			print ("close");
			panditas++;
		}
	}
}
