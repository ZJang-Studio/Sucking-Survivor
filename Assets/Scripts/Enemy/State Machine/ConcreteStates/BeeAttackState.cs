using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;

public class BeeAttackState : EnemyAttackState
{
    Vector3 DirToCrash;
    float crashSpeed = 2f;
    TimerHelp crashTime;
    public BeeAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        crashTime = new TimerHelp(1.5f);
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        
    }

    public override void EnterState()
    {
        crashTime.ResetTime();
        DirToCrash = enemy.Direction;
        DirToCrash.Normalize();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        crashTime.CountDown();
        enemy.MoveEnemy(DirToCrash * crashSpeed);
        if (crashTime.TimeOver)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
    }
}

