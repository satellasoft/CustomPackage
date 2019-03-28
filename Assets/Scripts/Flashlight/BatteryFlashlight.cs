using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryFlashlight : MonoBehaviour
{
	public KeyCode key = KeyCode.E;
	public UnityEngine.UI.Text textButton;
	public GameObject canvas;
	public Flashlight flashlight;
	public string playerTag = "Player";
	public float chargeAmount = 300.0f;
	[Space(10)]
	public bool staticObject = false;

	private new bool collider = false;

	void Start()
	{
		if (staticObject) {
			Destroy(this);
		}
		this.textButton.text = key.ToString();
		this.canvas.SetActive(false);
	}

	void Update()
	{
		if (this.collider && Input.GetKeyDown(key)) {
			this.flashlight.Charge(chargeAmount);
			Destroy(this.gameObject);
		}
	}


	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag(this.playerTag))
		{
			this.collider = true;
			this.canvas.SetActive(true);
		}
	}


	private void OnTriggerExit(Collider col)
	{
		if (col.CompareTag(this.playerTag))
		{
			this.collider = false;
			this.canvas.SetActive(false);
		}
	}
}
