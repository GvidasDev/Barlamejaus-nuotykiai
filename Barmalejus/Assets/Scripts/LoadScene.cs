using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    Scene devScene;
    Scene island;
    // Start is called before the first frame update
    void Start()
    {
        devScene = SceneManager.GetSceneByName("DevMap");
        island = SceneManager.GetSceneByName("Island");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(","))
        {
            LoadDevScene();
        }
        if (Input.GetKeyDown("."))
        {
            LoadIslandScene();
        }
    }
    void LoadDevScene()
    {
        SceneManager.LoadSceneAsync("DevMap");
        if (island.isLoaded)
        {
            SceneManager.UnloadScene("Island");
        }
    }
    void LoadIslandScene()
    {
        SceneManager.LoadSceneAsync("Island");
        if(devScene.isLoaded)
        {
            SceneManager.UnloadScene("DevMap");
        }

    }
}
