using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerControl player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
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
        player.RB2.velocity = Vector3.zero;
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            player.StateMachine.ChangeState(player.MoveState);
        }
        else if( Input.GetKey(KeyCode.Space))
        {
            player.StateMachine.ChangeState(player.ChargeState);
        }
        
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
    }
}
