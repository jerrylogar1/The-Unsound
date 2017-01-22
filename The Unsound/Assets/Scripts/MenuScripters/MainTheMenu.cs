using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainTheMenu : MonoBehaviour {

	public bool isStart;
	public bool isCredits;
	public bool isEnd;
	public bool isMain;
	public bool isGame;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp () {
		if (isStart) {
			SceneManager.LoadScene("InstructionScene");
			GetComponent<Renderer> ().material.color = Color.cyan;
		}

		if (isCredits) {
			SceneManager.LoadScene ("CreditsMenu");
			GetComponent<Renderer> ().material.color = Color.cyan;
		}

		if (isMain) {
			SceneManager.LoadScene ("Menu");
			GetComponent<Renderer> ().material.color = Color.cyan;
		}

		if (isGame) {
			SceneManager.LoadScene ("AndyScene");
			GetComponent<Renderer> ().material.color = Color.cyan;
		}

		if (isEnd) {
			Application.Quit();
			GetComponent<Renderer> ().material.color = Color.cyan;
		}
	}
}
