using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthChangeButton : MonoBehaviour
{
    [SerializeField]private Button _button;

    public event Action<float> HitPointsChanging;

    private float _value = 10;  

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeHitPoint);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeHitPoint);
    }

    private void ChangeHitPoint()
    {
        HitPointsChanging?.Invoke(_value);
    }
}