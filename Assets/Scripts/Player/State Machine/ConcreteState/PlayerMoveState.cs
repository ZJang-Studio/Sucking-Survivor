using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    float horizontal;
    float vertical;
    Vector3 moveDir;
    public PlayerMoveState(PlayerControl player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
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
        if (Input.GetKey(KeyCode.Space))
        {
            player.StateMachine.ChangeState(player.ChargeState);
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(horizontal, vertical);
        moveDir.Normalize();
    }

    public override void PhisicsUpdate()
    {
        base.PhisicsUpdate();
        player.MovePlayer(moveDir);
    }
}
