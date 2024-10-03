using UnityEngine;
using UnityEngine.UI;

public class HealthChangeButton : MonoBehaviour
{
    public const string Damage = nameof(Damage);

    [SerializeField] private Button _button;
    [SerializeField] private Health _health;

    private float _value = 40;  

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeAmount);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeAmount);
    }

    private void ChangeAmount()
    {
        if (_button.name == Damage)
        {
            _health.ApplyDamage(_value);
        }
        else
        {
            _health.ApplyTreatment(_value);
        }
    }
}