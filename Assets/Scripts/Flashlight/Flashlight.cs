using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

	#region "Variables"
	[Header("CONTROLLER")]
	public float durantionSeconds = 300.0f;
	public bool enableBattery = true;
	public bool startOn = true;
	public KeyCode onKey = KeyCode.F;

	[Header("LIGHT")]
	public new Light light;
	public Color lightColor;
	public float intensityMultiply = 1;

	[Header("AUDIO")]
	public AudioSource audioSource;
	public AudioClip chargeSound;
	public AudioClip[] flashlightSounds;

	private bool on = true;
	private float currentTime;
	private bool effect = false;
	#endregion

	/// <summary>
	/// Start method
	/// </summary>
	void Start()
	{
		if (!this.startOn)
			this.on = false;

		this.currentTime = this.durantionSeconds;
		this.light.color = this.lightColor;
		this.light.intensity = this.intensityMultiply;
	}

	/// <summary>
	/// Update method
	/// </summary>
	void Update()
	{
		
		
		if (this.enableBattery && this.on && this.currentTime >= 0)
		{
			print(this.currentTime);
			this.currentTime -= (1 * Time.deltaTime);
		}

		if (Input.GetKeyDown(this.onKey))
		{
			this.on = !this.on;
			this.PlaySound();
			this.EnableFlashlight();
		}

		this.light.intensity = this.GetIntensity() * this.intensityMultiply;
	}
	
	/// <summary>
	/// Return between 0 and 1
	/// </summary>
	/// <returns></returns>
	public float GetIntensity()
	{
		return (this.currentTime / this.durantionSeconds);
	}

	/// <summary>
	/// Charge the battery
	/// </summary>
	/// <param name="charge"></param>
	public void Charge(float charge = 0)
	{
		if (charge == 0)
			this.currentTime = this.durantionSeconds;
		else
		{
			this.currentTime = (charge <= this.durantionSeconds ? charge : this.durantionSeconds);
		}

		this.audioSource.clip = this.chargeSound;
		this.audioSource.Play();
	}

	/// <summary>
	/// Enable and Disable Light only
	/// </summary>
	private void EnableFlashlight()
	{
		this.light.enabled = this.on;
	}

	/// <summary>
	/// Play random sound click
	/// </summary>
	private void PlaySound()
	{
		this.audioSource.clip = this.flashlightSounds[Random.Range(0, this.flashlightSounds.Length)];
		this.audioSource.Play();
	}
}
