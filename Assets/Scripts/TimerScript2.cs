using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript2 : MonoBehaviour
{
    public float timeRemaining = 30;
    public bool timeIsRunning = true;
    public TMP_Text timerText;
    public bool isPlayerDead = false;
    private Main2 mainScript;

    void Start()
    {
        timeIsRunning = true;
        mainScript = GameObject.Find("generator2").GetComponent<Main2>();
    }

    void Update()
    {
        if (timeIsRunning && !isPlayerDead)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timeIsRunning = false;
                mainScript.DisplayWin();
                mainScript.StopScore();  // Stop the score when the timer ends
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Clamp(timeToDisplay, 0, Mathf.Infinity);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OnPlayerDeath()
    {
        isPlayerDead = true;
        timeIsRunning = false;
        mainScript.DisplayGameOver();
        mainScript.StopScore();  // Stop the score when the player dies
    }

    // Public method to check if the timer is running
    public bool IsTimerRunning()
    {
        return timeIsRunning;
    }
}