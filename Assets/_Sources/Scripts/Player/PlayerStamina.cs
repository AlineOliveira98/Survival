using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] StarterAssetsInputs input;
    [SerializeField] float maxStaminaBase;
    [SerializeField] float costSprint;
    float currentStamina;
    float maxStaminaTotal;

    public Action<float, float> OnStaminaChanged;

    void Start()
    {
       Initialise(); 
    }

    void Update()
    {
        if(input.sprint)
        {
            ChangeStamina(-costSprint * Time.deltaTime);
        }
        else if(currentStamina < maxStaminaTotal)
        {
            ChangeStamina(Time.deltaTime);
        }
    }

    void Initialise()
    {
        maxStaminaTotal = maxStaminaBase;
        currentStamina = maxStaminaTotal;
        OnStaminaChanged?.Invoke(currentStamina, maxStaminaTotal);
    }

    public void ChangeStamina(float value)
    {
        currentStamina = Mathf.Clamp(currentStamina + value, 0, maxStaminaTotal);
        OnStaminaChanged?.Invoke(currentStamina, maxStaminaTotal);
    }
}
