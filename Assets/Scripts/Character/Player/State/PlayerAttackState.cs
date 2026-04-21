using System;
using UnityEngine;

public class PlayerAttackState : State
{
    private PlayerAnimatorController _animator;
    private InputService _inputService;
    private CombatSystem _combatSystem;

    public PlayerAttackState(StateMachine stateMachine, PlayerAnimatorController animator, InputService inputService, CombatSystem combatSystem) : base(stateMachine)
    {
        _animator = animator;
        _inputService = inputService;
        _combatSystem = combatSystem;
    }

    public override void Enter()
    {
        _animator.AttackEnded += OnAttackEnd;
        _inputService.Attacked += OnAttack;

        _animator.StartAttackAnimation();
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
        _inputService.Attacked -= OnAttack;

        _animator.StopAttackAnimation();
    }

    private void OnAttack()
    {
        if (_combatSystem.IsAttacking == true)
        {
            StateMachine.SetState<PlayerAttackState>();
        }
    }

    private void OnAttackEnd()
    {
        _combatSystem.EndAttack();
        StateMachine.SetState<PlayerIdleState>();
    }
}
