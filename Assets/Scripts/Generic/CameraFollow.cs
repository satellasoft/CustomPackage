using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smooth = 5.0f;
	public float rotateSpeed = 5.0f;

	private Vector3 cameraOffset;

	private void Start()
	{
		this.cameraOffset = this.transform.position - this.target.position;
	}

	void LateUpdate()
	{

		Quaternion cameraTurn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * this.rotateSpeed, Vector3.up);

		this.cameraOffset = cameraTurn * this.cameraOffset;

		Vector3 newPosition = this.target.position + this.cameraOffset;

		this.transform.position = Vector3.Slerp(this.transform.position, newPosition, this.smooth * Time.deltaTime);
		this.transform.LookAt(this.target);
	}
}
