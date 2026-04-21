using UnityEngine;

public class EnemyAttackState : State
{
    private EnemyAnimatorController _animator;
    private CombatSystem _combatSystem;

    public EnemyAttackState(StateMachine stateMachine, EnemyAnimatorController animator, CombatSystem combatSystem) : base(stateMachine)
    {
        _animator = animator;
        _combatSystem = combatSystem;
    }

    public override void Enter()
    {
        _combatSystem.Attack();
        _animator.AttackEnded += OnAttackEnd;
        _animator.StartAttackAnimation();
    }

    public override void Exit()
    {
        _animator.StopAttackAnimation();
        _animator.AttackEnded -= OnAttackEnd;
    }

    public void OnAttackEnd()
    {
        _combatSystem.EndAttack();
        StateMachine.SetState<EnemyCheckAreaState>();
    }
}
