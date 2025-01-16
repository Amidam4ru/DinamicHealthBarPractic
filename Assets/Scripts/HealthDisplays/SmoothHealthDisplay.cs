using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speedOfChanging = 0.5f;

    private Coroutine _changeValueSmoothCoroutine;
    private WaitForEndOfFrame _waitForEndOfFrame;

    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
        _waitForEndOfFrame = new WaitForEndOfFrame();
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
        if (_changeValueSmoothCoroutine != null)
        {
            StopCoroutine(_changeValueSmoothCoroutine);
        }

        _changeValueSmoothCoroutine = StartCoroutine(ChangeValueSmooth());
    }

    private IEnumerator ChangeValueSmooth()
    {
        while (_healthSlider.value != (_health.Value / _health.MaxValue))
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, (_health.Value / _health.MaxValue), _speedOfChanging * Time.deltaTime);
            yield return _waitForEndOfFrame;
        }
    }
}
