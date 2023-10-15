using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName) { }

    public override void Enter()
    {
        base.Enter();

        Rb.velocity = new Vector2(Rb.velocity.x, Player.jumpForce);
    }

    public override void Update()
    {
        base.Update();
        if (Rb.velocity.y < 0)
        {
            StateMachine.ChangeState(Player.AirState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
