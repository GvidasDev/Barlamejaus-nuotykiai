using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool loadQuestState = true;

    // "New quest UI"
    [Header("UI")]
    [SerializeField] private GameObject uiText;
    private TextMeshProUGUI uiTextComponent;
    [SerializeField] private float duration = 2f;
    [SerializeField] private float currentLerpTime = 0f;
    private float initialAlpha;
    private float finalAlpha = 0f;
    private bool shouldChange = false;


    private Dictionary<string, Quest> questMap;

    // quest start requirements
    private int currentPlayerLevel;


    private void Awake()
    {
        questMap = CreateQuestMap();
        

    }

    private void DarkenText()
    {
        if(currentLerpTime < duration)
        {
            currentLerpTime += Time.deltaTime;
            if(currentLerpTime > duration)
            {
                currentLerpTime = duration;
                uiText.SetActive(false);
            }
            float t = currentLerpTime / duration;
            
            Color color = uiTextComponent.color;
            color.a = Mathf.Lerp(initialAlpha, finalAlpha, t);
            Debug.Log(color.a);
            uiTextComponent.color = color;
        }
        
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;

        GameEventsManager.instance.questEvents.onQuestStepStateChange += QuestStepStateChange;

        GameEventsManager.instance.playerEvents.onPlayerLevelChange += PlayerLevelChange;
    }
    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;

        GameEventsManager.instance.questEvents.onQuestStepStateChange -= QuestStepStateChange;

        GameEventsManager.instance.playerEvents.onPlayerLevelChange -= PlayerLevelChange;
    }

    private void Start()
    {
        
        foreach(Quest quest in questMap.Values)
        {
            // initialize ant loaded quest steps
            if(quest.state == QuestState.IN_PROGRESS)
            {
                quest.InstantiateCurrentQuestStep(this.transform);
            }
            // broadcast the initial state of all quests on startup
            GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }


        //"New Quest UI"
        uiTextComponent = uiText.GetComponent<TextMeshProUGUI>();
        Color color = uiTextComponent.color;
        initialAlpha = color.a;
        Debug.Log("Initial alpha: " + initialAlpha);
        uiText.SetActive(false);
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

        if(shouldChange)
        {
            uiText.SetActive(true);
            DarkenText();
        }
        
    }

    private void StartQuest(string id)
    {
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestState(quest.info.id, QuestState.IN_PROGRESS);
        
        // Quest start audio
        AudioManager.instance.PlayOneShot(FMODEvents.instance.newQuest,this.transform.position);

        // "New Quest" UI
        shouldChange = true;
    }

    private void AdvanceQuest(string id)
    {
        Quest quest = GetQuestById(id);

        // move to next step
        quest.MoveToNextStep();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.newObjective, this.transform.position);

        // if there are more steps, instantiate the next one
        if (quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(this.transform);
        }
        else
        {
            ChangeQuestState(quest.info.id, QuestState.CAN_FINISH);
        }
    }

    private void FinishQuest(string id)
    {
        Quest quest = GetQuestById(id);
        ClaimReward(quest);
        ChangeQuestState(quest.info.id,QuestState.FINISHED);
    }
    private void ClaimReward(Quest quest)
    {
        GameEventsManager.instance.playerEvents.ExperienceGained(quest.info.experienceLevel);
    }

    private void QuestStepStateChange(string id, int stepIndex, QuestStepState questStepState)
    {
        Quest quest = GetQuestById(id);
        quest.StoreQuestStepState(questStepState, stepIndex);
        ChangeQuestState(id, quest.state);
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
            idToQuestMap.Add(questInfo.id, LoadQuest(questInfo));
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

    private void OnApplicationQuit()
    {
        foreach(Quest quest in questMap.Values)
        {
            SaveQuest(quest);
        }
    }

    private void SaveQuest(Quest quest)
    {
        try
        {
            QuestData questData = quest.GetQuestData();
            string serializeData = JsonUtility.ToJson(questData);
            PlayerPrefs.SetString(quest.info.id, serializeData);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save quest with id " + quest.info.id + ": " + e);
        }
    }

    private Quest LoadQuest(QuestInfoSO questInfo)
    {
        Quest quest = null;
        try
        {
            // Load quest data from saved data
            if(PlayerPrefs.HasKey(questInfo.id) && loadQuestState)
            {
                string serializedData = PlayerPrefs.GetString(questInfo.id);
                QuestData questData = JsonUtility.FromJson<QuestData>(serializedData);
                quest = new Quest(questInfo, questData.state,questData.questStepIndex,questData.questStepStates);
            }
            // otherwise, initialize a new quest (no save data was found)
            else
            {
                quest = new Quest(questInfo);
            }
        }
        catch(System.Exception e)
        {
            Debug.LogError("Failed to load quest with id " + quest.info.id + ": " + e);
        }
        return quest;
    }
}
