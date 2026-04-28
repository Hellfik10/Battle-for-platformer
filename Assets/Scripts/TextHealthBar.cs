using UnityEngine;
using TMPro;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _text.text = $"{Health.CurrentValue} / {Health.MaxValue} ";
    }

    public override void ChangeValue(float value)
    {
        _text.text = $"{value} / {Health.MaxValue} ";
    }
}
