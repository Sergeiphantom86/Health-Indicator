using TMPro;
using UnityEngine;

public class TextHealthBar : SliderHandler
{
    [SerializeField] protected TMP_Text TextAmount;

    protected virtual void Awake()
    {
        RefreshData();
    }

    protected override void RefreshData()
    {
        TextAmount.text = GetStringFromAmount(Health.Amount, Health.MaxAmount);
    }

    private string GetStringFromAmount(float amount, float maxAmount)
    {
        string status = "Погиб";

        return amount <= 0 ? status : $"{amount}/{maxAmount}";
    }
}