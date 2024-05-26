using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform openPosition;
    private Vector3 closedPosition;
    private bool isOpen = false;

    void Start()
    {
        closedPosition = transform.position;
    }

    public void UnlockDoor()
    {
        if (!isOpen)
        {
            transform.position = openPosition.position;
            isOpen = true;
        }
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            transform.position = closedPosition;
            isOpen = false;
        }
    }
}
