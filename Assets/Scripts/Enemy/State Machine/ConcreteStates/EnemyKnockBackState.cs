using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyKnockBackState : EnemyState
{
    TimerHelp knockBackTime = new TimerHelp(0.3f);
    public EnemyKnockBackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.MoveEnemy(Vector3.zero);
        enemy.RB.AddForce(-enemy.Direction * (500 / enemy.RB.mass), ForceMode2D.Impulse);
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        knockBackTime.CountDown();
        if(knockBackTime.TimeOver)
        {
            knockBackTime.ResetTime();
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
    }
}
