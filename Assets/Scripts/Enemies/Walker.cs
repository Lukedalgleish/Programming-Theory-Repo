using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : Enemies
{
    void Start()
    {
        health = 200;
    }

    void Update()
    {
        FollowPlayer(8);
    }
}
