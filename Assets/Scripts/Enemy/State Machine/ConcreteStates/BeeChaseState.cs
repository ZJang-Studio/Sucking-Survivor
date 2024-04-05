using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeChaseState : EnemyChaseState
{
    public BeeChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        
        if (enemy.IsAttackable)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }

        enemy.Direction = direction = enemy.playerTrans.position - enemy.transform.position;
        direction.Normalize();
        enemy.CheckForFacingDirection(direction);
        if (enemy.CurrentHealth <= 0)
        {
            enemy.StateMachine.ChangeState(enemy.DeadState);
        }
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
    }
}
