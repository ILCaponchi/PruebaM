using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class KeyCard : MonoBehaviour {

	public bool animate = true;
	public float rotationSpeed = 5f;
	public Transform cardTransform;
	public KeyCard_Type type;
	
	void Update()
	{
		if (animate)
		{
			Animate();
		}
	}

	private void Animate()
	{
		cardTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			CardSlot cardSlot = other.GetComponent<CardSlot>();
			if (cardSlot == null)
				return;
			if (cardSlot.cards.Contains(type) == false)
				cardSlot.cards.Add(type);
			gameObject.SetActive(false);
		}
	}
}
