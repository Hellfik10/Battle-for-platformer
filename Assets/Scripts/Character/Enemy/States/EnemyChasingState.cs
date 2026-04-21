using UnityEngine;

public class EnemyChasingState : State
{
    private EnemyAnimatorController _animator;
    private EnemyAreaViewer _areaViewer;
    private Collider2D _currentTarget;
    private Mover _mover;
    private float _distanceToTarget = 3f;
    private bool _isCome = false;
    private float _moveSpeed;
    private Vector3 _direction;
    private CombatSystem _combatSystem;

    public EnemyChasingState(StateMachine stateMachine, EnemyAnimatorController animator, EnemyAreaViewer enemyViewer, Mover mover, float moveSpeed, CombatSystem combatSystem) : base(stateMachine)
    {
        _combatSystem = combatSystem;
        _areaViewer = enemyViewer;
        _moveSpeed = moveSpeed;
        _animator = animator;
        _mover = mover;
    }

    public override void Enter()
    {
        _currentTarget = _areaViewer.GetTarget();
        _animator.StartRunAnimation();
    }

    public override void Update()
    {
        _direction = new Vector3(_currentTarget.transform.position.x - _mover.transform.position.x, 0);

        if (_areaViewer.CurrentTarget)
        {
            if (Vector2.Distance(_mover.transform.position, _currentTarget.transform.position) < _distanceToTarget & _combatSystem.IsAttacking == false)
            {
                _isCome = true;
                StateMachine.SetState<EnemyAttackState>();
            }
            else
            {
                _isCome = false;
            }
        }
        else
        {
            StateMachine.SetState<EnemyCheckAreaState>();
        }
    }

    public override void FixedUpdate()
    {
        if (_isCome == false)
        {
            if (_direction.x > 0)
            {
                _direction.x = 1;
            }
            else if (_direction.x < 0)
            {
                _direction.x = -1;
            }

            _mover.Move(_direction, _moveSpeed);
        }
    }

    public override void Exit()
    {
        _animator.StopRunAnimation();
    }
}
