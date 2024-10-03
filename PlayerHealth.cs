using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthChangeButton _treatment;
    [SerializeField] private HealthChangeButton _hit;

    private float _maxHitPoints;
    private float _hitPoints;

    public event Action<float, float, float> HitPointChanged;

    private void Awake()
    {
        _maxHitPoints = 100;
        _hitPoints = _maxHitPoints;
    }

    private void OnEnable()
    {
        _treatment.HitPointsChanging += ApplyTreatment;
        _hit.HitPointsChanging += ApplyDamage;
    }

    private void OnDisable()
    {
        _treatment.HitPointsChanging -= ApplyTreatment;
        _hit.HitPointsChanging -= ApplyDamage;
    }

    public void ApplyDamage(float damage)
    {
        if (_hitPoints > 0)
        {
            _hitPoints -= damage;

            HitPointChanged?.Invoke(GetProportionHitPoint(-damage), 
                _hitPoints, _maxHitPoints);
        }
    }

    public void ApplyTreatment(float treatment)
    {
        if (_hitPoints < _maxHitPoints)
        {
            _hitPoints += treatment;

            HitPointChanged?.Invoke(GetProportionHitPoint(treatment), 
                _hitPoints, _maxHitPoints);
        }
    }

    private float GetProportionHitPoint(float value)
    {
        return value / _maxHitPoints;
    }
}