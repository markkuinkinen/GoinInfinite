using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CircleScript : MonoBehaviour
{
    public clickerUI ui;
    public Transform location;
    private SpriteRenderer sRend;
    public int score;
    public float timer;
    public float timeLimit = 1.5f;

    public Text timerText;
    public Transform timerTextLocation;

    void Start()
    {
        location = GetComponent<Transform>();
        sRend = GetComponent<SpriteRenderer>();       
    }
    
    void OnMouseDown()
    {   
        if (timer < timeLimit)
        {
            reduceTimeLimit();
            score++;
            changeLocation();
            timer = timeLimit;
        }
    }

    public void changeLocation()
    {
        location.position = new Vector2(Random.Range(-7f, 7.1f), Random.Range(-4f, 4.1f));
    }
    
    void Update()
    {
        timerTextLocation.position = location.position;
        timerText.text = timer.ToString();

        if (score > 0f)
        {
            timer -= Time.deltaTime;    //starts timer after first click

            if (timer <= 0f)        //ends game if timer hits 0
            {
                ui.gameOver = true;
                sRend.enabled = false;
                timerText.enabled = false;
            }
        }   
    }

    public void reduceTimeLimit()
    {
        if (score > 1)
        {
            if (score % 5 == 0 && timeLimit > 0.65f)
            {
                timeLimit -= 0.1f;
            }
        }
    }
}
