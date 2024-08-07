using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : Enemies
{
    // public Transform player;
    // public Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        movementSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
}
