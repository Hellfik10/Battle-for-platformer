using UnityEngine;

[RequireComponent (typeof(Mover), typeof(AnimatorController), typeof(CombatSystem))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private AnimatorController _animatorController;

    private CombatSystem _combatSystem;
    private Flipper _flipper;
    private Mover _mover;
    private float _direction;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _animatorController = GetComponent<AnimatorController>();
        _flipper = GetComponent<Flipper>();
        _combatSystem = GetComponent<CombatSystem>();
    }

    private void Update()
    {
        Move();
        TryAttack();
    }

    private void Move()
    {
        _direction = _inputReader.Horizontal;

        _mover.SetDirection(_direction);

        if (_groundChecker.IsGrounded)
        {
            if (_inputReader.IsJump)
            {
                _animatorController.StartJumpAnimation();
                _mover.Jump(_jumpForce);
            }
            else
            {
                _animatorController.StopJumpAnimation();
            }

            if (_direction != 0)
            {
                _animatorController.StartRunAnimation();
            }
            else
            {
                _animatorController.StopRunAnimation();
            }
        }

        _mover.Move(_direction, _moveSpeed);

        if (_direction != 0)
        {
            _flipper.FlipCharacter(_direction);
        }
    }

    private void TryAttack()
    {
        if (_inputReader.IsAttack && _combatSystem.IsAttacking == false)
        {
            _animatorController.StartAttackAnimation();
            _combatSystem.Attack();
        }
    }
}
