using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PatrolController))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private SpriteRenderer _spriteRenderer;
    private Transform _point;
    private PatrolController _patrolController;
    private float _direction;
    private Flipper _flipper;
    private float _health;

    public Rigidbody2D Rigidbody { get; private set; }

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _patrolController = GetComponent<PatrolController>();
        _flipper = GetComponent<Flipper>();
    }

    private void OnEnable()
    {
        _patrolController.CurrentPointUpdated += SetDirectionToPoint;
    }

    private void OnDisable()
    {
        _patrolController.CurrentPointUpdated -= SetDirectionToPoint;
    }
        
    public void Init(List<Transform> points)
    {
        _patrolController.Init(points);
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = new Vector2(_direction * _speed, Rigidbody.velocity.y);
    }

    private void SetDirectionToPoint(Transform point)
    {
        _point = point;

        if (_point.position.x < transform.position.x)
        {
            _direction = -1;
        }
        else
        {
            _direction = 1;
        }

        _flipper.FlipCharacter(_direction);
    }
}
