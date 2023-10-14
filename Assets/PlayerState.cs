using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine StateMachine;
    protected Player Player;

    private string _animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        Player = player;
        StateMachine = stateMachine;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log("I enter" + _animBoolName);
    }

    public virtual void Update()
    {
        Debug.Log("I in" + _animBoolName);
    }

    public virtual void Exit()
    {
        Debug.Log("I exit" + _animBoolName);
    }
}
