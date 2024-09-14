using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemies : MonoBehaviour
{
    public static int currentRound { get; private set; }

    [SerializeField] private GameObject[] spawnPositions, enemies;

    private Vector3 enemySpawnPosition;

    private bool reachedTargetAmountOfEnemiesSpawned = false;

    private int spawnPositionIndex, enemiesIndex, spawnRate = 3;
    private int amountOfEnemiesToSpawn = 3; // this will always 
    private int amountOfEnemiesToAdd = 2;
    private int amountofEnemiesSpawned = 0;


    public static int currentAmountOfEnemies;
    // Need to abstract out this static class variable

    void Start()
    {
        currentRound = 1;
        StartCoroutine(SpawnRate());
    }

    IEnumerator SpawnRate()
    {
        while (Enemies.playerDead == false)
        {
            while (amountofEnemiesSpawned <= amountOfEnemiesToSpawn && reachedTargetAmountOfEnemiesSpawned == false)
            { 
                SpawnEnemy();
                amountofEnemiesSpawned++;
                currentAmountOfEnemies++;

                if (amountofEnemiesSpawned == amountOfEnemiesToSpawn)
                {
                    reachedTargetAmountOfEnemiesSpawned = true;
                }

                yield return new WaitForSeconds(spawnRate);
            }
            if (reachedTargetAmountOfEnemiesSpawned == true && currentAmountOfEnemies == 0)
            {
                currentRound++;
                amountofEnemiesSpawned = 0;
                amountOfEnemiesToSpawn += amountOfEnemiesToAdd;

                reachedTargetAmountOfEnemiesSpawned = false;

            }

            yield return new WaitForSeconds(1); // adding this line stopped it from crashing? I need to figure out why this is the case. 
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
