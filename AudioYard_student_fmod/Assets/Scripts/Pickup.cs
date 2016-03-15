using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    private PickupManager pickupManager;
    private BoxCollider boxCollider;
	public Transform refTrans;

	//public EventPlayer pickupMusic;

    void Awake()
    {
        pickupManager = FindObjectOfType<PickupManager>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }
	
	void Update ()
    {
        transform.Rotate(Vector3.up, 50f * Time.deltaTime);
    }

    void OnTriggerEnter()
    {
        boxCollider.enabled = false;
        pickupManager.PickupHandling(refTrans);

		//pickupMusic.ChangeParameter ("Level", 80f);
		//pickupMusic.PlayEvent ();


        Destroy(gameObject);
        
    }
}
