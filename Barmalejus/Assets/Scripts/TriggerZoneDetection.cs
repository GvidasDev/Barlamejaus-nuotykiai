using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pickable"))
        {
            string itemName = other.gameObject.name;
            Debug.Log(itemName + " has been delivered!");
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
