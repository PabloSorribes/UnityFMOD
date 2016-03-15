using UnityEngine;
using System.Collections;

public class LightTrigger : MonoBehaviour
{
	public GameObject[] activate;
	public GameObject[] deactivate;
	public float ambientIntensity;

	void OnTriggerEnter()
	{
		foreach (GameObject go in activate)
		{
			go.SetActive(true);
		}
		foreach (GameObject go in deactivate)
		{
			go.SetActive(false);
		}

		RenderSettings.ambientIntensity = ambientIntensity;

		Destroy (gameObject);
	}
}
