using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected readonly PlayerStateMachine StateMachine;
    protected readonly Player Player;
    protected Rigidbody2D Rb;

    protected float XInput;
    private readonly string _animBoolName;
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        Player = player;
        StateMachine = stateMachine;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        Player.Anim.SetBool(_animBoolName, true);
        Rb = Player.Rb;
    }

    public virtual void Update()
    {
        XInput = Input.GetAxisRaw("Horizontal");
        Player.Anim.SetFloat(YVelocity, Rb.velocity.y);
    }

    public virtual void Exit()
    {
        Player.Anim.SetBool(_animBoolName, false);
    }
}
