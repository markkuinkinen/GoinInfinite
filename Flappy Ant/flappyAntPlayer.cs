using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flappyAntPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public bool isAlive;
    public bool gameStarted;

    public float moveSpeed = 5f;
    public float timer;

    public Camera playerCamera;
    public Text startText;

    void Start()
    {
        isAlive = true;
        gameStarted = false;
        startText.enabled = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        startGame();
        if (isAlive && gameStarted)
        {
            movespeedIncreaser();
            otherDirectioner();
            moveCamera();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void startGame()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            startText.enabled = false;
            gameStarted = true;
        }
    }

    public void moveCamera()
    {
        playerCamera.GetComponent<Transform>().position = new Vector3(this.gameObject.GetComponent<Transform>().position.x, 0f, -1);
    }

    public void movespeedIncreaser()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            moveSpeed += 1f;
            timer = 0f;
        }
    }

    public void otherDirectioner()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0f, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0f, -moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            isAlive = false;
        }
    }
}
