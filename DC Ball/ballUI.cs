using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ballUI : MonoBehaviour
{
    public Text scoreText;
    public Text deathText;
    public Text highScoreText;
    public Text controlsText;
   
    public Button replayButton;
    public Button menuButton;
   
    public static int score; 
    public static int highscore;
    public bool highscoreGot;
    private float timer;
    private float scoreTimer;
    
    public GameObject deathSquare;
    private playerController player;
   
    void Start()
    {
        player = FindObjectOfType<playerController>();
        deathText.enabled = false;
        deathSquare.SetActive(false);
        replayButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        highscoreGot = false;
        score = 0;
        controlsText.enabled = false;
    }

    void Update()
    {
        scoreText.text = score.ToString();
        highScoreText.text = highscore.ToString();

        if (!player.isAlive)
        {
            highScoreText.enabled = false;
            scoreText.enabled = false;
            deathSquare.SetActive(true);
            checkHighScore();
            deathText.enabled = true;
            replayButton.gameObject.SetActive(true);
            replayButton.enabled = true;
            controlsText.enabled = true;
            menuButton.gameObject.SetActive(true);
            menuButton.enabled = true;
            playAgain();
        } 
        else
        {
            timer += Time.deltaTime;
            scoreTracker();
        }
    }


    public void checkHighScore()
    {
        if (score == 0 || score > highscore)
        {
            highscoreGot = true;
        } 
        if (highscoreGot)
        {
            highscore = score;
            deathText.text = "You're dead!\n\nNew High Score!\nYour score was " + score + "\nCurrent high score: " + highscore + "\nYou survived roughly " + timer + " seconds\n";
        }
        else
        {
            deathText.text = "You're dead!\n\nYour score was " + (score - 100) + "\nCurrent high score: " + highscore + "\nYou survived roughly " + timer + " seconds\n";
        }
    }

    public void scoreTracker()
    {
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= 1f)
        {
            score += 100;
            scoreTimer = 0;
        } 
    }

    public void playAgain()
    {
        if (!player.isAlive && Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            loadGame("BallGame");
        }
    }

    public void loadGame(string sceneName)
    {
        highScoreText.enabled = true;
        SceneManager.LoadScene(sceneName);
        score = 0;
        timer = 0;
        scoreTimer = 0;
        spawner.moveSpeed = 3f;
        spawner.spawnCounter = 0;
    }
}
