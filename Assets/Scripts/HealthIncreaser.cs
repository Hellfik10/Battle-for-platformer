using UnityEngine;
using UnityEngine.UI;

public class HealthIncreaser : HealthChanger
{
    [SerializeField] private float _value = 20;

    public override void ChangeValue()
    {
        Health.IncreaseHealth(_value);
    }
}
