using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FindAndDeliverPart : QuestStep
{
    [SerializeField] private int id;

    private GameObject textMeshPro;
    private TextMeshProUGUI text;

    private void Start()
    {
        string status = "The treasure is close, but you're not done, head 5 paces West, grab it and run";
        textMeshPro = GameObject.Find("QuestSteps");
        text = textMeshPro.GetComponent<TextMeshProUGUI>();
        
        ChangeState("");
        GameEventsManager.instance.riddleUIEvents.RiddleProgress(id,status);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Radiator"))
        {
            string status = "Radiator has been delivered to the boat. Return to the yellow marker!";
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
