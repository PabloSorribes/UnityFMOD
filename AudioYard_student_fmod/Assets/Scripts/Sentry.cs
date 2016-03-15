using UnityEngine;
using System.Collections;

public class Sentry : MonoBehaviour 
{
	public Transform rotationControl;
	public float rotationTime = 1;
	public float rotationMaxSpeed = 1;
	
	public GameObject sentryBulletPrefab;
	public float fireRate = 0.5f;
	public Transform muzzleTransform;
	
	public AudioSource rotationAudio;
	public float rotationThreshold = 5;
	
	private Transform target;
	private Transform ownTransform;
	private Vector3 standardEuler = Vector3.zero;
	private float rotationRefVelocity = 0;
	private PickupManager pickupManager;

	public EventPlayer actionMusic;

	void Awake()
	{
		ownTransform = transform;
		standardEuler = rotationControl.eulerAngles;
		pickupManager = FindObjectOfType<PickupManager> ();
	}
	
	void LateUpdate()
	{
		if(target == null)
			return;
		Quaternion dummyRotation = Quaternion.LookRotation(target.position - ownTransform.position, Vector3.up);
		rotationControl.eulerAngles = new Vector3(standardEuler.x, Mathf.SmoothDampAngle(rotationControl.eulerAngles.y, dummyRotation.eulerAngles.y, ref rotationRefVelocity, rotationTime, rotationMaxSpeed), standardEuler.z);
		if (rotationAudio == null) 
		{
			return;
		}
		else
		{
			if (Mathf.Abs (rotationRefVelocity) > rotationThreshold && !rotationAudio.isPlaying)
				rotationAudio.Play ();
		}
	}
	
	public void SetTarget(Transform targetTransform)
	{
		target = targetTransform;
		if(target != null)
		{
			StartCoroutine(FireRoutine());
		}
		else
		{
			if(rotationAudio != null && rotationAudio.isPlaying)
			{
				rotationAudio.Stop();
			}
			StopAllCoroutines();
		}
	}
	
	IEnumerator FireRoutine()
	{
		yield return new WaitForSeconds(fireRate);
		GameObject.Instantiate(sentryBulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
		StartCoroutine(FireRoutine());
	}
	
	void OnHit()
	{
		actionMusic.ChangeParameter ("Intensity", 1.00f);
		pickupManager.SentryKilled ();
		Destroy(gameObject);
	}
}
