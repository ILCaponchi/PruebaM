using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger_0 : MonoBehaviour {

	public DoorController_0 targetDoor;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			targetDoor.OpenDoor(true);
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			targetDoor.OpenDoor(false);
	}
}
