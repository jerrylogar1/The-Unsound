using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehaviourr : MonoBehaviour {
	public enum Status
	{
		WAITING,
		CHASE,
		CONFRONT,
		RESET
	}
	public Transform player;
	public 	Status bossStatus;
	[Range(0.0f , 5.0f)]
	public float bossSpeed;

	private Vector3 startingPoint;
	private bool executeMovemnt;
	Coroutine myCoroutine;
	// Use this for initialization
	void Start () {
		startingPoint = transform.position;
	}
	
	// Update is called once per frame

	IEnumerator funcionCansada()
	{
		Debug.Log ("YA ME VOY A DORMIR");
		//Desactivar contralador de personaje, hacer el paneo
		yield return new WaitForSeconds (1.5f);
		//Regresar la camara al player y reactivar controlador
		bossStatus = Status.CHASE;
		myCoroutine = null;
	}

	void Update () {
		//print (bossStatus);
		switch(bossStatus)
		{	
		case Status.WAITING:
			{
				
			}
			break;
		case Status.CONFRONT:
			{
				if (myCoroutine == null) 
				{
					myCoroutine = StartCoroutine (funcionCansada ());
					//Paneo de la cámara
				}
				
			}break;
		case  Status.CHASE:
			{
				
				transform.position = Vector2.Lerp (transform.position, player.position, bossSpeed*Time.deltaTime);
				float distance = Vector2.Distance (transform.position, player.position);
				Debug.Log (distance);
				if (distance > 3.5f) {//SE ALEJO
					bossStatus = Status.RESET;
				} 
				else if (distance < .39f) //PEGA
				{
					//RESET AL MENU  PRINCIPAL
					Application.LoadLevel(3);
				}
			}
			break;
		case  Status.RESET:
			{
				transform.position = Vector2.Lerp (transform.position, startingPoint, bossSpeed);
				if (transform.position == startingPoint) {
					bossStatus = Status.WAITING;
				}
			}
			break;
		}
	}
}
