using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleUIEvents : MonoBehaviour
{

    public event Action<int, string> onRiddleProgress;
    public void RiddleProgress(int id, string status)
    {
        if (onRiddleProgress != null)
        {
            onRiddleProgress(id,status);
        }
    }
}
