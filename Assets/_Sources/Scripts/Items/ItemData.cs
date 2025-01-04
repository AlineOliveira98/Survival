using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Crafting/Item")]
public class ItemData : ScriptableObject
{
    public string itemID;
    public string title;
    public Sprite icon;
    public ItemType type;
    public int maxStack;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(itemID))
        {
            itemID = System.Guid.NewGuid().ToString();
            EditorUtility.SetDirty(this);
        }
    }
#endif
}


