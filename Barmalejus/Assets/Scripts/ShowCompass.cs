using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCompass : MonoBehaviour
{
    [SerializeField] private GameObject compass;

    private void OnEnable()
    {
        GameEventsManager.instance.inputEvents.onShowCompassPressed += ShowCompassPressed;
        GameEventsManager.instance.inputEvents.onHideCompassPressed += HideCompassPressed;
    }
    private void OnDisable()
    {
        GameEventsManager.instance.inputEvents.onShowCompassPressed -= ShowCompassPressed;
        GameEventsManager.instance.inputEvents.onHideCompassPressed -= HideCompassPressed;
    }
    private void Start()
    {
        compass.gameObject.SetActive(false);
    }

    private void ShowCompassPressed()
    {
        compass.gameObject.SetActive(true);
    }
    private void HideCompassPressed()
    {
        compass.gameObject.SetActive(false);
    }
}
