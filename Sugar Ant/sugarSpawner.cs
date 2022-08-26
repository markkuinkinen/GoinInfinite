using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sugarSpawner : MonoBehaviour
{
    public Transform sugarSpawnLocation;
    public Transform enemySpawnLocation;

    public List<string> takenPositions = new List<string>();
    
    public int sugarRandomNumberX;
    public int sugarRandomNumberY;
    public int enemyRandomNumberX;
    public int enemyRandomNumberY;
    public int spawnLimiter = 1;
    public bool isAlive;

    public GameObject sugar;
    public GameObject enemy;
    public snakeController player;

    public string valueToAdd;
    public string sugarValueToAdd;
    public string currentSugarPosition;

    public float timer;

    void Update()
    {
        if (player.isAlive)
        {
            sSpawner();
            enemySpawner();   
        } 
        else if (!player.isAlive)
        {
            takenPositions.Clear();
        }
    }

    public void sSpawner()
    {
        if (!isAlive && spawnLimiter == 1)
        {            
            isAlive = true;
            if (player.sugarCollected < 6)
            {               
                sugarRandomNumberX = Random.Range(0, 20);
                sugarRandomNumberY = Random.Range(-10, 10);
                sugarSpawnLocation.position = new Vector3(sugarRandomNumberX, sugarRandomNumberY, 0f);
                currentSugarPosition = sugarRandomNumberX.ToString() + sugarRandomNumberY.ToString();
                spawnLimiter--;
            } 
            else
            {
                sugarRandomNumberX = Random.Range(-22, 42);
                sugarRandomNumberY = Random.Range(-16, 17);
                sugarSpawnLocation.position = new Vector3(sugarRandomNumberX, sugarRandomNumberY, 0f);
                currentSugarPosition = sugarRandomNumberX.ToString() + sugarRandomNumberY.ToString();
                spawnLimiter--;
            }
            checkLocation(currentSugarPosition, sugarRandomNumberX, sugarRandomNumberY, false);    //check to prevent sugar spawning on enemy
            GameObject sugarClone = Instantiate(sugar, sugarSpawnLocation.position, sugarSpawnLocation.rotation);
        }
    }

    public void enemySpawner()
    {
        if (player.sugarCollected > 0)
        {
            timer += Time.deltaTime;

            if (timer > 1.75f)
            {
                enemyRandomNumberX = Random.Range(-22, 42);     //first generates 2 random spawn locations
                enemyRandomNumberY = Random.Range(-16, 17);

                enemySpawnLocation.position = new Vector3(enemyRandomNumberX, enemyRandomNumberY, 0f);  //sets spawn position based on random numbers
                valueToAdd = enemyRandomNumberX.ToString() + enemyRandomNumberY.ToString();     //sets spawn location as string
                
                checkLocation(valueToAdd, enemyRandomNumberX, enemyRandomNumberY, true);      //checks list to see if it already contains location (as string), if so then rerolls
                takenPositions.Add(valueToAdd);  //adds string position to list 

                GameObject enemyClone = Instantiate(enemy, enemySpawnLocation.position, enemySpawnLocation.rotation);
                
                timer = 0;
            }
        }
    }

    public void checkLocation(string rolledPos, int x, int y, bool enemy)
    {
        if (takenPositions.Contains(rolledPos)) //checks value to add within takenPositions list
        {
            if (enemy || rolledPos.Equals(currentSugarPosition))
            {
                reroll(x, y);
            }
            else
            {
                rerollSugar(x, y);
            }
        }
    }

    public void rerollSugar(int x, int y)
    {
        x = Random.Range(-22, 42);
        y = Random.Range(-16, 17);
        sugarSpawnLocation.position = new Vector3(x, y, 0f);
        sugarValueToAdd = x.ToString() + y.ToString();
        checkLocation(sugarValueToAdd, x, y, false);
        GameObject sugarClone = Instantiate(enemy, enemySpawnLocation.position, enemySpawnLocation.rotation);
    }

    public void reroll(int x, int y)
    {
        x = Random.Range(-22, 42);    
        y = Random.Range(-16, 17);
        enemySpawnLocation.position = new Vector3(x, y, 0f);
        valueToAdd = x.ToString() + y.ToString();
        checkLocation(valueToAdd, x, y, true);
        takenPositions.Add(valueToAdd);
        GameObject enemyClone = Instantiate(enemy, enemySpawnLocation.position, enemySpawnLocation.rotation);
    }
}
