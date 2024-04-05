using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeState : PlayerState
{
    TimerHelp ChargeTime =new TimerHelp(0.65f);
    public PlayerChargeState(PlayerControl player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.playerAnimator.SetTrigger("Charge");
        ChargeTime.ResetTime();
        player.ChangeHealth(-1);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        ChargeTime.CountDown();
        player.RB2.velocity = Vector3.zero;
        
        if(ChargeTime.TimeOver) 
        {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
    }
}
