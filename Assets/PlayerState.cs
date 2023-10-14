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
    }

    public virtual void Exit()
    {
        Player.Anim.SetBool(_animBoolName, false);
    }
}
