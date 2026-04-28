using System.Collections;
using UnityEngine;

public class SmoothHealthBar : SimpleHealthBar
{
    [SerializeField] private float _delay = 1f;

    private Coroutine _coroutine;

    public override void ChangeValue(float value)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothChangeValue(Utility.NormalizedValue(value, Health.MaxValue)));
    }

    private IEnumerator SmoothChangeValue(float targetValue)
    {
        while(Mathf.Approximately(targetValue, HealthSlider.value) == false)
        {
            yield return null;

            HealthSlider.value = Mathf.MoveTowards(HealthSlider.value, targetValue, _delay * Time.deltaTime);
        }
    }
}
