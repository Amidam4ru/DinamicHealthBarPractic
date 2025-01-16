using System;
using UnityEngine;

public class Health: MonoBehaviour
{
    [field: SerializeField, Min(0)] public float Value { get; private set; }
    [field: SerializeField, Min(0)] public float MinValue { get; private set; }
    [field: SerializeField, Min(1)] public float MaxValue { get; private set; }

    public event Action Died;
    public event Action ValueChanged;


    private void OnValidate()
    {
        if (Value > MaxValue)
        {
            Value = MaxValue;
        }

        if (MaxValue <= MinValue)
        {
            MaxValue = MinValue + 1;
        }
    }

    public void IncreaseValue(float value)
    {
        if (value > 0)
        {
            Value += value;
            Value = Math.Clamp(Value, MinValue, MaxValue);
            ValueChanged?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            Value -= damage;
            Value = Math.Clamp(Value, MinValue, MaxValue);
            ValueChanged?.Invoke();

            if (Value == MinValue)
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
