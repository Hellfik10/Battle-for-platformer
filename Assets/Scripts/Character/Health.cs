using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100;

    private float _minValue = 0;

    public event Action Died;
    public event Action<float> ChangedValue;
    public float CurrentValue { get; private set; }
    public float MaxValue => _maxValue;

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
            ChangedValue?.Invoke(CurrentValue);
        }
    }

    public void DecreaseHealth(float damage)
    {
        if (damage > 0)
        {
            CurrentValue -= damage;

            if (CurrentValue <= 0)
            {
                CurrentValue = 0;
                Died?.Invoke();
            }

            ChangedValue?.Invoke(CurrentValue);
        }
    }
}
