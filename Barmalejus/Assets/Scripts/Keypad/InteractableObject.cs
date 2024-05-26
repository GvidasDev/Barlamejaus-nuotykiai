using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject keypadCanvas; // Reference to the canvas object for the keypad
    public GameObject interactionCanvas; // Reference to the canvas object for the interaction text
    public KeyCode interactKey = KeyCode.E;
    private bool isPlayerInRange = false;
    private bool isUIActive = false;
    public GameObject player;
    private MonoBehaviour lookingScript; // Reference to the "Looking" script

    void Start()
    {
        // Get the "Looking" script attached to the main camera
        lookingScript = player.GetComponentInChildren<Looking>();
        // Disable canvases initially
        keypadCanvas.SetActive(false);
        interactionCanvas.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactKey))
        {
            ToggleUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // Show interaction canvas
            interactionCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Hide interaction canvas
            interactionCanvas.SetActive(false);
            if (isUIActive) ToggleUI(); // Close UI when player leaves range
        }
    }

    private void ToggleUI()
    {
        isUIActive = !isUIActive;
        // If UI is active, handle cursor and looking script
        if (isUIActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            lookingScript.enabled = false;
            // Show keypad canvas
            keypadCanvas.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            lookingScript.enabled = true;
            // Hide keypad canvas
            keypadCanvas.SetActive(false);
        }
        // Disable interaction canvas after pressing the interaction key
        interactionCanvas.SetActive(false);
    }
}
