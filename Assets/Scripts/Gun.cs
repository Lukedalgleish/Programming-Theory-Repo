using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public GameObject gunMuzzle;
    public GameObject oritentation;

    // Update is called once per frame
    void Update()
    {
        // Shoot the gun
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, gunMuzzle.transform.position, oritentation.transform.rotation);
        }
    }

}
