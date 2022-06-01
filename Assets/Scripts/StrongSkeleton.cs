using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongSkeleton : Enemy
{
    private void Awake()
    {
        attack = "Attack1h1";
        speed = 0.02f;
        Health = 5;
    }

}
