using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField] int startingLevel = 1;
    [SerializeField] int startingExperience = 0;

    private int currentLevel;
    private int currentExperience;

    private void Awake()
    {
        currentLevel = startingLevel;
        currentExperience = startingExperience;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onExperienceGained += ExperienceGained;
    }
    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onExperienceGained -= ExperienceGained;
    }

    private void Start()
    {
        GameEventsManager.instance.playerEvents.PlayerLevelChange(currentLevel);
        GameEventsManager.instance.playerEvents.ExperienceChange(currentExperience);
    }

    private void ExperienceGained(int experience)
    {
        currentExperience += experience;

        while(currentExperience >= GlobalConstants.experienceToLevelUp)
        {
            currentExperience -= GlobalConstants.experienceToLevelUp;
            currentLevel++;
            GameEventsManager.instance.playerEvents.PlayerLevelChange(currentLevel);
        }
        GameEventsManager.instance.playerEvents.ExperienceChange(currentExperience);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.questCompleted, this.transform.position);
    }
}
