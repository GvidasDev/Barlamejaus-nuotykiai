using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDigUpAnimation : MonoBehaviour
{
    [SerializeField] private Animator chestDigUp;
    [SerializeField] private Animator chestOpen;
    [SerializeField] private GameObject interactionPrompt;
    [SerializeField] private GameObject treasure;

    private bool isPlayerNear = false;

    private void OnEnable()
    {
        GameEventsManager.instance.inputEvents.onSubmitPressed += SubmitPressed;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.inputEvents.onSubmitPressed -= SubmitPressed;
    }

    private void Awake()
    {
        interactionPrompt.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        chestDigUp.SetTrigger("DigUp");
        interactionPrompt.SetActive(true);
        isPlayerNear = true;
    }
    private void OnTriggerExit(Collider other)
    {
        interactionPrompt.SetActive(false);
        isPlayerNear = false;
    }

    private void SubmitPressed()
    {
        if(isPlayerNear)
        {
            chestOpen.SetTrigger("ChestOpen");
            AudioManager.instance.PlayOneShot(FMODEvents.instance.chestOpen, this.transform.position);
            interactionPrompt.SetActive(false);
            Destroy(this.gameObject);
            Instantiate(treasure);
        }
    }
}
