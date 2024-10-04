using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected TMP_Text _textAmount;

    protected virtual void Awake()
    {
        RefreshData();
    }

    protected virtual void OnEnable()
    {
        _health.AmountChanged += RefreshData;
    }

    protected virtual void OnDisable()
    {
        _health.AmountChanged -= RefreshData;
    }

    protected virtual void RefreshData()
    {
        _textAmount.text = GetStringFromAmount(_health.Amount, _health.MaxAmount);
    }

    private string GetStringFromAmount(float amount, float maxAmount)
    {
        string status = "Погиб";

        return amount <= 0 ? status : $"{amount}/{maxAmount}";
    }
}