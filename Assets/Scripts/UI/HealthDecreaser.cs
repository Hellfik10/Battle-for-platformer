using UnityEngine;

public class HealthDecreaser : HealthChanger
{
    [SerializeField] private float _value = 20;

    public override void ChangeValue()
    {
        Health.TakeDamage(_value);
    }
}
