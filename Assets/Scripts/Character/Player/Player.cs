using UnityEngine;

[RequireComponent(typeof(Mover), typeof(CombatSystem), typeof(PlayerAnimatorController))]
[RequireComponent(typeof(InputService))]
public class Player : Character
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _jumpForce = 12f;

    [Header("Components")]
    [SerializeField] private GroundChecker _groundChecker;

    private Mover _mover;
    private InputService _inputService;
    private CombatSystem _combatSystem;
    private PlayerAnimatorController _animatorController;
    private StateMachine _stateMachine;

    private Vector2 _moveInput;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _combatSystem = GetComponent<CombatSystem>();
        _animatorController = GetComponent<PlayerAnimatorController>();

        _inputService = GetComponent<InputService>();
    }

    private void Start()
    {
        _inputService.Moved += OnMove;
        _inputService.Jumped += OnJump;
        _inputService.Attacked += OnAttack;

        _stateMachine = new StateMachine();

        _stateMachine.AddState(new PlayerIdleState(_stateMachine, _animatorController, _inputService, _combatSystem));
        _stateMachine.AddState(new PlayerRunState(_stateMachine, _animatorController, _groundChecker, _inputService, _combatSystem));
        _stateMachine.AddState(new PlayerJumpState(_stateMachine, _animatorController, _mover, _groundChecker, _inputService, _combatSystem));
        _stateMachine.AddState(new PlayerAttackState(_stateMachine, _animatorController, _inputService, _combatSystem));

        _stateMachine.SetState<PlayerIdleState>();
    }

    private void Update()
    {
        _stateMachine?.Update();

        _mover.Move(_moveInput, _speed);
    }   

    private void FixedUpdate()
    {
        _stateMachine?.FixedUpdate();
    }

    private void OnDestroy()
    {
        _inputService.Moved -= OnMove;
        _inputService.Jumped -= OnJump;
    }

    private void OnMove(Vector2 moveInput)
    {
        _moveInput = moveInput;
    }

    private void OnJump()
    {
        if (_groundChecker.IsGrounded)
        {
            _mover.Jump(_jumpForce);
        }
    }

    private void OnAttack()
    {
        if (_combatSystem.IsAttacking == false)
        {
            _combatSystem.Attack();
        }
    }
}
