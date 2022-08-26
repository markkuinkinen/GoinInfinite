using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flappyPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform playerTrans;

    public float moveSpeed = 1f;
    public float jumpForce = 5f;

    public bool isAlive;
    public bool gameStarted;

    public Camera playerCam;

    void Start()
    {
        isAlive = true;
        gameStarted = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        startGame();

        if (isAlive && gameStarted)
        {
            moveCamera();
            move();
            jump();
        } 
        else
        {
            playerCam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void startGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        } 
    }

    public void move()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    public void moveCamera()
    {
        playerCam.GetComponent<Transform>().position = new Vector3(playerTrans.position.x, 0f, -1);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            isAlive = false;
        }
    }
}
