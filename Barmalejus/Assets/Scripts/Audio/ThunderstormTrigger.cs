using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderstormTrigger : MonoBehaviour
{
    [SerializeField] private GameObject lightning;
    private bool wasActive = false;
    void Update()
    {
        //check if lightning object is active
        if(lightning.activeInHierarchy && !wasActive)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.introThunderstorm,this.transform.position);
            wasActive = true;
        }
        else if(!lightning.activeInHierarchy)
        {
            wasActive = false;
        }
    }
}
