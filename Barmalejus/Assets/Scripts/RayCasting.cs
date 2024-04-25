using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class RayCasting : MonoBehaviour
{

    [SerializeField] float rayRange = 1.0f;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    Transform cameraTransform;
    private ObjectGrabbable objectGrabbable;
    [SerializeField] CrosshairManager crosshairManager;
    RaycastHit hitInfo;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }


    void Update()
    {
        PickupItem();
        AdjustCrossair();
    }

    void PickupItem()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(objectGrabbable == null) // No object is picked up
            {
                if (Physics.Raycast(origin: cameraTransform.position, direction: cameraTransform.forward, out hitInfo, rayRange, pickUpLayerMask))
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
    void AdjustCrossair()
    {
        if(Physics.Raycast(origin: cameraTransform.position, direction: cameraTransform.forward, out hitInfo, rayRange, pickUpLayerMask))
        {
            Debug.DrawRay(start: cameraTransform.position, dir: cameraTransform.forward,color: Color.red);
            if(hitInfo.transform.tag == "Pickable")
            {
                crosshairManager.ChangeCrosshairSize(300);
            }
        }
        else
        {
            crosshairManager.ChangeCrosshairSize(100);
        }
    }
}
