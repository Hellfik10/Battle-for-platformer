using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : HealthBar
{
    [SerializeField] protected Slider HealthSlider;

    protected void Start()
    {
        ChangeValue(Health.CurrentValue);
    }

    public override void ChangeValue(float value)
    {
        HealthSlider.value = Utility.NormalizedValue(value, Health.MaxValue);
    }
}
