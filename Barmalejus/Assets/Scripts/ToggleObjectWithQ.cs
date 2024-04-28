using System.Collections;
using UnityEngine;

public class ToggleObjectWithQ : MonoBehaviour
{
    [SerializeField] GameObject toggleRiddleUI;
    [SerializeField] private float dissapearDelayTime = 0.1f;

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
    private void Awake()
    {
        StartCoroutine(ActivateDeactivateRiddleUI());
    }
    private void ShowRiddleUIPressed()
    {
        toggleRiddleUI.SetActive(true);
    }

    private void HideRiddleUIPressed()
    {
        toggleRiddleUI.SetActive(false);
    }
    private IEnumerator ActivateDeactivateRiddleUI()
    {
        toggleRiddleUI.SetActive(true);
        yield return new WaitForSeconds(dissapearDelayTime);
        toggleRiddleUI.SetActive(false);
    }
}
