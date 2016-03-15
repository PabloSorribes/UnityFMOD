using UnityEngine;
using System.Collections;

public class SentrySensor : MonoBehaviour 
{
	public Sentry sentry;
	public EventPlayer actionMusic;
    public EventPlayer pickupMusic;

    void OnTriggerEnter(Collider other)
	{
        //pickupMusic.ChangeParameter("Level", 80f);
        pickupMusic.StopEvent(true);

        actionMusic.ChangeParameter ("Intensity", 0.40f);
		actionMusic.PlayEvent ();
		sentry.SetTarget(other.transform);
	}
	
	void OnTriggerExit()
	{
		actionMusic.ChangeParameter ("Intensity", 1.00f);

        pickupMusic.ChangeParameter("Level", 80f);
        pickupMusic.PlayEvent();

        sentry.SetTarget(null);
	}
}
