using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Rotate(Vector3.forward*1f);
		} 
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.Rotate(Vector3.forward*-1f);
		}

	}
}
