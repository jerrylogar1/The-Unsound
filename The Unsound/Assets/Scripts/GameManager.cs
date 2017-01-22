using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject osciloscope;

	private GameObject closeEnemy;

	public GameObject token;

	public Canvas c;

	private Image[] tokens;

	public GameObject[] totems;

	private static GameManager instance = null;

	public static GameManager Instance
	{
		get
		{ 
			return instance; 
		}
	}

	private void Awake()
	{
		// if the singleton hasn't been initialized yet
		if (instance != null && instance != this) 
		{
			Destroy(this.gameObject);
		}

		instance = this;
		DontDestroyOnLoad( this.gameObject );
	}

	// Use this for initialization
	void Start () {
		tokens =
			c.GetComponentsInChildren<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enemyClose(GameObject g){
		osciloscope.BroadcastMessage("newEnemy");
		closeEnemy = g;
	}

	public void enemyLeft(){
		osciloscope.BroadcastMessage("delEnemy");
	}

	public void enemyDead(){
		closeEnemy.SendMessage ("dead");
		StartCoroutine ("SpawnToken");
	}

	public void endGame (){
		SceneManager.LoadScene("GameOntheOver");
	}

	IEnumerator SpawnToken(){
		yield return new WaitForSeconds (5);


		int id = closeEnemy.GetComponent<Enemy> ().id;

		GameObject newToken = Instantiate (token, closeEnemy.transform.position, new Quaternion());

		switch(id) {

		case 0://Verde
			tokens [id].color = new Color (1, 1, 1);
			Destroy(totems [id]);
			break;
		case 1://Morado
			tokens [id].color = new Color (0.60f, 0.13f, 0.79f);
			newToken.GetComponent<SpriteRenderer> ().color = new Color (0.60f, 0.13f, 0.79f);
			Destroy(totems [id]);
			break;
		case 2://Rosa
			tokens [id].color = new Color (0.89f,0.09f,0.52f);
			newToken.GetComponent<SpriteRenderer> ().color = new Color (0.89f,0.09f,0.52f);
			Destroy(totems [id]);
			break;
		case 3://Azul
			tokens [id].color = new Color (0.40f,0.49f,0.9f);
			newToken.GetComponent<SpriteRenderer> ().color = new Color (0.40f,0.49f,0.9f);
			Destroy(totems [id]);
			break;
		default://Boss
			print("Ganaste");
			break;

		}
		Destroy (closeEnemy);
	}
}
