using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] Image fill;
    public void UpdateHealthBar(float current, float max)
    {
        float targetFill = Mathf.Clamp01(current / max);
        DOTween.To(() => fill.fillAmount, x => fill.fillAmount = x, targetFill, 0.5f);
    }
}
