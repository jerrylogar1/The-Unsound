using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_Uli_Musical2 : MonoBehaviour {

	public bool changeTheSoundOfMusic;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		changeTheSoundOfMusic = false;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D (Collider2D col) {
		if(col.tag == "player") {
			if (changeTheSoundOfMusic) {
				audio.Stop ();
				print ("Stop2");
				changeTheSoundOfMusic = false;
			} else {
				audio.Play ();
				print ("Play2");
				changeTheSoundOfMusic = true;
			}
		}
	}
}
