using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]private Text label;
    [SerializeField] private GameObject panel;
    [SerializeField] private float startTime = 600; // Time in seconds (e.g., 300 seconds = 5 minutes)
    [SerializeField] private float timeRemaining;
    private bool isRunning = false;

    void Start() {
        timeRemaining = startTime;
        isRunning = true;
    }

    void Update() {
        if (isRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else {
                timeRemaining = 0;
                isRunning = false;
                UpdateTimerDisplay(timeRemaining);
                OnTimerEnd();
            }
        }
        if (panel.activeInHierarchy) {
            Restart();
            Exit();
        }
    }

    void UpdateTimerDisplay(float timeToDisplay) {
        timeToDisplay += 1; // Adding one second for proper display
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        label.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer() {
        isRunning = false;
    }

    public void StartTimer() {
        isRunning = true;
    }

    public void ResetTimer() {
        timeRemaining = startTime;
        isRunning = false;
        UpdateTimerDisplay(timeRemaining);
    }

    void OnTimerEnd() {
        Debug.Log("Timer ended!");
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    void Restart() {
        if (Input.GetKeyDown(KeyCode.M)) {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync("Main menu");
        }
    }

    void Exit() {
        if (Input.GetKeyDown(KeyCode.N)) {
            Application.Quit();
        }
    }
}
