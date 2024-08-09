using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : Enemies
{
    void Start()
    {
        health = 200;
        movementSpeed = 8;
    }

    void Update()
    {
        FollowPlayer();
    }
}
