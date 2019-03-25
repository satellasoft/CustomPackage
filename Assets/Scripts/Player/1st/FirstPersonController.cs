using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonController : MonoBehaviour
{
	[Header("Keys")]
	public KeyCode runKey = KeyCode.LeftShift;
	public KeyCode jumpKey = KeyCode.Space;

	[Header("Controller")]
	public float speed = 5.0f;
	public float runSpeed = 10.0f;
	public float rotateSpeed = 120.0f;
	public float jumpImpulse = 12.0f;

	private Rigidbody rg;
	private float vertical;
	private float horizontal;
	private float mouseX;
	private float currentSpeed = 0;
	public bool isGrounded;

	void Start()
	{
		this.rg = GetComponent<Rigidbody>();

		this.rg.constraints = RigidbodyConstraints.FreezeRotation;
	}


	void Update()
	{
		this.vertical = Input.GetAxis("Vertical");
		this.horizontal = Input.GetAxis("Horizontal");
		this.mouseX = Input.GetAxis("Mouse X");

		if (Input.GetKey(runKey))
			this.currentSpeed = this.runSpeed;
		else
			this.currentSpeed = this.speed;


		Vector3 newPos = new Vector3((this.horizontal * this.currentSpeed) * Time.deltaTime, 0, (this.vertical * this.currentSpeed) * Time.deltaTime);
		this.rg.MovePosition(this.transform.localPosition + transform.TransformDirection(newPos));

		this.rg.rotation = Quaternion.Euler(this.rg.rotation.eulerAngles + new Vector3(0, (this.mouseX * this.rotateSpeed) * Time.deltaTime, 0));

		if (Input.GetKeyDown(jumpKey) && this.isGrounded)
		{
			this.rg.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
		}
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		this.isGrounded = true;
	}

	void OnCollisionExit(Collision collisionInfo)
	{
		this.isGrounded = false;
	}
}
