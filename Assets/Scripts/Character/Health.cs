using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100;

    private float _minValue = 0;

    public float CurrentValue { get; private set; }
    public bool IsDead => CurrentValue <= 0;

    public void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void IncreaseHealth(float count)
    {
        if (count > 0)
        {
            CurrentValue += count;
            CurrentValue = Mathf.Clamp(CurrentValue, _minValue, _maxValue);
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Ouch");

        if (damage > 0)
        {
            CurrentValue -= damage;

            if (CurrentValue <= 0)
            {
                CurrentValue = 0;
                Die();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
