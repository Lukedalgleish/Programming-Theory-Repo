using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Walker : Enemies
{
    // Reference to the ParentScript on the parent GameObject

    void Start()
    {
        health = 200;
    }

    void Update()
    {
        FollowPlayer(8);
    }
}
