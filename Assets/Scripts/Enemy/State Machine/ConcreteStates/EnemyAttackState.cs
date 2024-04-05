using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private Vector3 dir;
    TimerHelp attackTime;
    float attackCD = 1.5f;
    PlayerControl player;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        player = PlayerControl.instance;
        attackTime = new TimerHelp(attackCD);
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        if (triggerType==Enemy.AnimationTriggerType.EnemyAttack && dir.magnitude - enemy.attackArea <= 0.2f)
        {
            player.ChangeHealth(enemy.damage);
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 500, ForceMode2D.Impulse);
            player.StateMachine.ChangeState(player.DamagedState);
        }
    }

    public override void EnterState()
    {
        
        base.EnterState();
        enemy.enemyAnimator.SetTrigger("Attack");

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        attackTime.CountDown();
        dir = enemy.playerTrans.position - enemy.transform.position;
        enemy.enemyAnimator.SetFloat("Speed", 0f);

        if (attackTime.TimeOver)//当Monster不能Attack然后就转换为IdleState
        {
            attackTime.ResetTime();
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        

        
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
    }
}
