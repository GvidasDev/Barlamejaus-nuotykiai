using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public float skySpeed;

    // Update is called once per frame
    void Update()
    {
        Material skyboxMaterial = RenderSettings.skybox;

        float newRotation = skyboxMaterial.GetFloat("_Rotation") + Time.deltaTime * skySpeed;
        skyboxMaterial.SetFloat("_Rotation", newRotation % 360);
    }
}
