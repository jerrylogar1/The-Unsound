using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class temp_Uli_Musical_Script : MonoBehaviour {

	public bool changeTheSoundOfMusic;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		changeTheSoundOfMusic = true;
		audio = GetComponent<AudioSource>();
		audio.Play ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D (Collider2D col) {
		if(col.tag == "changer") {
			if (changeTheSoundOfMusic) {
				audio.Stop ();
				print ("Stop1");
				changeTheSoundOfMusic = false;
			} else {
				audio.Play ();
				print ("Play1");
				changeTheSoundOfMusic = true;
			}
		}
	}
}
