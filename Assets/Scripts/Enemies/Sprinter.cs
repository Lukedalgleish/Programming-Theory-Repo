using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinter : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        movementSpeed = 14;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }


}
