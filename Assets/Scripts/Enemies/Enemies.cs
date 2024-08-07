using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected int health;
    protected int movementSpeed = 10;
    protected int bulletDamage = 50;
    //[SerializeField] protected GameObject player;
    protected int EnemiesStayAtPosY = 1;

    //public Transform player;
    //public Vector3 playerPos;

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
        
        DealDamage();
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DealDamage()
    {
        health -= bulletDamage;
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerMovement.playerPositionInstance, movementSpeed * Time.deltaTime);
    }

}
