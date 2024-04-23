using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneDetection : MonoBehaviour
{
    private GameObject sun;
    private Light sunLight;
    private float initialIntensity;
    private float finalIntensity = 0.1f;
    public float duration = 2f;
    public float currentLerpTime = 0f;
    private bool shouldRotate = false;
    public float initialSkyboxIntensity;
    public float finalSkyboxIntensity = 0f;

    private void Start()
    {
        sun = GameObject.Find("Spot Light");
        sunLight = sun.GetComponent<Light>();
        initialIntensity = sunLight.intensity;
        initialSkyboxIntensity = RenderSettings.ambientIntensity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            shouldRotate = true;
            currentLerpTime = 0f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldRotate = false;
            currentLerpTime = 0f;
        }
    }
    void Update()
    {
        if (shouldRotate)
        {
            Darken();
        }
        else
        {
            Brighten();
        }
        
    }
    void Darken()
    {
            if (currentLerpTime < duration)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime > duration)
                {
                    currentLerpTime = duration;
                }
                float t = currentLerpTime / duration;
                sunLight.intensity = Mathf.Lerp(initialIntensity, finalIntensity, t);
                RenderSettings.ambientIntensity = Mathf.Lerp(initialSkyboxIntensity, finalSkyboxIntensity, t);
            }
    }
    void Brighten()
    {
            if (currentLerpTime < duration)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime > duration)
                {
                    currentLerpTime = duration;
                }
                float t = 1 - (currentLerpTime / duration);
                sunLight.intensity = Mathf.Lerp(initialIntensity, finalIntensity, t);
                RenderSettings.ambientIntensity = Mathf.Lerp(initialSkyboxIntensity, finalSkyboxIntensity, t);
        }
    }
}
