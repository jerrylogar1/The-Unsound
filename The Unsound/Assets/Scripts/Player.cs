using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Animator animator; 
	private float speed;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		animator.SetBool ("Moving", false);

		if(Input.GetKey(KeyCode.W)){	//Arriba
			animator.SetInteger ("Direction", 0);
			animator.SetBool ("Moving", true);
			rb.transform.Translate (0,0.04f,0);
		}

		if(Input.GetKey(KeyCode.A)){	//Izq
			animator.SetInteger ("Direction", 3);
			animator.SetBool ("Moving", true);
			rb.transform.Translate (-0.04f,0,0);
		}

		if(Input.GetKey(KeyCode.S)){	//Abajo
			animator.SetInteger ("Direction", 2);
			animator.SetBool ("Moving", true);
			rb.transform.Translate (0,-0.04f,0);
		}

		if(Input.GetKey(KeyCode.D)){	//Derecha
			animator.SetInteger ("Direction", 1);
			animator.SetBool ("Moving", true);
			rb.transform.Translate (0.04f,0,0);
		}
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
