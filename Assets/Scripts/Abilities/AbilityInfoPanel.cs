using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityInfoPanel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private float _delay = 1;

    private Coroutine _coroutine;

    public void OnEnable()
    {
        _vampirism.ChangedCooldownTimerValue += ChangeValue;
        _vampirism.ChangedActionTimerValue += ReverseChangeValue;
    }

    public void OnDisable()
    {
        _vampirism.ChangedCooldownTimerValue -= ChangeValue;
        _vampirism.ChangedActionTimerValue -= ReverseChangeValue;
    }

    private void ChangeValue(float value, float maxValue)
    {    
        float currentValue = value / maxValue;
        DisplayChanges(currentValue);
    }

    private void ReverseChangeValue(float value, float maxValue)
    {
        float currentValue = maxValue / maxValue - value / maxValue;
        DisplayChanges(currentValue);
    }

    private void DisplayChanges(float value)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothChangeValue(value));
    }

    private IEnumerator SmoothChangeValue(float value)
    {
        while (Mathf.Approximately(value, _slider.value) == false)
        {
            yield return null;

            _slider.value = Mathf.MoveTowards(_slider.value, value, _delay * Time.deltaTime);
        }
    }
}
