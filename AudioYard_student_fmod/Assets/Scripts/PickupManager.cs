using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour
{
	[HideInInspector]
    public int numberOfPickups = 0;
    [HideInInspector]
	public GameObject[] pickups;
	private SpawnAI spawnAI;


    void Awake()
    {
        spawnAI = FindObjectOfType<SpawnAI>();
		pickups = GameObject.FindGameObjectsWithTag("Pickups");
    }

    public void PickupHandling(Transform tempTrans)
    {
        numberOfPickups++;
        Debug.Log("Pickup " + numberOfPickups);
        spawnAI.Spawn(tempTrans);
        
    }

	public void SentryKilled()
	{
		numberOfPickups++;
		Debug.Log("Pickup " + numberOfPickups);
	}

}
