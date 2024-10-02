using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthChangeButton : MonoBehaviour
{
    [SerializeField]private Button _button;

    public event Action<float> OnHitPointsChange;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeHealth);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeHealth);
    }

    private void ChangeHealth()
    {
        float value = 0.1f;

        OnHitPointsChange?.Invoke(value);
    }
}