using UnityEngine;

public class ToggleObjectWithQ : MonoBehaviour
{
    public GameObject objectToToggle;

    void Update()
    {
        // Check if the 'Q' key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Toggle the visibility of the object
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
