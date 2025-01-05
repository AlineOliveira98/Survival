using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        
        // DontDestroyOnLoad(gameObject);
    }
    #endregion

    [SerializeField] int maxSize;
    public static Dictionary<string, float> playerItems = new();
    public static Action OnInventoryUpdated;

    void Start()
    {
        Initialise();
    }

    public void Initialise()
    {
        playerItems.Clear();
    }

    public static void AddItem(string itemID, float amount)
    {
        if(playerItems.ContainsKey(itemID))
            playerItems[itemID] += amount;
        else
        {
            if(playerItems.Count >= Instance.maxSize)
            {
                Debug.LogError("Error, inventory is full!");
                return;
            }

            playerItems.Add(itemID, amount);
        }

        DebugInventory();
        OnInventoryUpdated?.Invoke();
    }

    public void RemoveItem(string itemID, float amount)
    {
        if(playerItems.ContainsKey(itemID))
        {
            playerItems[itemID] -= amount;

            if(playerItems[itemID] <= 0)
            {
                playerItems.Remove(itemID);
            }
        }

        DebugInventory();
        OnInventoryUpdated?.Invoke();
    }

    static void DebugInventory()
    {
        foreach (var item in playerItems)
        {
            var itemI = ItemsData.GetItem(item.Key);
            Debug.Log($"Inventory [{itemI.title} - Quantity: {item.Value}]");
        }
    }
}
