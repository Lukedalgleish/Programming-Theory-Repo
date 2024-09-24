using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public static bool playerDead { get; private set; }
    public static int destroyedChildCount { get; private set; }

    protected int health;
    protected int movementSpeed = 10;
    protected int bulletDamage = 50;
    

    private void Start()
    {
        playerDead = false;
    }

    private void Update()
    {
        Debug.Log(destroyedChildCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletDamage();

        if (other.CompareTag("Player"))
        {
            playerDead = true;
        }
    }

    public void BulletDamage()
    {
        health -= bulletDamage;

        if (health <= 0)
        {
            Destroy(gameObject);
            destroyedChildCount++;
            SpawnEnemies.currentAmountOfEnemies--;
            //Debug.Log("The current amount of Enemies now alive: " + SpawnEnemies.currentAmountOfEnemies);
        }
    }

    public void FollowPlayer(int movementSpeed)
    {
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerMovement.playerPositionInstance, movementSpeed * Time.deltaTime);
    }

}
