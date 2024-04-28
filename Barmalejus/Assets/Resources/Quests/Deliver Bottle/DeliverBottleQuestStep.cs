using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeliverBottleQuestStep : QuestStep
{
    private GameObject textMeshPro;
    private TextMeshProUGUI text;
    private void Start()
    {
        string status = "Deliver the bottle to the boat!";
        textMeshPro = GameObject.Find("QuestSteps");
        text = textMeshPro.GetComponent<TextMeshProUGUI>();
        text.text = status;
        ChangeState("");
        Debug.Log(status);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bottle"))
        {
            string status = "Bottle has been delivered to the boat. Return to green check mark";
            text.text = status;
            Debug.Log(status);
            ChangeState("");
            FinishQuestStep();
            
        }
    }

    protected void UpdateState()
    {
        // no state is needed for this quest (would require if there was e.g incrementing integer)
    }

    protected override void SetQuestStepState(string state)
    {
        // no state is needed for this quest (would require if there was e.g incrementing integer)
    }
}
