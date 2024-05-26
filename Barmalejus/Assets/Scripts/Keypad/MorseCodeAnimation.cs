using UnityEngine;using System.Collections;
public class MorseCodeAnimation : MonoBehaviour
{
    public Light lightSource;
    public float dotDuration = 0.5f; // Duration of a dot (in seconds)
    public float dashDuration = 1.5f; // Duration of a dash (in seconds)
    public float pauseDuration = 0.5f; // Duration of pause between characters (in seconds)
    public float repeatDelay = 3f; // Delay before repeating the animation (in seconds)

    private string[] morseCodeSequence = { "-....", "--...", "..---", ".----", "-----" }; // Example Morse code sequence -.... --... ..--- .---- ----- 67210
    private float baseIntensity; // Base intensity of the light
    private WaitForSeconds dotWait; // Wait duration for dots
    private WaitForSeconds dashWait; // Wait duration for dashes
    private WaitForSeconds pauseWait; // Wait duration for pauses
    private WaitForSeconds repeatWait; // Wait duration before repeating the animation

    void Start()
    {
        baseIntensity = lightSource.intensity;
        dotWait = new WaitForSeconds(dotDuration);
        dashWait = new WaitForSeconds(dashDuration);
        pauseWait = new WaitForSeconds(pauseDuration);
        repeatWait = new WaitForSeconds(repeatDelay);

        StartCoroutine(AnimateMorseCode());
    }

    IEnumerator AnimateMorseCode()
    {
        while (true)
        {
            foreach (string character in morseCodeSequence)
            {
                foreach (char signal in character)
                {
                    if (signal == '.')
                    {
                        lightSource.intensity = 10; // Increase intensity for dots
                        yield return dotWait;
                    }
                    else if (signal == '-')
                    {
                        lightSource.intensity = 10; // Increase intensity for dashes
                        yield return dashWait;
                    }
                    lightSource.intensity = baseIntensity; // Reset intensity
                    yield return pauseWait; // Pause between characters
                }
                yield return pauseWait; // Pause between characters
            }
            yield return repeatWait; // Delay before repeating the animation
        }
    }
}
