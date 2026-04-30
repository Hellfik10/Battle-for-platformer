using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.ChangedValue += ChangeValue;
    }

    private void OnDisable()
    {
        Health.ChangedValue -= ChangeValue;
    }

    public abstract void ChangeValue(float value);
}
