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
        return $"{hitPoints}/{maxHitPoints}";
    }
}