using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected int health;
    protected int movementSpeed = 10;
    protected int bulletDamage = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletDamage();

        if (other.CompareTag("Player"))
        {
            //SpawnEnemies.gameover = true;
            Debug.Log("Game over!"); 
        }
    }

    public void BulletDamage()
    {
        health -= bulletDamage;
        Debug.Log(gameObject.name + " " + health);

        if(health <= 0)
        {
            Destroy(gameObject);
            SpawnEnemies.currentAmountofEnemies--;
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerMovement.playerPositionInstance, movementSpeed * Time.deltaTime);
    }

}
