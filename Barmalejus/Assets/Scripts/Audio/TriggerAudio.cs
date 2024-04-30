using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    [SerializeField] public bool PlayOnAwake;
    public void PlayButtonSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.menuSelection, this.transform.position);
    }
    private void Start()
    {
        if(PlayOnAwake)
        {
            PlayButtonSound();
        }
    }
}
