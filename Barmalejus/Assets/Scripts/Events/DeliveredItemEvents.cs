using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveredItemEvents
{
    public event Action onItemDelivered;
    public void ItemDelivered()
    {
        if (onItemDelivered != null)
        {
            onItemDelivered();
        }
    }
}
