using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{   
    private Rigidbody rb;
    private float bulletVelocity = 2.5f;
    [SerializeField] private float destroyTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        rb.AddForce(transform.forward * bulletVelocity, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
