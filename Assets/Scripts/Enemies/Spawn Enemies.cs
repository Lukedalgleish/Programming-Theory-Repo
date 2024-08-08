using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPositions, enemies;
    private int spawnPositionIndex, enemiesIndex, spawnRate = 2, currentRound = 1;

    private int amountOfEnemiesToSpawn = 3;
    private int i = 0;
    private int amountOfEnemiesToAdd = 2;
    public static int currentAmountofEnemies; // need to encapsulate this


    private Vector3 enemySpawnPosition;

    public static bool gameover = false; // need to change this to encapsulate this at some point 

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    private void Update()
    {
        if (currentAmountofEnemies == 0)
        {
            amountOfEnemiesToSpawn += amountOfEnemiesToAdd;
            currentRound++;
            Debug.Log("You have made it to round" + currentRound);
        }
    }

    IEnumerator SpawningEnemies()
    {

        for (int i = 0; i < amountOfEnemiesToSpawn; i++)
        {

            ChooseRandomEnemy();
            ChooseRandomSpawnLocation();
            SpawnEnemyLogic();
            yield return new WaitForSeconds(spawnRate);

        }
        
    }

    private void SpawnEnemyLogic()
    {
        Instantiate(enemies[enemiesIndex], enemySpawnPosition, gameObject.transform.rotation);
        currentAmountofEnemies++;
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
