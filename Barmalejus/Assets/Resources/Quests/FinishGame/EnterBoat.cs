using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class EnterBoat : QuestStep
{

    private GameObject textMeshPro;
    private TextMeshProUGUI text;


    public LevelLoader levelLoader;


    void Start()
    {
        GameObject gameObject = GameObject.Find("LevelLoader");
        levelLoader = gameObject.GetComponent<LevelLoader>();
        string status = "Leave the island with the boat!";

        textMeshPro = GameObject.Find("QuestSteps");
        text = textMeshPro.GetComponent<TextMeshProUGUI>();
        text.text = status;
        ChangeState("");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            levelLoader.LoadNextLevel("3DEnding");
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
