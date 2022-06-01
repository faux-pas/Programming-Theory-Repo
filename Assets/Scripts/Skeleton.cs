using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private void Awake()
    {
        attack = "Attack1h1";
        speed = 0.05f;
        Health = 2;
    }
}
