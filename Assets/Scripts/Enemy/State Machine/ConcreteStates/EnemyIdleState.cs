using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    Vector3 direction;
    Vector3 dir;
    //¹¥»÷¾àÀë
    float distance = 0.4f;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
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
        base.FrameUpdate();

        dir = direction = enemy.playerTrans.position - enemy.transform.position;

        direction.Normalize();

        enemy.CheckForFacingDirection(direction);
        enemy.enemyAnimator.SetFloat("Speed", 0f);

        if (dir.magnitude > distance)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }
        else if (enemy.IsAttackable)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
        enemy.MoveEnemy(Vector3.zero);
    }
}
