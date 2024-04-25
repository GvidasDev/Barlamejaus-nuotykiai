using UnityEngine;

public class ToggleCanvasWithTab : MonoBehaviour
{
    public GameObject canvasObject; // Reference to the canvas GameObject

    void Update()
    {
        // Toggle canvas with Tab key
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Check if canvasObject exists
            if (canvasObject != null)
            {
                // Toggle canvas visibility
                canvasObject.SetActive(!canvasObject.activeSelf);
            }
            else
            {
                Debug.LogError("Canvas object reference is not set!");
            }
        }
    }
}
