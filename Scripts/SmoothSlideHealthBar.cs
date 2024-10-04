using System.Collections;
using UnityEngine;

public class SmoothSlideHealthBar : SlideHealthBar
{
    private float _smoothSlideDelta = 0.5f;

    protected override void RefreshData()
    {
        StartCoroutine(SmoothChangeSliderValue(_health.Amount));
    }

    private void Move(float target)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, target, _smoothSlideDelta * Time.deltaTime);
    }

    private float GetTargetPosition(float target) => target /= _health.MaxAmount;

    private IEnumerator SmoothChangeSliderValue(float target)
    {
        target = GetTargetPosition(target);

        while (_slider.value != target)
        {
            yield return null;

            Move(target);
        }
    }
}