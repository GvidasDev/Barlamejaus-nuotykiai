using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsToCutscene : MonoBehaviour
{
    private LevelLoader levelLoader;
    public void ChangeScene()
    {
        GameObject gameObject = GameObject.Find("LevelLoader");
        levelLoader = gameObject.GetComponent<LevelLoader>();
        levelLoader.LoadNextLevel("FinalScene");
    }
}
