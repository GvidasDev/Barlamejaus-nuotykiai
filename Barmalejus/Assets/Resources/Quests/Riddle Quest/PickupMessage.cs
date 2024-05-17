using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class PickupMessage : QuestStep
{
    private bool playerInRange = false;

    private GameObject textMeshPro;
    private TextMeshProUGUI text;
    private GameObject bottle;

    void Start()
    {
        string status = "Approach the bottle!";
        textMeshPro = GameObject.Find("QuestSteps");
        text = textMeshPro.GetComponent<TextMeshProUGUI>();
        text.text = status;
        ChangeState("");

        bottle = GameObject.Find("bottle");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //playerInRange = true;
            FinishQuestStep();
            Destroy(bottle);
            text.text = "Open riddle paper with Q";
            //SubmitPressed();
        }
    }
/*    private void SubmitPressed()
    {
        if (playerInRange)
        {
            FinishQuestStep();
        }
    }*/

    protected void UpdateState()
    {
        // no state is needed for this quest (would require if there was e.g incrementing integer)
    }
    protected override void SetQuestStepState(string state)
    {
        // no state is needed for this quest (would require if there was e.g incrementing integer)
    }
}
