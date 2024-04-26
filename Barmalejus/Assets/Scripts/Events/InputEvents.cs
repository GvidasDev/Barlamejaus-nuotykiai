using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEvents
{

    public event Action onSubmitPressed;

    public void SubmitPressed()
    {
        if (onSubmitPressed != null)
        {
            onSubmitPressed();
        }
    }

    public event Action onShowCompassPressed;

    public void ShowCompassPressed()
    {
        if(onShowCompassPressed != null)
        {
            onShowCompassPressed();
        }
    }

    public event Action onHideCompassPressed;

    public void HideCompassPressed()
    {
        if (onHideCompassPressed != null)
        {
            onHideCompassPressed();
        }
    }

    public event Action onPickItemPressed;

    public void PickItemPressed()
    {
        if (onPickItemPressed != null)
        {
            onPickItemPressed();
        }
    }

    public event Action onShowRiddleUIPressed;
    public void ShowRiddleUIPressed()
    {
        if(onShowRiddleUIPressed != null)
        {
            onShowRiddleUIPressed();
        }
    }

    public event Action onHideRiddleUIPressed;
    public void HideRiddleUIPressed()
    {
        if (onHideRiddleUIPressed != null)
        {
            onHideRiddleUIPressed();
        }
    }

}
