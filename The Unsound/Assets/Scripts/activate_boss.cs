using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_boss : MonoBehaviour {
	
	public BossBehaviourr boss;
	int count = 0;

	void OnTriggerEnter2D(Collider2D externalObject)
	{
		Debug.Log (externalObject.name);
		if (externalObject.tag == "Player" && count < 1) {
			count = count + 1;
			boss.bossStatus = BossBehaviourr.Status.CONFRONT;
		}
	}
	// Update is called once per frame
	void Update () {


	}
}
