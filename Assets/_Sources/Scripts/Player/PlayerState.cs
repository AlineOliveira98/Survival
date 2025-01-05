using System;
using UnityEngine;

[System.Serializable]
public class PlayerState
{
    public float maxBaseValue;
    public float decayBaseValue;
    public float decayRate;

    float currentValue;
    float maxTotalValue;
    float decayValueTotal;
    float currentTime = 0;
    bool lockDecay;

    public Action<float, float> OnStateChanged;
    public Action OnStateReachedZero;

    public void Initialise()
    {
        maxTotalValue = maxBaseValue;
        currentValue = maxTotalValue;
        decayValueTotal = decayBaseValue;
        OnStateChanged?.Invoke(currentValue, maxTotalValue);
    }

    public void LockDecay(bool lockDecay) => this.lockDecay = lockDecay;

    public void UpdateState()
    {
        if(lockDecay) return;

        currentTime += Time.deltaTime;

        if(currentTime >= decayRate && currentValue > 0)
        {
            Modify(-decayValueTotal);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            currentTime = 0;
        }
    }

    public void Modify(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxTotalValue);
        OnStateChanged?.Invoke(currentValue, maxTotalValue);

        if(currentValue <= 0)
        {
            OnStateReachedZero?.Invoke();
        }
    }
}