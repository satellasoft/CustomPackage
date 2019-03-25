using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
	private Animator animator;

	void Start()
	{
		this.animator = GetComponent<Animator>();
	}

	public void Walk(float vertical, float horizontal)
	{
		this.animator.SetFloat("Vertical", vertical);
		this.animator.SetFloat("Horizontal", horizontal);
	}
}
