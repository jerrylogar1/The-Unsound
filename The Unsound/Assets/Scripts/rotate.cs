﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(Vector3.forward*1);
		} 
		if(Input.GetKey(KeyCode.RightArrow)){
				transform.Rotate(Vector3.forward*-1f);
		}
		
	}
}
