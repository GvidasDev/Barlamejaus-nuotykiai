using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] float rayRange = 1.0f;
    Transform cameraTransform;
    RaycastHit hitInfo;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }


    void Update()
    {
        // Always draw ray for debugging
        Ray ray = new Ray(origin: cameraTransform.position, direction: cameraTransform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayRange,Color.red);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitInfo, rayRange))
            {
                if (hitInfo.collider.tag != null)
                {
                    Debug.Log("Ray hit an object!");
                }
            }
        }
    }
}
