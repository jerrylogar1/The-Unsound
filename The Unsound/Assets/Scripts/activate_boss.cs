using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_boss : MonoBehaviour {
	
	public BossBehaviourr boss;

	void OnTriggerEnter2D(Collider2D externalObject)
	{
		Debug.Log (externalObject.name);
		if (externalObject.tag.Equals("Player") &&
			boss.bossStatus == BossBehaviourr.Status.WAITING) 
		{
			boss.bossStatus = BossBehaviourr.Status.CONFRONT;
		}
	}
	// Update is called once per frame
	void Update () {


	}
}
