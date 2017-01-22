using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private Animator animator;
	private float speed;
	private Rigidbody2D rb;
	[HideInInspector]
	public int playerDirection;
	bool isMoving;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float hDirection, vDirection;
		hDirection = Input.GetAxis ("Horizontal");
		vDirection = Input.GetAxis ("Vertical");
		Vector2 movementVector;

		//print (hDirection);

		if (hDirection != 0 || vDirection != 0) {
			movementVector = new Vector2 (hDirection, vDirection);
			movementVector = movementVector.normalized*.04f; 

		} 
		else 
		{
			isMoving = false;
			movementVector = new Vector2 (0, 0);
		}

		//animator.SetInteger ("Direction", playerDirection);
		//animator.SetBool ("Moving", isMoving);

		if (Input.GetKey (KeyCode.W)) {	//Arriba
			playerDirection = 0;
			isMoving = true;
		}
		if (Input.GetKey (KeyCode.A)) {	//Izq
			playerDirection = 3;
			isMoving = true;
		}
		if (Input.GetKey (KeyCode.S)) {	//Abajo
			playerDirection = 2;
			isMoving = true;
		}
		if (Input.GetKey (KeyCode.D)) {	//Derecha
			playerDirection = 1;
			isMoving = true;

		}
		if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.A))
			isMoving = false;

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			rb.transform.Translate (movementVector);
		}

		animator.SetInteger ("Direction", playerDirection);
		animator.SetBool ("Moving", isMoving);


	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag.Equals ("Enemy")) {
			GameManager.Instance.enemyClose (col.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag.Equals ("Enemy")) {
			GameManager.Instance.enemyLeft ();
		}
	}
}
