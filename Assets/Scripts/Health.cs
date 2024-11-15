using System;
using UnityEngine;

public class Health: MonoBehaviour
{
    [SerializeField] private float _value = 100;
    [SerializeField] [Min(1)] private float _maxValue = 100;
    [SerializeField] [Min(0)] private float _minValue = 0;

    public event Action Died;
    public event Action ValueChanged;

    public float Value => _value;
    public float MinValue => _minValue;
    public float MaxValue => _maxValue;

    private void OnValidate()
    {
        if (_value > _maxValue)
        {
            _value = _maxValue;
        }

        if (_maxValue <= _minValue)
        {
            _maxValue = _minValue + 1;
        }
    }

    public void IncreaseValue(float value)
    {
        if (value > 0)
        {
            _value += value;
            _value = Math.Clamp(_value, _minValue, _maxValue);
            ValueChanged?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            _value -= damage;
            _value = Math.Clamp(_value, _minValue, _maxValue);
            ValueChanged?.Invoke();

            if (_value == _minValue)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
