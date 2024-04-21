using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeliverBottleQuestStep : QuestStep
{
    private void Start()
    {
        string status = "Deliver the bottle to the boat!";
        Debug.Log(status);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bottle"))
        {
            string status = "Bottle has been delivered to the boat. Return to green check mark";
            Debug.Log(status);
            FinishQuestStep();
        }
    }

}
