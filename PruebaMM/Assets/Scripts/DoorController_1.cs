using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController_1 : MonoBehaviour {

	private Animator animator;
	private bool isOpen = false;

	void Start () 
	{
		animator = GetComponentInChildren<Animator>();
	}

	public void OpenDoor(bool willOpen = true)
	{
		if (willOpen != isOpen)
		{
			isOpen = willOpen;
			animator.SetBool("opened", isOpen);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			OpenDoor(true);
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			OpenDoor(false);
	}
}
