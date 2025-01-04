using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIStaminaBar : MonoBehaviour
{
    [SerializeField] Image fill;
    PlayerStamina _playerStamina;
    PlayerStamina playerStamina => _playerStamina != null ? _playerStamina : _playerStamina = FindObjectOfType<PlayerStamina>();

    void OnEnable()
    {
        playerStamina.OnStaminaChanged += UpdateStaminaBar;
    }
    
    public void UpdateStaminaBar(float current, float max)
    {
        float targetFill = Mathf.Clamp01(current / max);
        DOTween.To(() => fill.fillAmount, x => fill.fillAmount = x, targetFill, 0.5f);
    }
}
