using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Gun : MonoBehaviour
{

    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private int muzzleVelocity = 700;

    [SerializeField] private GameObject gunMuzzle;

    [SerializeField] GameObject oritentation; // Can we make this better by using a get/set?

    // throws an exception if we try to return an exissting item thats already in the pool. Not seen this issue in action yet. 
    [SerializeField] private bool collectionCheck = true; 

    private IObjectPool<Bullet> objectPool;

    [SerializeField] private int defaultCapacity = 30;
    [SerializeField] private int maxCapacity = 60;

    private void Awake()
    {
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestoryPooledObject, collectionCheck, defaultCapacity, maxCapacity);
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot the gun if the pool isnt empty 
        if (Input.GetButtonDown("Fire1") && objectPool != null)
        {
            // Get a pooled object instead of instantiating
            Bullet bulletObject = objectPool.Get();

            if (bulletObject == null) { return; }

            // Set its position and rotation
            bulletObject.transform.SetPositionAndRotation(gunMuzzle.transform.position, oritentation.transform.rotation);

            // Move the bullet
            bulletObject.GetComponent<Rigidbody>().AddForce(transform.up * muzzleVelocity, ForceMode.Acceleration);

            // Stop the bullet after a certain amount of time. 
            bulletObject.Deactivate();

        }
    }
    // This method is where we create a new bullet if the pool is empty.
    private Bullet CreateBullet()
    {
        Bullet bulletInstance = Instantiate(bulletPrefab);

        /* we set an objectpool property on the bullet instance. this is so the insatnce can have access to the object pool.
           This is useful because the bullet can release itself back to the pool after a certain amount of time or collision. */
        bulletInstance.ObjectPool = objectPool; 

        return bulletInstance;
    }

    // This method is executed when retrieving the next item from the pool. 
    private void OnGetFromPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    // this method is called when we return an instance back to the pool.
    private void OnReleaseToPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    // This is called if the pool reaches its max size and you add more objects to the pool.
    private void OnDestoryPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

}
