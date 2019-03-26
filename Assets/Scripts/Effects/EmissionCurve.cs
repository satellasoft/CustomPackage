using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionCurve : MonoBehaviour
{
	public new Light light;
	public AnimationCurve animationCurve;
	public Color color;
	public float multiplyIntensity = 1.0f;

	public WrapMode wrapmode = WrapMode.PingPong;
	private Material emissiveMaterial;

	private void Start()
	{
		this.animationCurve.postWrapMode = this.wrapmode;
		this.emissiveMaterial = this.GetComponent<Renderer>().material;
	}

    void Update()
    {
		float value = animationCurve.Evaluate(Time.time);

		if (this.light)
		{
			this.light.color = this.color;
			this.light.intensity = value * multiplyIntensity;
		}
		

		
		this.emissiveMaterial.SetColor("_EmissionColor", this.color * value);
	}
}
