using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            GameEventsManager.instance.inputEvents.SubmitPressed();
        }
    }
}
