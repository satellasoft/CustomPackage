using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMotor : MonoBehaviour
{
	public Vector3 axis = Vector3.up;

	void Update()
	{
		this.transform.Rotate(axis * Time.deltaTime);
	}
}
