using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int id = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void dead(){
		StartCoroutine ("Fade");
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<CircleCollider2D> ().enabled = false;
	}

	IEnumerator Fade() {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();

		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = sr.material.color;
			c.a = f;
			sr.material.color = c;
			yield return new WaitForSeconds(0.5f);
		}
	}
}
