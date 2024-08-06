using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPositions;
    [SerializeField] private GameObject[] enemies;
    private int spawnPositionIndex, enemiesIndex, amountOfEnemies = 1, spawnRate = 5;
    private Vector3 enemySpawnPosition;
    public bool gameover = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawningEnemies()
    {
        while (gameover == false)
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
