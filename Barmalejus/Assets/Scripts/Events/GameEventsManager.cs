using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public QuestEvents questEvents;
    public InputEvents inputEvents;
    public PlayerEvents playerEvents;
    public RiddleUIEvents riddleUIEvents;
    public DeliveredItemEvents deliveredItemEvents;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene!");
        }
        instance = this;


        questEvents = new QuestEvents();
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        riddleUIEvents = new RiddleUIEvents();
        deliveredItemEvents = new DeliveredItemEvents();
    }
}
