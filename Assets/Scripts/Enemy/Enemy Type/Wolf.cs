using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Wolf : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        MaxHealth = 5;
        damage = 2;
        attackArea = 0.6f;
    }
}
