using UnityEngine;

public class EnableQuestListOnKeyPress : MonoBehaviour
{
    public GameObject questListController; // Reference to the QuestListController object
    public GameObject canvasObject;
    void Update()
    {
        // Check if 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if QuestListController exists
            if (questListController != null)
            {
                // Enable QuestListController object
                questListController.SetActive(true);
                canvasObject.SetActive(true);
            }
            else
            {
                Debug.LogError("QuestListController reference is not set!");
            }
        }
    }
}
