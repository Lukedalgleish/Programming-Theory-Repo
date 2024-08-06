using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected int health;
    protected int movementSpeed;
    protected int bulletDamage = 50;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DealDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        DealDamage();
        Debug.Log(health + gameObject.name);
        if (health <= 0)
        {
            Debug.Log(health);
            Destroy(gameObject);
        }
    }

    public virtual void DealDamage()
    {
        health -= bulletDamage;
    }
}
