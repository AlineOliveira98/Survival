using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] float maxStaminaBase;
    [SerializeField] float recoveryRate;
    float currentStamina;
    float maxStaminaTotal;
    float currentConsume;

    public Action<float, float> OnStaminaChanged;

    #region Singleton
    public static PlayerStamina Instance { get; private set; }
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

    void Update()
    {
        if(currentConsume <= 0)
        {
            if(currentStamina < maxStaminaTotal)
            {
                ModifyStamina(recoveryRate * Time.deltaTime);
            }
        }
        else
        {
            ModifyStamina(-currentConsume * Time.deltaTime);
        }
    }

    void Initialise()
    {
        maxStaminaTotal = maxStaminaBase;
        currentStamina = maxStaminaTotal;
        OnStaminaChanged?.Invoke(currentStamina, maxStaminaTotal);
    }

    public void ModifyStamina(float value)
    {
        currentStamina = Mathf.Clamp(currentStamina + value, 0, maxStaminaTotal);
        OnStaminaChanged?.Invoke(currentStamina, maxStaminaTotal);
    }

    public void ModifyConsumeStamina(float value)
    {
        currentConsume += value;
    }
}
