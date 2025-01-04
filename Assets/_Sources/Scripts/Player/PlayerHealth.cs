using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealthBase;
    float currentHealth;
    float maxHealthTotal;

    public Action<float, float> OnHealthChanged;

    void Start()
    {
       Initialise(); 
    }

    void Initialise()
    {
        maxHealthTotal = maxHealthBase;
        currentHealth = maxHealthTotal;
        OnHealthChanged?.Invoke(currentHealth, maxHealthTotal);
    }

    public void ModifyHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealthTotal);
        OnHealthChanged?.Invoke(currentHealth, maxHealthTotal);
    }
}
