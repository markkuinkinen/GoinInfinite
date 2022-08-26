using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public playerScript player;
    public GameObject[] obstacles;
    public GameObject Ground;
    
    public Transform[] obstaclePositions;
    public Transform currentSpawnLocation;

    public float playerXTracker;
    public int obstacleTracker = 0; 
    public int mapTracker = 0;
    public int randomNumber;

    public bool groundSpawnTime;
    public bool groundHasSpawned;

    void Start()
    {
        currentSpawnLocation.position = new Vector2(0, 0);
        groundHasSpawned = false;
    }

    void Update()
    {
        playerXTracker = (int)player.playerTrans.position.x;
        currentSpawnLocation.position = new Vector2(obstacleTracker, 0);
        if (!player.gameOver)
        {
            obstacleSpawnController();
        }
    }

    public void moveGround()
    {
        Ground.transform.position = new Vector2(playerXTracker + 25f, -2.5f);
    }

    public void obstacleSpawnController()
    {
        if ((playerXTracker == 0 || playerXTracker % 40 == 0) && obstacleTracker < (playerXTracker + 80))
        {
            randomObstacleSpawner();     
        }
    }

    public void randomObstacleSpawner()
    {
        int randomNumber = Random.Range(0, 3);
        if (randomNumber == 0)
        {
            spawnWall();
        } 
        else if (randomNumber == 1)
        {
            spawnSpike();
        }
        else if (randomNumber == 2)
        {
            spawnHover();
        }
    }

    public void spawnWall()
    {
        GameObject wallClone = Instantiate(obstacles[0], new Vector3(obstacleTracker, -0.5f, 0f), Quaternion.identity);
        obstacleTracker += 10;
    }

    public void spawnSpike()
    {
        Quaternion tiltedPos = Quaternion.Euler(0, 0, 45);

        GameObject spikeClone = Instantiate(obstacles[1], new Vector3(obstacleTracker, -2f, 0f), tiltedPos);
        obstacleTracker += 10;
    }

    public void spawnHover()
    {
        GameObject hoverClone = Instantiate(obstacles[2], new Vector3(obstacleTracker, 0, 0f), Quaternion.identity);
        obstacleTracker += 10;
    }
}
