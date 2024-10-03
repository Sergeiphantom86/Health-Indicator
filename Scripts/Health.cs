using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxAmount;

    private float _amount;

    public event Action<float, float, float> AmountChanged;

    private void Awake()
    {
        _amount = _maxAmount;
    }

    public void ApplyDamage(float damage)
    {
        if (_amount > 0)
        {
            _amount -= damage;

            AmountChanged?.Invoke(GetRatioAmount(damage), _amount, _maxAmount);
        }
    }

    public void ApplyTreatment(float treatment)
    {
        if (_amount < _maxAmount)
        {
            _amount += treatment;

            AmountChanged?.Invoke(GetRatioAmount(-treatment), _amount, _maxAmount);
        }
    }

    private float GetRatioAmount(float value)
    {
        return value / _maxAmount;
    }
}