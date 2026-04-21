using System;
using UnityEngine;

public class PlayerRunState : State
{
    private PlayerAnimatorController _animator;
    private InputService _inputService;
    private GroundChecker _groundChecker;
    private CombatSystem _combatSystem;

    public PlayerRunState(StateMachine stateMachine, PlayerAnimatorController animator, GroundChecker groundChecker, InputService inputService, CombatSystem combatSystem) : base(stateMachine)
    {
        _animator = animator;
        _groundChecker = groundChecker;
        _inputService = inputService;
        _combatSystem = combatSystem;
    }

    public override void Enter()
    {
        _inputService.Jumped += OnJump;
        _inputService.Attacked += OnAttack;

        _animator.StartRunAnimation();
    }

    public override void Update()
    {
        if (_inputService.MoveDirection == Vector3.zero)
        {
            StateMachine.SetState<PlayerIdleState>();
        }
    }

    public override void FixedUpdate()
    {
    }

    public override void Exit()
    {
        _inputService.Jumped -= OnJump;

        _animator.StopRunAnimation();
    }

    private void OnJump()
    {
        if (_groundChecker.IsGrounded)
        {
            StateMachine.SetState<PlayerJumpState>();
        }
    }

    private void OnAttack()
    {
        if (_combatSystem.IsAttacking == true)
        {
            StateMachine.SetState<PlayerAttackState>();
        }
    }
}
