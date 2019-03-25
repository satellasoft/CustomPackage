using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToObject : MonoBehaviour
{
	public Transform objectLook;
	public Vector3 axisLook = Vector3.up;
	void Update()
	{
		this.transform.LookAt(objectLook.position, axisLook);
	}
}
