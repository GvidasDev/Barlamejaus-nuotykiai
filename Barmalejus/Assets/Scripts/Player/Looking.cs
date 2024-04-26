using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;

    [SerializeField] Transform playerBody;
    [SerializeField] Camera mainCamera;

    [SerializeField] float defaultFov = 60f;
    [SerializeField] float zoomSpeed = 0.2f;
    [SerializeField] float zoomFov = 30f;

    float xRotation = 0f;
    private bool enableLook;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        defaultFov = mainCamera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(enableLook)
        {
            Look();
            CameraZoom();
        }


    }
    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    private void CameraZoom()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoomFov, zoomSpeed);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, defaultFov, zoomSpeed);
        }
    }
    public void EnableLook()
    {
        enableLook = true;
    }

    public void DisableLook()
    {
        enableLook = false;
    }
}
