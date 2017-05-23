using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RECharacterController : MonoBehaviour 
{
	public float walkingSpeed = 6f;
	public float strafingSpeed = 3f;
	public float maxJumpHeight = 4f;
	public float minJumpHeight = 2f;
	
	private CharacterController controller;
	private Vector3 moveInput;
	private Vector3 maxYVelocity;
	private Vector3 minYVelocity;
	private Vector3 yVelocity;
	private float gravity = -16f;

	private Vector3 targetSpeed;

	void Start()
	{
		controller = GetComponent<CharacterController>();
		minYVelocity = Vector3.up * Mathf.Sqrt(-2 * gravity * minJumpHeight);
	}

	void Update()
	{	
		moveInput = transform.right * Input.GetAxis("Horizontal") * strafingSpeed + transform.forward * Input.GetAxis("Vertical") * walkingSpeed;
		yVelocity += Vector3.up * gravity * Time.deltaTime;

		if (controller.isGrounded)
		{
			yVelocity = Vector3.up * -0.01f;
			if (Input.GetKey(KeyCode.Space))
			{
				yVelocity = Vector3.up * Mathf.Sqrt(-2 * gravity * maxJumpHeight);
			}
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (yVelocity.y > minYVelocity.y)
				yVelocity = minYVelocity;
		}

		controller.Move((moveInput + yVelocity) * Time.deltaTime);
	}


}

