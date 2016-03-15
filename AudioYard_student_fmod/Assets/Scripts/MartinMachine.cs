using UnityEngine;
using System.Collections;

public class SpawnAI2 : MonoBehaviour
{
    public Object runner;
    //private Transform playerCamera;
    public bool spawnOnAwake = false;
    public EventPlayer eventAmb;
    public int enemies = 0;

    void Awake()
    {
        //playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        if (runner == null)
        {
            return;
        }
    }

    public void Spawn(Transform spawnTrans)
    {
        enemies++;
        Instantiate(runner, spawnTrans.localPosition, spawnTrans.localRotation);
        eventAmb.ChangeParameter("Enemy", 1.0f);
    }

    public void Death()
    {
        enemies--;

        if (enemies == 0)
        {
            eventAmb.ChangeParameter("Enemy", 0.0f);
        }
    }
}