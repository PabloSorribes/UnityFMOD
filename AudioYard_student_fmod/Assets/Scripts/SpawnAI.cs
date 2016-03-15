using UnityEngine;
using System.Collections;
//using UnityStandardAssets.Characters.ThirdPerson;

public class SpawnAI : MonoBehaviour
{
    public Object runner;
    //private Transform playerCamera;
    public bool spawnOnAwake = false;
    public EventPlayer eventAmb;
    public int enemies = 0;
    //public AIBehavior enemy;

    void Awake()
    {
        //enemy = GameObject.FindObjectOfType<AIBehavior>();
        //playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        if (runner == null)
        {
            return;
        }
    }

    /* void Update()
     {
         if (enemy.Dead)              //if (enemy.Dead == true)
         {
             Death();
         }
     }
     */

    public void Spawn(Transform spawnTrans)
    {
        Debug.Log("I SPAWN AND ADD ENEMY COUNTER!");
        enemies++;
        Instantiate(runner, spawnTrans.localPosition, spawnTrans.localRotation);
        eventAmb.ChangeParameter("Intensity", 0.20f);
    }

    public void Death()
    {
        Debug.Log("I DIE NAU!");
        enemies--;

        if (enemies == 0)
        {
            eventAmb.ChangeParameter("Intensity", 0.0f);
        }
    }
}