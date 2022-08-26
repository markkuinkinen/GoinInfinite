using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class towerUI : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public Text deathText;
    public Text startText;
    public Text timerText;

    public Button replayButton;
    public Button returnButton;

    public Main mainScript;

    public int score;
    public static int highScore;
    public float postDeathTimer;

    void Start()
    {
        replayButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        deathText.enabled = false;
        scoreText.enabled = false;      
    }

    void Update()
    {
        score = (mainScript.towerPieceList.Count - 1);
        if (score > highScore)
        {
            highScore = score;
        }

        scoreText.text = (mainScript.towerPieceList.Count - 1).ToString();
        highscoreText.text = highScore.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            scoreText.enabled = true;
            startText.enabled = false;
        }

        if (mainScript.gameOver)
        {
            postDeathTimer += Time.deltaTime;
            replayButton.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(true);
            deathText.enabled = true;
            deathText.text = "You lost\n\nBetter luck next time";

            if (Input.GetKeyDown(KeyCode.Space) && postDeathTimer > 0.2f)
            {
                postDeathTimer = 0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
