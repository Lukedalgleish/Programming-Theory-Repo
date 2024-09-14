using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public static bool playerDead { get; private set; }
    protected int health;
    protected int bulletDamage = 50;


    private void Start()
    {
        playerDead = false;
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

        if(health <= 0)
        {
            Destroy(gameObject);
            SpawnEnemies.currentAmountOfEnemies--;
        }
    }

    public void FollowPlayer(int movementSpeed)
    {
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerMovement.playerPositionInstance, movementSpeed * Time.deltaTime);
    }

}
