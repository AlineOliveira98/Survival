using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtHunger;
    [SerializeField] TextMeshProUGUI txtThirsty;

    PlayerStatesManager _playerSM;
    PlayerStatesManager playerSM => _playerSM != null ? _playerSM : _playerSM = FindObjectOfType<PlayerStatesManager>();

    void OnEnable()
    {
        playerSM.hungerState.OnStateChanged += UpdateHungerState;
        playerSM.thirstyState.OnStateChanged += UpdateThirstyState;
    }

    void UpdateHungerState(float current, float max)
    {
        txtHunger.text = $"Hunger\r\n{current / max * 100}%";
    }

    void UpdateThirstyState(float current, float max)
    {
        txtThirsty.text = $"Thirsty\r\n{current / max * 100}%";
    }
}
