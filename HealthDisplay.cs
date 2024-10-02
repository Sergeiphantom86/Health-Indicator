using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textHitPoint;

    public void ShowQuantity(float hitPoints, float maxHitPoints)
    {
        _textHitPoint.text = GetStringValueHitPoint(hitPoints, maxHitPoints);
    }

    private string GetStringValueHitPoint(float hitPoints, float maxHitPoints)
    {
        string quantityHealth = $"{hitPoints}/{maxHitPoints}";
        string died = "Погиб";

        if (hitPoints > 0)
        {
            return quantityHealth;
        }
        else
        {
            return died;
        }
    }
}