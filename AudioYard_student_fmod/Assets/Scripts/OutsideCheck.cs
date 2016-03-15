using UnityEngine;
using System.Collections;

public class OutsideCheck : MonoBehaviour {

	public float ambientOutside;
	public float ambientInside;
	public GameObject dirLight;
	private bool outside = false;

	void OnTriggerExit()
	{
		if (outside == false)
		{
			RenderSettings.ambientIntensity = ambientOutside;
			dirLight.SetActive(true);
			outside = true;
		}
		else 
		{
			RenderSettings.ambientIntensity = ambientInside;
			dirLight.SetActive(false);
			outside = false;
		}
	}
}
