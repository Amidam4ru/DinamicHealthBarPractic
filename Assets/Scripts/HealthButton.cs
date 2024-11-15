using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealthButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] [Min (1)] private float _valueOfChange;
    [SerializeField] private bool isImprove;

    private Button _healthButton;

    private void Awake()
    {
        _healthButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _healthButton.onClick.AddListener(ChangeValue);
    }

    private void OnDisable()
    {
        _healthButton?.onClick.RemoveListener(ChangeValue);
    }

    private void ChangeValue()
    {
        if (isImprove)
        {
            _health.IncreaseValue(_valueOfChange);
        }
        else
        {
            _health.TakeDamage(_valueOfChange);
        }
    }
}
