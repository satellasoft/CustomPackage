using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
	public Transform target;
	public Vector3 offset = Vector3.back;
	public float smooth = 5.0f;

	void Update()
	{
		this.transform.position = Vector3.Lerp(this.transform.position, this.target.position + offset, this.smooth * Time.deltaTime);
	}
}
