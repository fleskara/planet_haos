using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
	[SerializeField] Transform targetObject;
	[SerializeField] Vector3 cameraOffset;
	[SerializeField] float translationSmoothness;
	[SerializeField] float rotationSmoothness;

	private Vector3 velocity = Vector3.zero;

	void FixedUpdate () {
		
		Vector3 newPosition = targetObject.TransformDirection(cameraOffset);
		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, translationSmoothness);

		Vector3 rotationCorectionVector = new Vector3(-30f, 0f, 0f);
 		Quaternion rotationCorection = Quaternion.Euler(rotationCorectionVector);

		Quaternion targetRotation = Quaternion.LookRotation(-targetObject.up, targetObject.forward) * rotationCorection;
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSmoothness);
	}
}
