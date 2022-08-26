using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] Spawnables;
    public Transform[] spawnLocations;

    public playerController player;

    public int randomInt;

    public static int spawnCounter;
    private int spawnLimit = 16;
    private int typeDecider;
    public static float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnRoutine");
        moveSpeed = 3;
    }


    private IEnumerator spawnRoutine()      //this starts a coroutine (timer) that allows for me to do this every x amount of seconds
    {
        while (player.isAlive)
        {
            yield return new WaitForSeconds(100f / ((float)spawnCounter + 150f));          
            
            randomInt = Random.Range(0, spawnLimit);    //first i get a random number within this range (this is the spawn positions)
            
            spawnEnemies(randomInt);    //then i spawn enemies using that number

            updateSpawner();
            spawnCounter++;

            if (!player.isAlive)
            {
                StopCoroutine("spawnRoutine");
            }
        }
    }

    void updateSpawner()
    {
        if (spawnCounter % 10 == 0)
        {
            moveSpeed += 1f;
        }
    }

    void spawnEnemies(int randomNumber)     //based on the number it'll spawn left/top/right/bottom side 
    {
        typeDecider = (int)Random.Range(0, 5);

        if (randomNumber <= 3)
        {
            if (typeDecider >= 1)
            {
                Object.Instantiate(Spawnables[0], spawnLocations[randomNumber].position, spawnLocations[randomNumber].rotation);
            }
            else
            {
                Object.Instantiate(Spawnables[1], spawnLocations[randomNumber].position, spawnLocations[randomNumber].rotation);
            }
        }      
        if (randomNumber > 3 && randomNumber <= 7)
        {
            if (typeDecider >= 1)
            {
                Object.Instantiate(Spawnables[2], spawnLocations[randomNumber].position, spawnLocations[randomNumber].rotation);
            }
            else
            {
                Object.Instantiate(Spawnables[3], spawnLocations[randomNumber].position, spawnLocations[randomNumber].rotation);
            }
        }       
        if (randomNumber > 7 && randomNumber <= 11)
        {
            if (typeDecider >= 1)
            {
                Object.Instantiate(Spawnables[4], spawnLocations[randomNumber].position, spawnLocations[randomNumber].rotation);
            }
            else
            {
                Object.Instantiate(Spawnables[5], spawnLocations[randomNumber].position, spawnLocations[randomNumber].rotation);
            }
        }      
        if (randomNumber >= 12)
        {
            if (typeDecider >= 1)
            {
                Object.Instantiate(Spawnables[6], spawnLocations[randomNumber].position, spawnLocations[randomNumber].rotation);
            }
            else
            {
                Object.Instantiate(Spawnables[7], spawnLocations[randomNumber].position, spawnLocations[randomNumber].rotation);
            }
        }
    }

}
