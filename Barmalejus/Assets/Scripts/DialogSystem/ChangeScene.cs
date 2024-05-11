using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Function to change scene to the island scene
    public void ChangeToIslandScene()
    {
        SceneManager.LoadScene("Island"); // Replace "IslandSceneName" with the name of your island scene
    }
}
