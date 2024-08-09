using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogger : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        movementSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
}
