using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCamera : MonoBehaviour
{
	public float speed = 50.0f;
	public float[] clampY = new float[2] { 20, 80 };

	private float mouseY = 0;

	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		this.mouseY += (Input.GetAxis("Mouse Y") * speed) * Time.deltaTime;
		this.mouseY = Mathf.Clamp(this.mouseY, clampY[0], clampY[1]);

		Vector3 rotCamera = transform.rotation.eulerAngles;
		rotCamera.x = -mouseY;
		rotCamera.z = 0;

		transform.rotation = Quaternion.Euler(rotCamera);
	}
}
