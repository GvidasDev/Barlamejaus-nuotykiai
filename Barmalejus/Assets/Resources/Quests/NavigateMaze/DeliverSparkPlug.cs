using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeliverSparkPlug : QuestStep
{
    private void Start()
    {
        string status = "Deliver Spark Plug to the boat!";
        Debug.Log(status);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SparkPlug"))
        {
            string status = "Spark Plug has been delivered to the boat. Return to the maze marker!";
            Debug.Log(status);
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
