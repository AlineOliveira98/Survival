using System.Collections.Generic;
using UnityEngine;

public class ItemsData : MonoBehaviour
{
    [SerializeField] List<ItemData> itemsData = new();
    static Dictionary<string, ItemData> itemsStorage = new();

    void Awake()
    {
        Initialise();
    }

    void Initialise()
    {
        itemsStorage.Clear();

        foreach (var item in itemsData)
        {
            itemsStorage.Add(item.itemID, item);
        }
    }

    public static ItemData GetItem(string itemID)
    {
        if(!itemsStorage.ContainsKey(itemID)) return null;
        return itemsStorage[itemID];
    }
}