using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchActivation : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.lightSwitch, this.transform.position);
    }
}
