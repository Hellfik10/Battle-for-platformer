using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AbilityEffects), typeof(NearestTargetDetector), typeof(Health))]

public class Vampirism : MonoBehaviour
{  
    [SerializeField] private LayerMask _enemyLayer; 
    [SerializeField] private float _damage = 20;

    private NearestTargetDetector _targetDetector;
    private Collider2D _currentTarget;
    private Health _health;
    private float _currentCooldownTime = 0f;
    private float _currentActionTime = 0f;
    private float _refreshTime = 0.25f;
    private float _cooldownTime = 4f;
    private float _actionTime = 6f;

    private bool _isReady = false;

    public event Action<float, float> ChangedCooldownTimerValue;
    public event Action<float, float> ChangedActionTimerValue;
    public event Action ActivatedAbility;
    public event Action DeactivatedAbility;

    public float CircleRadius { get; private set; } = 4;

    private void Start()
    {
        _health = GetComponent<Health>();
        _targetDetector = GetComponent<NearestTargetDetector>();
        StartCoroutine(StartCooldown());
    }

    public void Activate()
    {
        if(_isReady)
        {
            StartCoroutine(StartAction());
        }
    }

    private IEnumerator StartAction()
    {
        _isReady = false;
        ActivatedAbility?.Invoke();
        _currentActionTime = 0f;
        var wait = new WaitForSeconds(_refreshTime);

        while (_currentActionTime < _actionTime)
        {
            yield return wait;

            _currentActionTime += _refreshTime;
            ChangedActionTimerValue(_currentActionTime, _actionTime);
            _currentTarget = _targetDetector.GetTarget(CircleRadius, _enemyLayer);

            if (_currentTarget != null && _currentTarget.gameObject.TryGetComponent(out IDamageable target))
            {
                 target.TakeDamage(_damage);
                _health.Heal(_damage);
            }
        }

        DeactivatedAbility?.Invoke();
        StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        _currentCooldownTime = 0f;
        var wait = new WaitForSeconds(_refreshTime);

        while (_currentCooldownTime < _cooldownTime)
        {
            yield return wait;

            _currentCooldownTime += _refreshTime;
            ChangedCooldownTimerValue?.Invoke(_currentCooldownTime, _cooldownTime);
        }

        _isReady = true;
    }

    private void OnDrawGizmos()
    {
        if (transform.position != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, CircleRadius);
        }
    }
}
