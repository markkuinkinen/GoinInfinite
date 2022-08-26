using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flappyAntSpawner : MonoBehaviour
{
    public GameObject enemy;
    public flappyAntPlayer player;

    public int xSpawnTracker = 10;
    public int xPlayerTracker;
    public int thirdNumberChance;

    public float randomNumber;
    public float secondRandomNumber;
    public float thirdRandomNumber;

    void Update()
    {
        xPlayerTracker = (int)player.GetComponent<Transform>().position.x;
        if (player.isAlive && (xSpawnTracker < (xPlayerTracker + 25)))
        {
            spawner();
        }
    }

    public void spawner()
    {
        randomNumber = Random.Range(-5f, 5.41f);
        secondRandomNumber = Random.Range(-5f, 5.41f);

        thirdNumberChance = Random.Range(0, 4);
        thirdRandomNumber = Random.Range(-5f, 5.41f);

        GameObject enemyClone = Instantiate(enemy, new Vector3(xSpawnTracker, randomNumber, 0f), Quaternion.identity);
        GameObject secondEnemyClone = Instantiate(enemy, new Vector3(xSpawnTracker, secondRandomNumber, 0f), Quaternion.identity);

        if (thirdNumberChance == 0) //25% chance at spawning a third
        {
            GameObject thirdEnemyClone = Instantiate(enemy, new Vector3(xSpawnTracker, thirdRandomNumber, 0f), Quaternion.identity);
        }
        xSpawnTracker += 5;
    }
}
