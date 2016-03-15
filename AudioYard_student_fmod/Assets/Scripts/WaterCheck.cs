using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{

    public class WaterCheck : MonoBehaviour
    {
        private FirstPersonController player;

        void Awake()
        {
            player = FindObjectOfType<FirstPersonController>();
        }

        // Update is called once per frame
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                player.inWater = true;
            }
            else
                return;

        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                player.inWater = false;
            }
            else
                return;
        }
    }
}