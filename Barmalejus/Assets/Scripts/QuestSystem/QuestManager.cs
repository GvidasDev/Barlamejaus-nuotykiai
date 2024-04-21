using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    private Dictionary<string, Quest> questMap;

    // quest start requirements
    private int currentPlayerLevel;


    private void Awake()
    {
        questMap = CreateQuestMap();

    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;

        GameEventsManager.instance.playerEvents.onPlayerLevelChange += PlayerLevelChange;
    }
    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;

        GameEventsManager.instance.playerEvents.onPlayerLevelChange -= PlayerLevelChange;
    }

    private void Start()
    {
        // broadcast the initial state of all quests on startup
        foreach(Quest quest in questMap.Values)
        {
            GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        GameEventsManager.instance.questEvents.QuestStateChange(quest);
    }

    private void PlayerLevelChange(int level)
    {
        currentPlayerLevel = level;
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        // start true and prove to be false
        bool meetsRequirements = true;

        // check player level requirements
        if(currentPlayerLevel < quest.info.levelRequirement)
        {
            meetsRequirements = false;
        }

        // check quest prerequisites for completion
        foreach(QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites)
        {
            if(GetQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED)
            {
                meetsRequirements = false;
                break;
            }
        }
        return meetsRequirements;
    }

    private void Update()
    {
        // Loop through ALL quests
        foreach(Quest quest in questMap.Values)
        {
            if(quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }
        }
    }

    private void StartQuest(string id)
    {
        // TODO - start the quest
        Debug.Log("Start Quest: " + id);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.newObjective,this.transform.position);
    }

    private void AdvanceQuest(string id)
    {
        // TODO - advance the quest
        Debug.Log("Advance Quest: " + id);
    }

    private void FinishQuest(string id)
    {
        // TODO - finish the quest
        Debug.Log("Finish Quest: " + id);
    }


    private Dictionary<string, Quest> CreateQuestMap()
    {
        // Loads all QuestInfoSO scriptable objects under the Assets/Resources/Quests folder
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        // Create the quest map
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach(QuestInfoSO questInfo in allQuests)
        {
            if(idToQuestMap.ContainsKey(questInfo.id))
            {
                Debug.LogWarning("Duplicate ID was found when creating quest map: " + questInfo.id);
            }
            idToQuestMap.Add(questInfo.id, new Quest(questInfo));
        }
        return idToQuestMap;
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if(quest == null)
        {
            Debug.LogError("ID not found in Quest Map: " + id);
        }
        return quest;
    }

}
