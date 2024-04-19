using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    [SerializeField] GameObject crosshairObject;

    public void ChangeCrosshairSize(float newSize)
    {
        RectTransform rectTransform = crosshairObject.GetComponent<RectTransform>();

        rectTransform.sizeDelta = new Vector2(newSize, newSize);
    }

}
