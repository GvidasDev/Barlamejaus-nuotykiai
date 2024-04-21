using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneDetection : MonoBehaviour
{
    [SerializeField] private int experienceGained = 100;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pickable"))
        {
            string itemName = other.gameObject.name;
            Debug.Log(itemName + " has been delivered!");

            GameEventsManager.instance.playerEvents.ExperienceGained(experienceGained);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            string itemName = other.gameObject.name;
            Debug.Log(itemName + " has been taken away!");
        }
    }
}
