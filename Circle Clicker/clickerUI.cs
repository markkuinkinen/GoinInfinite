using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clickerUI : MonoBehaviour
{
    public Text[] deathTexts;
    public Text niceDeathText;
    public Text extraText;
    public Text controlsText;
    public Text scoreText;
    public Text highscoreText;

    public Button replayButton;
    public Button exitButton;

    public static int highScore;
    public int randomNumber;
    private float postDeathTimer;

    public CircleScript player;
    public bool gameOver;

    void Start()
    {
        replayButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        niceDeathText.enabled = false;
        extraText.enabled = false;
        gameOver = false;
        controlsText.enabled = true;
        randomNumber = Random.Range(0, 5);  

        foreach (Text items in deathTexts)
        {
            items.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.score.ToString();
        highscoreText.text = highScore.ToString();

        if (player.score > highScore)
        {
            highScore = player.score;
        }

        if (gameOver)
        {
            replayButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
            deathTextDecider();
            extraText.enabled = true;

            postDeathTimer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && postDeathTimer > 0.2f)
            {
                postDeathTimer = 0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        } 
        
        if (player.score >= 1)
        {
            controlsText.enabled = false;
        }
    }

    public void deathTextDecider()
    {
        if (player.score == (1518/22))
        {
            niceDeathText.enabled = true;
        }
        else
        {
            deathTexts[randomNumber].enabled = true;
        }
    }    
}
