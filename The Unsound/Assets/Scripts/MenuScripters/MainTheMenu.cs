using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainTheMenu : MonoBehaviour {

	public bool isStart;
	public bool isSettings;
	public bool isEnd;
	public bool isMain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp () {
		if (isStart) {
			SceneManager.LoadScene("GameScene");
			GetComponent<Renderer> ().material.color = Color.cyan;
		}

		if (isSettings) {
			SceneManager.LoadScene ("SettingsMenu");
			GetComponent<Renderer> ().material.color = Color.cyan;
		}

		if (isMain) {
			SceneManager.LoadScene ("Menu");
			GetComponent<Renderer> ().material.color = Color.cyan;
		}

		if (isEnd) {
			Application.Quit();
			GetComponent<Renderer> ().material.color = Color.cyan;
		}
	}
}
