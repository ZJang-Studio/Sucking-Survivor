using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerControl player;
    protected PlayerStateMachine playerStateMachine;
    public PlayerState(PlayerControl player, PlayerStateMachine playerStateMachine)
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhisicsUpdate() { }
}
