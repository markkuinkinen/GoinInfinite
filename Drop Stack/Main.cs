using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Main : MonoBehaviour
{
    public GameObject towerPiece;
    public Transform spawnLocation;
    public Rigidbody2D rb;
    public Transform playerCamera;
    public Rigidbody2D playerCamerarb;
    public towerUI UI;

    public List<GameObject> towerPieceList = new List<GameObject>();

    public int spawnLocationX;
    public int spawnLocationY;

    public float moveSpeed = 5f;

    public bool gameOver;
    public bool gameStarted;

    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    void Update()
    {
        if (!gameOver)
        {
            moveCamera();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (towerPieceList.Count != 0)
                {
                    stopPiece();
                }
                if (towerPieceList.Count == 0)
                {
                    spawnPiece();
                }
                else if (towerPieceList.Last().GetComponent<blockCode>().isTouching)
                {
                    spawnPiece();
                }
                else if (!(towerPieceList.Last().GetComponent<blockCode>().isTouching))
                {
                    towerPieceList.Last().GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                    gameOver = true;
                }
            }         
        }
        else
        {
            playerCamerarb.velocity = new Vector2(0f, 0f);
        }
    }

    public void moveCamera()
    {
        if (playerCamera.transform.position.y < (towerPieceList.Count - 1))
        {
            playerCamerarb.velocity = new Vector2(0f, 1.5f);
        } 
        else
        {
            playerCamerarb.velocity = new Vector2(0f, 0f);
        }    
    }

    public void stopPiece()
    {
        if (towerPieceList.Last().GetComponent<blockCode>().isTouching)
        {
            Rigidbody2D CloneRB = towerPieceList.Last().GetComponent<Rigidbody2D>();
            CloneRB.velocity = new Vector2(0f, 0f);
        }
    }

    public void spawnPiece()
    {
        spawnLocationX = Random.Range(0, 11);
        spawnLocationY = towerPieceList.Count;

        spawnLocation.position = new Vector2(spawnLocationX, spawnLocationY);

        GameObject latestPiece = Instantiate(towerPiece, spawnLocation.position, spawnLocation.rotation);
        
        SpriteRenderer cloneSrend = latestPiece.GetComponent<SpriteRenderer>();
        cloneSrend.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        towerPieceList.Add(latestPiece);
        moveSpeed += 0.3f;

        Rigidbody2D CloneRB = latestPiece.GetComponent<Rigidbody2D>();

        int directionDecider = Random.Range(-1, 1);
        if (directionDecider == -1)
        {
            CloneRB.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            CloneRB.velocity = new Vector2(-moveSpeed, 0f);
        }   
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "rightWall")
        {
            moveSpeed *= -1;
        }
        if (other.tag == "leftWall")
        {
            moveSpeed *= -1;
        }
    }
}
