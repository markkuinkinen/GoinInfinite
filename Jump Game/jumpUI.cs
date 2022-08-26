using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jumpUI : MonoBehaviour
{
    public Text scoreText;
    public Text deathText;
    public Text highscoreText;

    public int score;
    public static int highScore;

    public playerScript player;
    public Button returnButton;

    public bool gotHighscore;

    void Start()
    {
        returnButton.gameObject.SetActive(false);
        deathText.enabled = false;
        gotHighscore = false;
    }

    void Update()
    {
        score = player.scoreTracker;
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = highScore.ToString();

        if (player.gameOver)
        {
            returnButton.gameObject.SetActive(true);
            deathText.enabled = true;
            if (player.scoreTracker > highScore)
            {
                highScore = score;
                gotHighscore = true;
            }

            if (gotHighscore)
            {
                deathText.text = "New high score!\n\nPress Space to play again";
            } 
            else
            {
                deathText.text = "Nice try guy\n\nPress Space to play again";
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
