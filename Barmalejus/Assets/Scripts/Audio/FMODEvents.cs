using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambience { get; private set; }


    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootsteps { get; private set; }


    [field: Header("New Quest")]
    [field: SerializeField] public EventReference newQuest { get; private set; }


    [field: Header("New Objective")]
    [field: SerializeField] public EventReference newObjective { get; private set; }


    [field: Header("Quest Completed")]
    [field: SerializeField] public EventReference questCompleted { get; private set; }


    [field: Header("Menu Selection")]
    [field: SerializeField] public EventReference menuSelection { get; private set; }


    [field: Header("Chest Open")]
    [field: SerializeField] public EventReference chestOpen { get; private set; }


    [field: Header("Intro Thunderstorm Ambience")]
    [field: SerializeField] public EventReference introThunderstorm { get; private set; }


    [field: Header("Outro Synthwave")]
    [field: SerializeField] public EventReference outroMusic { get; private set; }


    [field: Header("Ending Light Switch")]
    [field: SerializeField] public EventReference lightSwitch { get; private set; }


    [field: Header("Ending Sea Waves")]
    [field: SerializeField] public EventReference seaWaves { get; private set; }


    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events script in the scene!");
        }
        instance = this;
    }
}
