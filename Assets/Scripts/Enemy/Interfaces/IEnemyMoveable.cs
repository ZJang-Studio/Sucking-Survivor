using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMoveable
{
    Rigidbody2D RB { get; set; }
    Vector3 Direction { get; set; }
    float MoveSpeed { get; set; }

    void MoveEnemy(Vector3 velocity);
    void CheckForFacingDirection(Vector3 velocity);
}
