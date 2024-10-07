using UnityEngine;

public abstract class SliderHandler : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected virtual void OnEnable()
    {
        Health.AmountChanged += RefreshData;
    }

    protected virtual void OnDisable()
    {
        Health.AmountChanged -= RefreshData;
    }

    protected virtual void RefreshData()
    {
        
    }
}