using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public spawnScript spawner;
    public GameObject player;
    public GameObject projectile;
    public GameObject gun;

    public Text startText;
    public Text controlsText;
   
    public Rigidbody2D rb;
    public Rigidbody2D camerarb;

    public Transform playerTrans;
    public Transform playerCamPos;
    public Transform projectileSpawnLocation;

    private Vector3 sizeChange;
    
    public bool gameOver;
    public bool touchingGround;
    public bool gameStarted;
    public bool canShoot;

    public float moveSpeed;
    public float jumpForce;
    public float xSpeed;
    public float ySpeed;
    public float timer;
    public float fallMultiplier;

    public int yScale;
    public int scoreTracker;

    void Start()
    {
        moveSpeed = 5f;
        jumpForce = 9f;
        fallMultiplier = 3f;
        yScale = 2;
        gameStarted = false;
        startText.enabled = true; 
        controlsText.enabled = true;
    }

    void Update()
    {
        if (!gameOver && gameStarted)
        {
            playerCamPos.position = new Vector2((playerTrans.position.x + 5), 1);
            xSpeed = rb.velocity.x;
            ySpeed = rb.velocity.y;
            scoreTracker = (int)playerTrans.position.x;

            shoot();
            constantMove();
            crouch();
            jump();
            if (!touchingGround)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;    //makes returning to ground from jumper smoother
            }
        } 
        else
        {
            camerarb.velocity = new Vector2(0f, 0f);
            rb.velocity = new Vector2(0f, 0f);
        }
        startGame();    //starts game when space is pressed
    }

    public void startGame()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            gameStarted = true;
            startText.enabled = false;
            controlsText.enabled = false;
        }
    }

    public void constantMove()
    {
        xSpeed = moveSpeed;
        rb.velocity = new Vector2(xSpeed, ySpeed);
        
        timer += Time.deltaTime;
        if (timer > 3) //every 3 seconds movespeed increases by 1 
        {
            moveSpeed += 1;
            timer = 0;
        }
    }

    public void increaseMoveSpeed()
    {
        moveSpeed += 1;
    }

    public void jump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && touchingGround && gameStarted)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void crouch()  //decrease Y scale by half
    {
        playerTrans.localScale = new Vector2(playerTrans.localScale.x, yScale);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))     //if downArrow and "standing (yScale == 2)"
        {
            gun.gameObject.SetActive(false);
            canShoot = false;
            yScale = 1;
            if (touchingGround && playerTrans.position.y >= -1)
            {
                player.transform.position = new Vector2(playerTrans.position.x, -1.5f);
            }         
        } 
        else
        {
            gun.SetActive(true);
            canShoot = true;
            if (playerTrans.position.y == 0)
            {
                player.transform.position = new Vector2(playerTrans.position.x, 0.5f);
            }
            yScale = 2;     
        }
    }

    public void shoot()
    {
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && canShoot)
        {
            GameObject projectileClone = Instantiate(projectile, projectileSpawnLocation.position, projectileSpawnLocation.rotation);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy" || other.tag == "wall")
        {
            gameOver = true;
        }
        if (other.tag == "mover" && !gameOver)
        {
            fallMultiplier += 0.6f;
            jumpForce += 0.5f;
            spawner.moveGround();
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            touchingGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            touchingGround = false;
        }  
    }
}
