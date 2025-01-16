using UnityEngine;
using UnityEngine.UI;

public class DiscreteHealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _healthSlider.value = _health.Value / _health.MaxValue;
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
        _healthSlider.value = _health.Value / _health.MaxValue;
    }
}
