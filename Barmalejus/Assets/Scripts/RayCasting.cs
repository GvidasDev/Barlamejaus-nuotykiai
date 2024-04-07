using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{

    [SerializeField] float rayRange = 1.0f;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    Transform cameraTransform;
    private ObjectGrabbable objectGrabbable;
    RaycastHit hitInfo;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }


    void Update()
    {
        Pickup();
    }

    void Pickup()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(objectGrabbable == null) // No object is picked up
            {
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitInfo, rayRange, pickUpLayerMask))
                {
                    if (hitInfo.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * rayRange, color: Color.green);
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }

    }
}
