using System;
using UnityEngine;

public class PlayerIdleState : State
{
    private PlayerAnimatorController _animator;
    private InputService _inputService;
    private CombatSystem _combatSystem;

    public PlayerIdleState(StateMachine stateMachine, PlayerAnimatorController animator, InputService inputService, CombatSystem combatSystem) : base(stateMachine)
    {
        _animator = animator;
        _inputService = inputService;
        _combatSystem = combatSystem;
    }

    public override void Enter()
    {
        _inputService.Moved += OnMove;
        _inputService.Jumped += OnJump;
        _inputService.Attacked += OnAttack;

        _animator.StartIdleAnimation();
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
        _inputService.Moved -= OnMove;
        _inputService.Jumped -= OnJump;
        _inputService.Attacked -= OnAttack;

        _animator.StopIdleAnimation();
    }

    private void OnMove(Vector2 moveInput)
    {
        if (moveInput != Vector2.zero)
        {
            StateMachine.SetState<PlayerRunState>();
        }
    }

    private void OnJump()
    {
        StateMachine.SetState<PlayerJumpState>();
    }

    private void OnAttack()
    {
        if (_combatSystem.IsAttacking == true)
        {
            StateMachine.SetState<PlayerAttackState>();
        }
    }
}
