using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthDisplay _hitPointDisplay;
    [SerializeField] private HealthChangeButton _treatment;
    [SerializeField] private HealthChangeButton _hit;
    [SerializeField] private Slider _hitPointSlider;

    private WaitForSeconds _waitForSeconds;

    private float _sliderMovementSpeed;
    private float _maxHitPoints;
    private float _hitPoints;
    private float _delay;

    private void Awake()
    {
        _delay = 0.01f;
        _maxHitPoints = 200;
        _hitPoints = _maxHitPoints;
        _sliderMovementSpeed = _delay;
        _hitPointDisplay.ShowQuantity(_hitPoints, _maxHitPoints);

        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _treatment.OnHitPointsChange += ApplyTreatment;
        _hit.OnHitPointsChange += ApplyDamage;
    }

    private void OnDisable()
    {
        _treatment.OnHitPointsChange -= ApplyTreatment;
        _hit.OnHitPointsChange -= ApplyDamage;
    }

    public void ApplyDamage(float damage)
    {
        if (_hitPoints > 0)
        {
            StartCoroutine(WaitForChangeInHitPoints(-damage));
        }
    }

    public void ApplyTreatment(float treatment)
    {
        if (_hitPoints < _maxHitPoints)
        {
            StartCoroutine(WaitForChangeInHitPoints(treatment));
        }
    }

    private float CalculateDamageCaused(float value)
    {
        return _maxHitPoints * value;
    }

    private void Move(float value)
    {
        _hitPointSlider.value = Mathf.MoveTowards(_hitPointSlider.value, _hitPointSlider.value + value, _sliderMovementSpeed);
    }

    private IEnumerator WaitForChangeInHitPoints(float value)
    {
        _hitPoints += CalculateDamageCaused(value);
        _hitPointDisplay.ShowQuantity(_hitPoints, _maxHitPoints);

        for (int i = 0; i < Mathf.Abs(value / _sliderMovementSpeed); i++)
        {
            yield return _waitForSeconds;

            Move(value);
        }
    }
}