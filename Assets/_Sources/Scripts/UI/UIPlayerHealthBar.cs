using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthBar : UIHealthBar
{
    PlayerHealth _playerHealth;
    PlayerHealth playerHealth => _playerHealth != null ? _playerHealth : _playerHealth = FindObjectOfType<PlayerHealth>();

    void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdateHealthBar;
    }
}
