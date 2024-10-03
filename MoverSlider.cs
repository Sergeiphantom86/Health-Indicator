using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoverSlider : MonoBehaviour
{
    [SerializeField] private Slider _hitPointSlider;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private HealthDisplay _healthDisplay;

    private WaitForSeconds _waitForSeconds;

    private float _sliderMovementSpeed;
    private float _delay;

    private void Awake()
    {
        _delay = 0.01f;
        _sliderMovementSpeed = _delay;

        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _playerHealth.HitPointChanged += MoveSlider;
    }

    private void OnDisable()
    {
        _playerHealth.HitPointChanged -= MoveSlider;
    }

    private void MoveSlider(float percent, float hitPoints, float maxHitPoints)
    {
        StartCoroutine(WaitForChangeInHitPoints(percent));
        _healthDisplay.ShowQuantity(hitPoints, maxHitPoints);
    }

    private void Move(float percent)
    {
        _hitPointSlider.value = Mathf.MoveTowards(_hitPointSlider.value, _hitPointSlider.value + percent, _sliderMovementSpeed);
    }

    private IEnumerator WaitForChangeInHitPoints(float value)
    {
        for (int i = 0; i < Mathf.Abs(value / _sliderMovementSpeed); i++)
        {
            yield return _waitForSeconds;

            Move(value);
        }
    }
}