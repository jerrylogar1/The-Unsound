using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class theButtton : MonoBehaviour {

	private int state;
	/*
	 * 0 = no dynamics
	 * 1 = one
	 * 2 = two
	 * 3 = game
	 */
	public GameObject uno;
	public GameObject dos;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		state = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp () {
		switch (state) {
		case 0:
			state++;
			break;
		case 1:
			state++;
			spriteRenderer = uno.GetComponent<SpriteRenderer> ();
			spriteRenderer.enabled = true;
			break;
		case 2:
			state++;
			spriteRenderer = dos.GetComponent<SpriteRenderer>();
			spriteRenderer.enabled = true;
			break;
		case 3:
			SceneManager.LoadScene ("Main");
			GetComponent<Renderer> ().material.color = Color.cyan;
			break;
		}
		print (state);
	}
}
