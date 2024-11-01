using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPositions, enemies;
    private Vector3 enemySpawnPosition;
    public static int currentRound { get; private set; }
    public static bool allEnemiesAreDead { get; private set; }

    private bool reachedTargetAmountOfEnemiesSpawned = false;
    private int spawnPositionIndex, enemiesIndex, spawnRate = 2;
    private int amountofEnemiesSpawned = 0;
    private int amountOfEnemiesToSpawn = 3;
    private int amountOfEnemiesToAdd = 2;
    private float timer = 0f;

    void Start()
    {
        allEnemiesAreDead = false;
        currentRound = 1;
    }

    private void Update()
    {
        if (Enemies.playerDead == true)
        {
            return;
        }

        if (reachedTargetAmountOfEnemiesSpawned == true)
        {
            CheckIfAllEnemiesAreDead();
            return;
        }

        timer += Time.deltaTime;
        
        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        allEnemiesAreDead = false; 
        ChooseRandomEnemy();
        ChooseRandomSpawnLocation();
        Instantiate(enemies[enemiesIndex], enemySpawnPosition, gameObject.transform.rotation);
        amountofEnemiesSpawned++;

        if (amountofEnemiesSpawned == amountOfEnemiesToSpawn)
        {
            reachedTargetAmountOfEnemiesSpawned = true;
        }
    }

    private void CheckIfAllEnemiesAreDead()
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

    private void ChooseRandomEnemy()
    {
        enemiesIndex = Random.Range(0, enemies.Length);
    }

    private void ChooseRandomSpawnLocation()
    {
        spawnPositionIndex = Random.Range(0, spawnPositions.Length);
        enemySpawnPosition = spawnPositions[spawnPositionIndex].transform.position;
    }
}
