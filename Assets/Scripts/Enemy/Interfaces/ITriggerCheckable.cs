using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool IsAttackable { get; set; }
    void SetAttackableStatus(bool isAttackable);
}
