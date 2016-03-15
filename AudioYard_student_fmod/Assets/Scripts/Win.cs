using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour
{
    public float waitForSeconds = 0f;

    void Awake()
    {
        FMODUnity.RuntimeManager.LoadBank("Master Bank");
    }

    IEnumerator Won()
    {
        yield return new WaitForSeconds(waitForSeconds);
        FMODUnity.RuntimeManager.UnloadBank("Master Bank");
        Application.LoadLevel(Application.loadedLevel);
    }
    void OnTriggerEnter()
    {
        StartCoroutine(Won());
    }
}