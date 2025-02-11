using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main2 : MonoBehaviour
{
    public int score;
    public bool GameOver;
    public Transform title;
    public TextMeshProUGUI scoreboard;
    public GameObject restartButton;
    public TextMeshProUGUI resultText;

    public TextMeshProUGUI buttonText;

    void Start()
    {
        score = 0;
        GameOver = false;
        scoreboard.text = "0";
        title.localPosition = new Vector3(0f, 1000f, 0f);
        restartButton.SetActive(false);
        resultText.text = "";
    }

    void Update()
    {
        if (GameOver)
        {
            title.localPosition = new Vector3(0f, 0f, 0f);
            restartButton.SetActive(true);
        }
    }

    public void ScoreAdd()
    {
        if (!GameOver)  // Only add score if the game is not over
        {
            score++;
            scoreboard.text = score.ToString();
        }
    }

    public void NewGame()
    {
        if (buttonText.text == "Go To Next Level")
        {
            // Load the next scene in the build settings
            SceneManager.LoadScene("Level3Scene");
        }
        else if (buttonText.text == "Restart")
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Reset variables
        score = 0;
        GameOver = false;
        scoreboard.text = "0";
        title.localPosition = new Vector3(0f, 1000f, 0f);
        restartButton.SetActive(false);
        resultText.text = "";
    }


    public void DisplayWin()
    {
        StopScore();  // Stop score and update UI
        resultText.text = "You Win!\nYour score is: " + score.ToString();
        resultText.alignment = TextAlignmentOptions.Center;
        resultText.rectTransform.localPosition = new Vector3(0f, 150f, 0f); // Center the text
        buttonText.text = "Go To Next Level";
        restartButton.SetActive(true);
    }

    public void DisplayGameOver()
    {
        StopScore();  // Stop score and update UI
        resultText.text = "Game Over!!";
        resultText.alignment = TextAlignmentOptions.Center;
        resultText.rectTransform.localPosition = new Vector3(0f, 130f, 0f); // Center the text
        buttonText.text = "Restart";
        restartButton.SetActive(true);
    }

    // Stop score updates and set GameOver flag
    public void StopScore()
    {
        GameOver = true;
    }

    // Public method to check if the game is over
    public bool IsGameOver()
    {
        return GameOver;
    }
}