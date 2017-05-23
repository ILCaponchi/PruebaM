using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RECameraController : MonoBehaviour 
{
	public bool lockCursor = true;
	public float mouseSensitivity = 6f;
	public float minRot = -45f;
	public float maxRot = 45f;
	public float rotLerpTime = 3f;
	public float pivotPositionSmoothTime = 0.1f;
	public Vector3 pivotOffset = new Vector3(1.5f, 1.5f, -0.5f);
	public float distanceFromTarget = 5f;
	public Transform cameraPivot;

	private Vector3 currentRotation;
	private Transform camTarget;
	private Vector3 pivotDesiredPosition;
	private Vector3 pivotDesiredRotation;
	private Vector2 camInput;
	private float yaw; //rotacion en eje y
	private float pitch; //rotacion en eje x

	private Vector3 currentPivotPosVelocity;
	private Vector3 rotSmoothVelocity;


	void Start()
	{	
		if (lockCursor)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		camTarget = GameObject.FindWithTag("Player").transform;
	}

	void Update()
	{
		camInput = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
	}

	void LateUpdate()
	{	
		//Rotation
//		pivotDesiredRotation = camTarget.localRotation.eulerAngles;
//		currentRotation = Vector3.SmoothDamp(cameraPivot.localRotation.eulerAngles, pivotDesiredRotation, ref currentPivotRotVelocity, pivotRotationSmoothTime);
//		cameraPivot.localRotation = Quaternion.Euler(currentRotation);

		pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		pitch = Mathf.Clamp(pitch, minRot, maxRot);
		yaw += Input .GetAxis("Mouse X") * mouseSensitivity;

		Vector3 targetRot = new Vector3(pitch, yaw, 0);
//		currentRotation = Vector3.SmoothDamp(currentRotation, targetRot, ref rotSmoothVelocity, rotSmoothTime);
		currentRotation = Vector3.Lerp(currentRotation, targetRot, Time.deltaTime * rotLerpTime);
		camTarget.localRotation = Quaternion.Euler(0, currentRotation.y, 0);
		cameraPivot.localRotation = Quaternion.Euler(currentRotation);

		//Position
		pivotDesiredPosition = camTarget.position + camTarget.right * pivotOffset.x + Vector3.up * pivotOffset.y + camTarget.forward * pivotOffset.z;
		cameraPivot.position = Vector3.SmoothDamp(cameraPivot.position, pivotDesiredPosition, ref currentPivotPosVelocity, pivotPositionSmoothTime);
	}

	void OnDrawGizmos()
	{
		if (cameraPivot != null)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(cameraPivot.transform.position, 1f);
		}
	}
}
