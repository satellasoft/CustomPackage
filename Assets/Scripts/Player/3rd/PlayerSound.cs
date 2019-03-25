using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
	public AudioClip[] footstepSounds;

	private AudioSource audioSource;

	private void Start()
	{
		this.audioSource = GetComponent<AudioSource>();
	}

	public void PlaySound()
	{
		this.audioSource.clip = this.footstepSounds[Random.Range(0, this.footstepSounds.Length)];
		this.audioSource.Play();
	}
}
