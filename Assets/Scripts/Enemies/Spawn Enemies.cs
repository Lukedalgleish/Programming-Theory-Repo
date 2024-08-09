using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPositions, enemies;
    private int spawnPositionIndex, enemiesIndex, spawnRate = 3, currentRound = 1;
    private Vector3 enemySpawnPosition;
    private int amountOfEnemiesToSpawn = 3;
    private int amountOfEnemiesToAdd = 2;
    private bool reachedTargetAmountOfEnemiesSpawned = false;

    
    public int amountofEnemiesSpawned = 0;
    public static int currentAmountOfEnemies;

    public static bool gameover = false; // need to change this to encapsulate this at some point 

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SpawnRate());
    }

    /*private void Update()
    {
        if (amountofEnemiesSpawned <= amountOfEnemiesToSpawn && reachedTargetAmountOfEnemiesSpawned == false)
        {
            ChooseRandomEnemy();
            ChooseRandomSpawnLocation();
            SpawnEnemy();
            amountofEnemiesSpawned++;
            if (amountofEnemiesSpawned == amountOfEnemiesToSpawn)
            {
                reachedTargetAmountOfEnemiesSpawned = true;
            }

            
        }
    }*/

    IEnumerator SpawnRate()
    {
        while (gameover == false)
        {
            if (amountofEnemiesSpawned <= amountOfEnemiesToSpawn && reachedTargetAmountOfEnemiesSpawned == false)
            { 
                SpawnEnemy();
                amountofEnemiesSpawned++;
                currentAmountOfEnemies++;

                if (amountofEnemiesSpawned == amountOfEnemiesToSpawn)
                {
                    reachedTargetAmountOfEnemiesSpawned = true;
                }    
            }
            if (reachedTargetAmountOfEnemiesSpawned == true && currentAmountOfEnemies == 0)
            {
                currentRound++;
                Debug.Log("The current round is: " + currentRound);
                amountofEnemiesSpawned = 0;
                amountOfEnemiesToSpawn += amountOfEnemiesToAdd;

                reachedTargetAmountOfEnemiesSpawned = false;

                Debug.Log("The new amount of enemies that will spawn on round: " + currentRound + " is: " + amountOfEnemiesToSpawn);
            }

            yield return new WaitForSeconds(spawnRate);
        } 
    }

    private void SpawnEnemy()
    {
        ChooseRandomEnemy();
        ChooseRandomSpawnLocation();
        Instantiate(enemies[enemiesIndex], enemySpawnPosition, gameObject.transform.rotation);
    }

    private void ChooseRandomSpawnLocation()
    {
        spawnPositionIndex = Random.Range(0, spawnPositions.Length);
        enemySpawnPosition = spawnPositions[spawnPositionIndex].transform.position;
    }

    private void ChooseRandomEnemy()
    {
        enemiesIndex = Random.Range(0, enemies.Length);
        
    }
}
