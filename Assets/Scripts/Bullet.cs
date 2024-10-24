using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    private IObjectPool<Bullet> objectPool;
    
    // Deactivate after a certain amount of time. 
    [SerializeField] private float destroyTime = 3f;

    // public property to give the bullet a reference to its ObjectPool
    public IObjectPool<Bullet> ObjectPool { set => objectPool = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine(destroyTime));
    }

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Reset the moving rigidbody
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Release allows the object to return itself back to the pool. 
        objectPool.Release(this);  
    }

}
