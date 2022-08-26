using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class snakeScore : MonoBehaviour
{
    public Text scoreText;
    public Text deathText;
    public Text highScoreText;

    public int snakeCurrentScore;
    public int placeHolderScore;
    public static int snakeSavedHighScore;
    public float postDeathTimer;

    public Button replayButton;
    public Button menuButton;

    public snakeController player;  

    void Start()
    {
        replayButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        deathText.enabled = false;
    }

    void Update()
    {
        scoreText.text = "Score: " + placeHolderScore.ToString();
        saveHighScore();
        highScoreText.text = "High Score: " + snakeSavedHighScore.ToString();

        if (!player.isAlive)
        {
            snakeCurrentScore = 0;
            replayButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            deathText.enabled = true;

            postDeathTimer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && postDeathTimer > 0.2f)
            {
                postDeathTimer = 0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void saveHighScore()
    {
        if (!player.isAlive)
        {
            if (placeHolderScore > snakeSavedHighScore)// && placeHolderScore != 0)
            {
                deathText.text = "You died\n\nNew high score!";
                snakeSavedHighScore = placeHolderScore;
            }
            else if (placeHolderScore < snakeSavedHighScore || placeHolderScore == 0)// || placeHolderScore == snakeSavedHighScore)
            {
                deathText.text = "You died\n\nBetter luck next time!";
            } 
            else if (snakeCurrentScore == snakeSavedHighScore)
            {
                deathText.text = "You died\n\nSO close to that juicy high score..";
            }
        }
    }
}
