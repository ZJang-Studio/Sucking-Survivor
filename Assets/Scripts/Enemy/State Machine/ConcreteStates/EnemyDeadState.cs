using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    TimerHelp clearTime;
    public EnemyDeadState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        clearTime = new TimerHelp(2f);
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.GetComponent<Collider2D>().enabled = false;
        enemy.enemyAnimator.SetBool("Dead", true);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        clearTime.CountDown();
        enemy.MoveEnemy(Vector3.zero);
        if(clearTime.TimeOver)
        {
            enemy.Die();
        }
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
    }
}
