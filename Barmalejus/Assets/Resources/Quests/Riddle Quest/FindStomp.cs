using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FindStomp : QuestStep
{
    private void Start()
    {
        string status = "A stomp in the forest atop the island awaits your arrival, when this is done then read this map";
        Debug.Log(status);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            InputCheck();
        }
    }

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        if (Input.GetKey(KeyCode.Q))
        {
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
