using UnityEngine;

public class FogTrigger : MonoBehaviour
{
    public float fogDensity = 0.05f; // Adjust the fog density as needed
    public Color fogColor = Color.gray; // Adjust the fog color as needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable fog
            RenderSettings.fog = false;
            // Set fog density
            RenderSettings.fogDensity = fogDensity;
            // Set fog color
            RenderSettings.fogColor = fogColor;

            // Debug print statement
            Debug.Log("Fog enabled.");
        }
    }
}
