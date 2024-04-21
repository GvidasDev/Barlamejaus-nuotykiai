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


    [field: Header("Item PickUp test")]
    [field: SerializeField] public EventReference itemPickup { get; private set; }


    [field: Header("New Objective")]
    [field: SerializeField] public EventReference newObjective { get; private set; }


    [field: Header("Quest Completed")]
    [field: SerializeField] public EventReference questCompleted { get; private set; }

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
