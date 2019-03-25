using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCamera : MonoBehaviour
{
	public Transform mainCamera;

	void Start()
	{
		if (!mainCamera)
			this.mainCamera = Camera.main.transform;
	}

	void Update()
	{
		this.transform.LookAt(mainCamera.position, Vector3.up);
	}
}
