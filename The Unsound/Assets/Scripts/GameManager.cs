using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject osciloscope;

	private GameObject closeEnemy;

	public GameObject token;

	public Canvas c;

	private int enemiesDead = 0;

	private Image[] tokens;

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

	IEnumerator SpawnToken(){
		yield return new WaitForSeconds (5);
		Instantiate (token, closeEnemy.transform.position, new Quaternion());
		Destroy (closeEnemy);
		tokens[enemiesDead].color = new Color (1, 1, 1);
		enemiesDead++;
	}
}
