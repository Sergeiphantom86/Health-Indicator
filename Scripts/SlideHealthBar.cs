using UnityEngine;
using UnityEngine.UI;

public class SlideHealthBar : TextHealthBar
{
    [SerializeField] protected Slider _slider;

    protected override void RefreshData()
    {
        _slider.value = _health.Amount / _health.MaxAmount;
    }
}