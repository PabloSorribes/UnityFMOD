using UnityEngine;
using System.Collections;

//using FMODUnity;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class AIBehavior : MonoBehaviour
    {
        private AICharacterControl charScript;
        public int hitpoints = 1;

        public EventPlayer enemyMusic;
        public bool Dead;

        void Awake()
        {
            Dead = false;

            if (hitpoints == 0)
            {
                hitpoints = 1;
            }
            charScript = gameObject.GetComponent<AICharacterControl>();
            charScript.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            //Needs a gameObj as reference for it to work, else it doesn't know what event to affect.
            //Which is the case right now.
            //enemyMusic.ChangeParameter("Level", 80f);
            //enemyMusic.PlayEvent();
        }

        void Update()
        {
            if (hitpoints > 0)
            {
                return;
            }
            else if (hitpoints == 0)
            {
                Dead = true;
                //Same thing here.
                //enemyMusic.StopEvent(false);
                Destroy(gameObject);
            }
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Player>().Death();
                Destroy(gameObject);
            }
            if (other.gameObject.tag == "PlayerBullet")
            {
                hitpoints--;
            }

        }

    }
}