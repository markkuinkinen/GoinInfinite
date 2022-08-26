using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snakeController : MonoBehaviour
{
    private Rigidbody2D rb;
    public sugarSpawner spawner;
    public snakeScore scoreUI;
    public bool isAlive;
    public float moveSpeed = 6f;
    public int sugarCollected;
    public Text startText;

    public Camera snakeCamera;

    public float timer;

    void Start()
    {
        startText.enabled = true;
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        scoreUI.placeHolderScore = sugarCollected;
        if (isAlive)
        {
            playerMover();
        } else
        {
            rb.velocity = new Vector2(0, 0);
        }      
    }
    
    public void playerMover()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
            startText.enabled = false;
        }     
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0f, moveSpeed);
            startText.enabled = false;
        }       
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
            startText.enabled = false;
        }       
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0f, -moveSpeed);
            startText.enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "points")
        {
            Object.Destroy(other.gameObject);
            spawner.spawnLimiter = 1;
            
            if (sugarCollected < 4)
            {
                moveSpeed += 2;
            }
            else if (sugarCollected > 3 && sugarCollected < 12)
            {
                moveSpeed += 1;
            }
            
            sugarCollected++;
            scoreUI.snakeCurrentScore++;
            spawner.isAlive = false;
        }

        if (other.tag == "enemy")
        {
            isAlive = false;
        }
    }
}
