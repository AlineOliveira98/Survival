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

    public Action<float, float> OnStateChanged;

    float currentTime = 0;

    public void Initialise()
    {
        maxTotalValue = maxBaseValue;
        currentValue = maxTotalValue;
        decayValueTotal = decayBaseValue;
        OnStateChanged?.Invoke(currentValue, maxTotalValue);
    }

    public void UpdateState()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= decayRate)
        {
            Modify(-decayValueTotal);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            currentTime = 0;
        }
    }

    public void Modify(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxTotalValue);
        OnStateChanged?.Invoke(currentValue, maxTotalValue);
    }
}