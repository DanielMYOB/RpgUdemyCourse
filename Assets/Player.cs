using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    public float moveSpeed = 8;

    public float jumpForce = 12;

    [Header("Collision Info")]
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundCheckDistance;

    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private float wallCheckDistance;

    [SerializeField]
    private LayerMask whatIsGround;

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    #endregion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
    }

    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rb.velocity = new Vector2(xVelocity, yVelocity);
    }

    public bool IsGroundDetected() =>
        Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        var groundCheckPosition = groundCheck.position;
        var wallCheckPosition = wallCheck.position;
        Gizmos.DrawLine(
            groundCheckPosition,
            new Vector3(groundCheckPosition.x, groundCheckPosition.y - groundCheckDistance)
        );
        Gizmos.DrawLine(
            wallCheckPosition,
            new Vector3(wallCheckPosition.x + wallCheckDistance, wallCheckPosition.y)
        );
    }
}
