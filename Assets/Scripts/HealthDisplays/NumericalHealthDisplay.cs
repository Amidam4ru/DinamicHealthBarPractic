using TMPro;
using UnityEngine;

public class NumericalHealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private TextMeshProUGUI _healthText;

    private void Start()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
        _healthText.text = _health.Value + "/" + _health.MaxValue;
    }

    private void OnEnable()
    {
        _health.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ChangeValue;
    }

    private void ChangeValue()
    {
        _healthText.text = _health.Value + "/" + _health.MaxValue;
    }
}
