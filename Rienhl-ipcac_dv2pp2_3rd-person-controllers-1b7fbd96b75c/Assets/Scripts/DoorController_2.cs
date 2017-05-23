using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class DoorController_2 : MonoBehaviour {

	private Animator animator;
	private bool isOpen = false;
	public KeyCard_Type cardThatOpens;

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
		{
			if (other.GetComponent<CardSlot>().cards.Contains(cardThatOpens))
				OpenDoor(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			OpenDoor(false);
	}
}
