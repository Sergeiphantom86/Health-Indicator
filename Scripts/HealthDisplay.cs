using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textAmount;
    [SerializeField] private Health _health;

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
        _textAmount.text = GetStringFromAmount(amount, maxAmount);
    }

    private string GetStringFromAmount(float amount, float maxAmount)
    {
        string status = "Погиб";

        return amount <= 0 ? status : $"{amount}/{maxAmount}";
    }
}