using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class flappyAntUI : MonoBehaviour
{
    public flappyAntPlayer player;

    public Text scoreText;
    public Text highscoreText;
    public Text deathText;

    public Button replayButton;
    public Button returnButton;

    public int scoreTracker;
    public static int highScore;
    public float postDeathTimer;

    public bool highscoreGot;

    void Start()
    {
        player = FindObjectOfType<flappyAntPlayer>();
        replayButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        deathText.enabled = false;
        highscoreGot = false;
    }

    void Update()
    {
        scoreTracker = (int)player.GetComponent<Transform>().position.x;
        scoreText.text = scoreTracker.ToString();
        highscoreText.text = highScore.ToString();

        if (!player.isAlive)
        {
            if (highScore == 0 || scoreTracker > highScore)
            {
                highScore = scoreTracker;
                highscoreGot = true;
            }

            if (highscoreGot)
            {
                deathText.text = "Game Over!\n\nNew High Score!";
            }
            else
            {
                deathText.text = "Game Over!";
            }
            deathText.enabled = true;
            replayButton.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(true);

            postDeathTimer += Time.deltaTime;
            if (postDeathTimer > 0.5f && Input.GetKeyDown(KeyCode.Space))
            {
                postDeathTimer = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
