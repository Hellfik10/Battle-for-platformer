using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : MonoBehaviour
{
    private InputSystem _inputSystem;

    private Vector2 _moveInput = Vector2.zero;

    public event Action<Vector2> Moved;
    public event Action Attacked;
    public event Action Jumped;

    public Vector3 MoveDirection => _moveInput;


    private void Awake()
    {
        _inputSystem = new InputSystem();
    }

    private void Start()
    {
        _inputSystem.Enable();

        _inputSystem.Player.Move.canceled += OnMove;
        _inputSystem.Player.Move.started += OnMove;
        _inputSystem.Player.Jump.started += OnJump;
        _inputSystem.Player.Jump.canceled += OnJump;
        _inputSystem.Player.Attack.performed += OnAttack;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
    }

    private void OnDestroy()
    {
        _inputSystem.Player.Move.canceled -= OnMove;
        _inputSystem.Player.Move.started -= OnMove;
        _inputSystem.Player.Jump.started -= OnJump;
        _inputSystem.Player.Jump.canceled -= OnJump;
        _inputSystem.Player.Attack.performed -= OnAttack;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        Moved?.Invoke(_moveInput);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jumped?.Invoke();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Attacked?.Invoke();
    }
}
