using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool playSkyrimMusic;
    public static AudioManager instance { get; private set; }

    private EventInstance ambienceEventInstance;
    private EventInstance skyrimAmbienceInstance;


    private void Start()
    {
        InitializeAmbience(FMODEvents.instance.ambience);
        InitializeSkyrimAmbience(FMODEvents.instance.skyrimAmbience);
    }
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene!");
        }
        instance = this;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void SetAmbienceArea(AmbienceArea area)
    {
        ambienceEventInstance.setParameterByName("area", (float) area);
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    private void InitializeAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateEventInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }
    private void InitializeSkyrimAmbience(EventReference skyrimAmbience)
    {
        if(playSkyrimMusic)
        {
            skyrimAmbienceInstance = CreateEventInstance(skyrimAmbience);
            skyrimAmbienceInstance.start();
        }
        
    }
}
