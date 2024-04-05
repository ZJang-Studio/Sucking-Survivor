using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedState : PlayerState
{
    TimerHelp CD = new TimerHelp(0.375f);
    public PlayerDamagedState(PlayerControl player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.playerAnimator.SetTrigger("Damaged");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        CD.CountDown();
        if (CD.TimeOver)
        {
            CD.ResetTime();
            if (player.CurrentHealth <= 0)
            {
                player.StateMachine.ChangeState(player.DeadState);
            }
            else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
            {
                player.StateMachine.ChangeState(player.IdleState);
            }
            else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                player.StateMachine.ChangeState(player.MoveState);
            }
        }
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
    }
}
