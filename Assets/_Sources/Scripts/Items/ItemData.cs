using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public string itemID;
    public Sprite icon;
    public string title;
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