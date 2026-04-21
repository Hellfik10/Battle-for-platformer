using System;
using UnityEngine;

public class PlayerJumpState : State
{
    private PlayerAnimatorController _animator;
    private GroundChecker _groundChecker;
    private InputService _inputService;
    private Mover _mover;
    private CombatSystem _combatSystem;

    public PlayerJumpState(StateMachine stateMachine, PlayerAnimatorController animator, Mover mover, GroundChecker groundChecker, InputService inputService, CombatSystem combatSystem) : base(stateMachine)
    {
        _animator = animator;
        _mover = mover;
        _groundChecker = groundChecker;
        _inputService = inputService;
        _combatSystem = combatSystem;
    }

    public override void Enter()
    {
        _animator.TriggerJumpAnimation();

        _inputService.Moved += OnMove;
        _inputService.Attacked += OnAttack;
    }

    public override void Update()
    {
        if (Mathf.Approximately(_mover.Rigidbody.linearVelocityY, 0f) == true)
        {
            StateMachine.SetState<PlayerIdleState>();
        }
    }

    public override void Exit()
    {
        _inputService.Moved -= OnMove;
        _inputService.Attacked -= OnAttack;
    }

    private void OnMove(Vector2 moveInput)
    {
        if (_groundChecker.IsGrounded)
        {
            if (moveInput == Vector2.zero)
            {
                StateMachine.SetState<PlayerIdleState>();
            }
            else
            {
                StateMachine.SetState<PlayerRunState>();
            }
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
