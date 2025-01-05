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

    #region Singleton
    public static PlayerHealth Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        
        // DontDestroyOnLoad(gameObject);
    }
    #endregion

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

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        
    }
}
