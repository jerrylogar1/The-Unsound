using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject osciloscope;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enemyClose(){
		osciloscope.BroadcastMessage("newEnemy");
	}

	public void enemyLeft(){
		osciloscope.BroadcastMessage("delEnemy");
	}
}
