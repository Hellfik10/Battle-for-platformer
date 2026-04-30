using UnityEngine;
using UnityEngine.UI;

public abstract class HealthChanger : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeValue);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeValue);
    }

    public abstract void ChangeValue();
}
