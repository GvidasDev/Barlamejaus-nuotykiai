using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingToMainMenu : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("Main menu");
    }
}
