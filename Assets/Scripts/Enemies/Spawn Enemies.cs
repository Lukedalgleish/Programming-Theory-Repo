using System.Collections;
using UnityEngine;


public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPositions, enemies;
    private Vector3 enemySpawnPosition;
    public static int currentRound { get; private set; }
    //public static int amountOfEnemiesToSpawn { get; private set; }
    //public static int amountOfEnemiesToAdd { get; private set; }
    public static bool allEnemiesAreDead { get; private set; }

    private bool reachedTargetAmountOfEnemiesSpawned = false;
    private int spawnPositionIndex, enemiesIndex, spawnRate = 3;
    private int amountofEnemiesSpawned = 0;
    private int amountOfEnemiesToSpawn = 3;
    private int amountOfEnemiesToAdd = 2;

    void Start()
    {
        allEnemiesAreDead = false;
        currentRound = 1;
        StartCoroutine(StartSpawningEnemies());
    }

    IEnumerator StartSpawningEnemies()
    {
        while (Enemies.playerDead == false)
        {
            while (amountofEnemiesSpawned <= amountOfEnemiesToSpawn && reachedTargetAmountOfEnemiesSpawned == false)
            { 
                SpawnEnemy();
                amountofEnemiesSpawned++;

                if (amountofEnemiesSpawned == amountOfEnemiesToSpawn)
                {
                    reachedTargetAmountOfEnemiesSpawned = true;
                }

                yield return new WaitForSeconds(spawnRate); // We need this line to ensure theres an interval between each enemy spawning.
            }

            CheckIfEnemiesAreAllDead();

            yield return new WaitForSeconds(1); 
        }

    }

    private void CheckIfEnemiesAreAllDead()
    {
        if (reachedTargetAmountOfEnemiesSpawned == true && Enemies.destroyedChildCount == amountOfEnemiesToSpawn)
        {
            allEnemiesAreDead = true;
            currentRound++;
            amountofEnemiesSpawned = 0;
            amountOfEnemiesToSpawn += amountOfEnemiesToAdd;
            reachedTargetAmountOfEnemiesSpawned = false;
        }
    }

    private void SpawnEnemy()
    {
        allEnemiesAreDead = false;
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
