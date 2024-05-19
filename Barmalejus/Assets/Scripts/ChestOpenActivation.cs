using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenActivation : MonoBehaviour
{
    [SerializeField] private Animator chestOpenAnimation;
    private void OnEnable()
    {
        chestOpenAnimation.SetTrigger("ChestOpen");
        AudioManager.instance.PlayOneShot(FMODEvents.instance.chestOpen, this.transform.position);
    }
}
