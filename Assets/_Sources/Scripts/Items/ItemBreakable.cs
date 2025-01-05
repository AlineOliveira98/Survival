using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemBreakable : Interactable, IDamageable
{
    [LineSpacer]
    [SerializeField] float durability;

    [Header("Drop Information")]
    [SerializeField] ItemData itemDrop;
    [SerializeField] int qtdMin, qtdMax;

    float currentDurability;

    protected override void Start()
    {
        base.Start();
        currentDurability = durability;
    }

    public override void Interact()
    {
        ModifyHealth(-1);
        base.Interact();
    }

    public void ModifyHealth(float value)
    {
        currentDurability = Mathf.Clamp(currentDurability + value, 0, durability);

        if(currentDurability <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
