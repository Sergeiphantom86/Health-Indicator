using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField][Range(50, 100)] private float _maxAmount;
    [SerializeField][Range(50, 100)] private float _amount;

    public event Action AmountChanged;

    public float Amount
    {
        get => _amount;

        private set
        {
            if (value == _amount)
                return;

            _amount = Mathf.Clamp(value, 0, _maxAmount);

            AmountChanged?.Invoke();
        }
    }

    public float MaxAmount => _maxAmount;

    public void TakeTreatment(float value) => Amount += Mathf.Round(value);

    public void TakeDamage(float value) => Amount -= Mathf.Round(value);
}