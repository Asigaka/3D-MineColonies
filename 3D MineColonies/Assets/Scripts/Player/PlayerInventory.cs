using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemLocation { InInventory, InContainer}
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ItemEntity> itemsInInventory;
    [SerializeField] private int maxSlots = 16;

    private UIInventoryManager uiInventory;

    public List<ItemEntity> ItemsInInventory { get => itemsInInventory; private set => itemsInInventory = value; }
    public bool IsFull() => (itemsInInventory.Count >= maxSlots);

    public static PlayerInventory Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        uiInventory = UIInventoryManager.Instance;
        uiInventory.SpawnInventory();
    }

    public void AddItem(ItemEntity item)
    {
        ItemEntity newItem = item;
        newItem.ItemLocation = ItemLocation.InInventory;

        if (ItemsInInventory.Contains(GetItemByInfo(newItem.ItemInfo)))
        {
            ItemEntity itemInInventory = GetItemByInfo(newItem.ItemInfo);
            itemInInventory.Count += newItem.Count;
        }
        else
        {
            ItemsInInventory.Add(newItem);
        }

        uiInventory.UpdateInventory();
    }

    public void AddItemList(List<ItemEntity> items)
    {
        foreach (ItemEntity addedItem in items)
        {
            AddItem(addedItem);
        }
    }

    public void RemoveItem(ItemEntity item)
    {
        ItemEntity removedItem = GetItemFromList(item);
        ItemsInInventory.Remove(removedItem);
    }

    public void RemoveItem(ItemEntity item, int amount)
    {
        ItemEntity removedItem = GetItemFromList(item);
        removedItem.Count -= amount;

        if (removedItem.Count <= 0)
        {
            ItemsInInventory.Remove(removedItem);
        }
    }

    public ItemEntity GetItemFromList(ItemEntity item)
    {
        return ItemsInInventory[ItemsInInventory.IndexOf(item)];
    }

    public ItemEntity GetItemByInfo(ItemInfo itemInfo)
    {
        foreach (ItemEntity item in ItemsInInventory)
        {
            if (item.ItemInfo == itemInfo)
            {
                return item;
            }
        }

        return null;
    }
}
