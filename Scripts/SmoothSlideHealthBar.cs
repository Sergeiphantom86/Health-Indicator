using System.Collections;
using UnityEngine;

public class SmoothSlideHealthBar : SlideHealthBar
{
    private float _smoothSlideDelta = 0.5f;

    protected override void RefreshData()
    {
        StartCoroutine(SmoothChangeSliderValue(Health.Amount));
    }

    private void Move(float target)
    {
        Slider.value = Mathf.MoveTowards(Slider.value, target, _smoothSlideDelta * Time.deltaTime);
    }

    private float GetTargetPosition(float target) => target /= Health.MaxAmount;

    private IEnumerator SmoothChangeSliderValue(float target)
    {
        target = GetTargetPosition(target);

        while (Slider.value != target)
        {
            yield return null;

            Move(target);
        }
    }
}