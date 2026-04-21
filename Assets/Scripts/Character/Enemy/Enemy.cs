using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator), typeof(Health), typeof(EnemyAreaViewer))]
public class Enemy : Character
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _timeToIdle = 3f;

    private PointCollector _patrolPointsCollector;
    private EnemyAreaViewer _areaViewer;
    private Rotator _rotator;
    private Mover _mover;
    private CombatSystem _combatSystem;

    private EnemyAnimatorController _animator;
    private StateMachine _stateMachine;

    private void Awake()
    {
        _areaViewer = GetComponent<EnemyAreaViewer>();
        _rotator = GetComponent<Rotator>();
        _mover = GetComponent<Mover>();
        _combatSystem = GetComponent<CombatSystem>();

        _animator = GetComponent<EnemyAnimatorController>();
        _stateMachine = new StateMachine();
    }

    private void Start()
    {
        _stateMachine.AddState(new EnemyAttackState(_stateMachine, _animator, _combatSystem));
        _stateMachine.AddState(new EnemyChasingState(_stateMachine, _animator, _areaViewer, _mover, _moveSpeed, _combatSystem));
        _stateMachine.AddState(new EnemyPatrolState(_stateMachine, _patrolPointsCollector, _animator, _mover, _moveSpeed, _areaViewer));
        _stateMachine.AddState(new EnemyCheckAreaState(_stateMachine, _animator, _timeToIdle, _rotator, _areaViewer));
        _stateMachine.SetState<EnemyPatrolState>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    public void Initialize(PointCollector points)
    {
        _patrolPointsCollector = points;
    }
}