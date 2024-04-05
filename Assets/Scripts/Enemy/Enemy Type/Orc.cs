using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        MaxHealth = 10;
        damage = 1;
        attackArea = 1f;     
    }

}
