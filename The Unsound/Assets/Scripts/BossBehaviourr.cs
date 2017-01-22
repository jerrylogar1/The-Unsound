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

	private Animator animator; 

	void Start () {
		animator = GetComponent<Animator> ();
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
				animator.SetBool ("Moving", false);
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

				//this.transform.position.x <= player.transform.position.x
				//this.transform.position.y <= player.transform.position.y
				//Mathf.Abs(this.transform.position.x - player.transform.position.x);
				float auxx;
				float auxy;
				auxx = this.transform.position.x - player.transform.position.x;
				auxy=this.transform.position.y - player.transform.position.y;
				if (Mathf.Abs (auxx) <= Mathf.Abs (auxy)) {//Vertical

					if (auxy > 0) {
						animator.SetInteger ("Direction", 0);
						animator.SetBool ("Moving", true);
					} else {
						animator.SetInteger ("Direction", 3);
						animator.SetBool ("Moving", true);
					}
				} else { //horizonal
					if (auxx > 0) {
						animator.SetInteger ("Direction", 2); //Derecha
						animator.SetBool ("Moving", true);
					} else {
						animator.SetInteger ("Direction", 1);
						animator.SetBool ("Moving", true);
					}
				}
					

				//movimiento
				transform.position = Vector2.Lerp (transform.position, player.position, bossSpeed*Time.deltaTime); 

				float distance = Vector2.Distance (transform.position, player.position); //calcula distacia
				//Debug.Log (distance);

				if (distance > 3.5f) {//revisa distancia si se alejo
					bossStatus = Status.RESET; //resetea jefe
				} 
				else if (distance < .39f) // revisa distancia si se acerco
				{
					//Application.LoadLevel(3);//pierdes y resetea nivel
					SceneManager.LoadScene("Menu");
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


/*

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag.Equals("Enemy")){
			GameManager.Instance.enemyClose (col.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag.Equals("Enemy")){
			GameManager.Instance.enemyLeft ();
		}
	}
}

  
  
 
 * */