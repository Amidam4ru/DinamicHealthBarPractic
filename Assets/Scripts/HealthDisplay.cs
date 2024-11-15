using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _healthSlider;

    [SerializeField] private Slider _smoothHealthSlider;
    [SerializeField] private float _speedOfChanging = 0.5f;

    private Coroutine _changeValueSmoothCoroutine;
    private WaitForEndOfFrame _waitForEndOfFrame;

    private void Awake()
    {
        _waitForEndOfFrame = new WaitForEndOfFrame();
    }

    private void Start()
    {
        _healthText.text = _health.Value + "/" + _health.MaxValue;

        _healthSlider.value = _health.Value/_health.MaxValue;
        _smoothHealthSlider.value = _health.Value / _health.MaxValue;
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
        _healthSlider.value = _health.Value/_health.MaxValue;

        if (_changeValueSmoothCoroutine != null)
        {
            StopCoroutine( _changeValueSmoothCoroutine );
        }

        _changeValueSmoothCoroutine = StartCoroutine(ChangeValueSmooth());
    }

    private IEnumerator ChangeValueSmooth()
    {
        while (_smoothHealthSlider.value != (_health.Value/_health.MaxValue))
        {
            _smoothHealthSlider.value = Mathf.MoveTowards(_smoothHealthSlider.value, (_health.Value / _health.MaxValue),  _speedOfChanging * Time.deltaTime);
            yield return _waitForEndOfFrame;
        }
    }
}
