using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollyBack : MonoBehaviour {

	public float scrollSpeed = 0.5f;
	public float offset;
	public float rotate;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		offset+= (Time.deltaTime /* *scrollSpeed */)/10.0f;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset,0));
	}
}
