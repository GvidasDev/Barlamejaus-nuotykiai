using UnityEngine;

public class ToggleObjectWithQ : MonoBehaviour
{
    [SerializeField] GameObject toggleRiddleUI;

    private void OnEnable()
    {
        GameEventsManager.instance.inputEvents.onShowRiddleUIPressed += ShowRiddleUIPressed;
        GameEventsManager.instance.inputEvents.onHideRiddleUIPressed += HideRiddleUIPressed;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.inputEvents.onShowRiddleUIPressed -= ShowRiddleUIPressed;
        GameEventsManager.instance.inputEvents.onHideRiddleUIPressed -= HideRiddleUIPressed;
    }
    private void Start()
    {
        toggleRiddleUI.SetActive(false);
    }
    private void ShowRiddleUIPressed()
    {
        toggleRiddleUI.SetActive(true);
    }

    private void HideRiddleUIPressed()
    {
        toggleRiddleUI.SetActive(false);
    }
}
