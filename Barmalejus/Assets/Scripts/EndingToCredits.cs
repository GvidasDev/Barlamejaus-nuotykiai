using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingToCredits : MonoBehaviour
{
    private LevelLoader levelLoader;
    private void Start()
    {
        GameObject gameObject = GameObject.Find("LevelLoader");
        levelLoader = gameObject.GetComponent<LevelLoader>();
        levelLoader.LoadNextLevel("Credits");
    }
}
