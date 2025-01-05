using UnityEngine;

public class ItemCollectable : Interactable
{
    [LineSpacer]
    [SerializeField] ItemData itemReference;
    public override void Interact()
    {
        InventoryManager.AddItem(itemReference.itemID, 1);
        Destroy(gameObject);
        base.Interact();
    }
}