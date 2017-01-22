using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class movingDoor : MonoBehaviour

{
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x--;
			this.transform.position = position;
		}
	}
}