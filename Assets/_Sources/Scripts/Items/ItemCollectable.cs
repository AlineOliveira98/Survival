using UnityEngine;

public class ItemCollectable : Interactable
{
    [LineSpacer]
    [SerializeField] ItemData itemReference;
    public override void Interact()
    {
        Destroy(gameObject);
        base.Interact();
    }
}