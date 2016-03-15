using UnityEngine;
using System.Collections;

public class StartMusic : MonoBehaviour 
{
	public EventPlayer levelMusic;
	//public FMOD_StudioEventEmitter name;


	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Starting playback");
		//levelMusic.ChangeParameter ("Progression", 0.00f);
		levelMusic.PlayEvent ();
		Debug.Log ("Event: /Music/Music is playing"); 
	}

	void StartTheMusic () 
	{
		Debug.Log ("Testing");
		//levelMusic.ChangeParameter ("Intensity", 0.00f);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
