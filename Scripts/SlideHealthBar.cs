using UnityEngine;
using UnityEngine.UI;

public class SlideHealthBar : SliderHandler
{
    [SerializeField] protected Slider Slider;

    protected override void RefreshData()
    {
        Slider.value = Health.Amount / Health.MaxAmount;
    }
}