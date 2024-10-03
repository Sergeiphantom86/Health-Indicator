using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _amount;
    [SerializeField] private Health _health;

    private WaitForSeconds _waitForSeconds;

    private float _movementSpeed;
    private float _delay;

    private void Awake()
    {
        _delay = 0.01f;
        _movementSpeed = _delay;

        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _health.AmountChanged += RefreshData;
    }

    private void OnDisable()
    {
        _health.AmountChanged -= RefreshData;
    }

    private void RefreshData(float ratio, float amount, float maxAmount)
    {
        StartCoroutine(WaitForChangeInHitPoints(ratio));
    }

    private void Move(float ratio)
    {
        _amount.value = Mathf.MoveTowards(_amount.value, _amount.value - ratio, _movementSpeed);
    }

    private IEnumerator WaitForChangeInHitPoints(float ratio)
    {
        for (int i = 0; i < Mathf.Abs(ratio / _movementSpeed); i++)
        {
            yield return _waitForSeconds;

            Move(ratio);
        }
    }
}