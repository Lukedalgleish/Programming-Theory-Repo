using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //public InGameUI inGameUIScript;

    protected int health;
    protected int movementSpeed = 10;
    protected int bulletDamage = 50;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletDamage();

        if (other.CompareTag("Player"))
        {
            //inGameUIScript.DeathScreen();

            SpawnEnemies.gameover = true;
            Debug.Log("Game over!"); 
        }
    }

    public void BulletDamage()
    {
        health -= bulletDamage;

        if(health <= 0)
        {
            Destroy(gameObject);
            SpawnEnemies.currentAmountOfEnemies--;
            Debug.Log("The current amount of Enemies now alive: " + SpawnEnemies.currentAmountOfEnemies);
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerMovement.playerPositionInstance, movementSpeed * Time.deltaTime);
    }

}
