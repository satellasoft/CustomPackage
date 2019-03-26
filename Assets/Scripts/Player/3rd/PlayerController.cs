using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]

[RequireComponent(typeof(PlayerAnimations))]
[RequireComponent(typeof(PlayerSound))]
public class PlayerController : MonoBehaviour
{

	public bool control = true;
	public float rotateSpeed = 8.0f;

	private CharacterController characterController;
	private PlayerAnimations playerAnimations;

	private float vertical = 0;
	private float horizontal = 0;

	void Start()
	{
		this.characterController = GetComponent<CharacterController>();
		this.playerAnimations = GetComponent<PlayerAnimations>();
	}

	void Update()
	{
		if (!control)
			return;

		this.Motor();
	}

	private void Motor()
	{
		this.vertical = Input.GetAxis("Vertical");
		this.horizontal = Input.GetAxis("Horizontal");

		if (this.vertical > 0 && Input.GetKey(KeyCode.LeftShift))
		{
			this.vertical *= 2;
		}

		this.playerAnimations.Walk(vertical, horizontal);

		if (this.vertical != 0)
		{
			Vector3 fwd = Camera.main.transform.forward;
			fwd.y = 0;
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(fwd.normalized), rotateSpeed * Time.deltaTime);
		}

		if (!this.characterController.isGrounded)
			this.characterController.Move(new Vector3(0, -1, 0));
	}
}
