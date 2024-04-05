using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemy
{
    //¹¥»÷¼ä¸ô
    TimerHelp crashCD = new TimerHelp(1f);
    protected override void Awake()
    {
        StateMachine = new EnemyStateMachine();

        ChaseState = new BeeChaseState(this, StateMachine);
        AttackState = new BeeAttackState(this, StateMachine);
        DeadState = new EnemyDeadState(this, StateMachine);
        KnockBackState = new EnemyKnockBackState(this, StateMachine);

        StateMachine.Initialize(ChaseState);

        damage = 1;
        attackArea = 1f;
        MaxHealth = 2;
    }
    protected override void Update()
    {
        base.Update();
        crashCD.CountDown();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (crashCD.TimeOver && collision.gameObject.tag == "Player" )
        {
            crashCD.ResetTime();
            PlayerControl player = collision.gameObject.GetComponent<PlayerControl>();
            player.ChangeHealth(damage);
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(Direction * 500, ForceMode2D.Impulse);
            player.StateMachine.ChangeState(player.DamagedState);
        }
    }
}
