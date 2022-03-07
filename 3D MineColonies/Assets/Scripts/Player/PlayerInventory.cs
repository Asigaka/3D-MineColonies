using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ItemEntity> itemsInInventory;

    private UIInventoryManager uiInventory;

    public List<ItemEntity> ItemsInInventory { get => itemsInInventory; private set => itemsInInventory = value; }

    private void Start()
    {
        uiInventory = UIInventoryManager.Instance;
        uiInventory.SpawnInventory();
    }

    public void AddItem(ItemEntity item)
    {
        ItemEntity newItem = item;

        if (ItemsInInventory.Contains(GetItemByInfo(newItem.ItemInfo)))
        {
            ItemEntity itemInInventory = GetItemByInfo(newItem.ItemInfo);
            itemInInventory.Count += newItem.Count;
            itemInInventory.ItemSlot.UpdateSlot();
        }
        else
        {
            ItemsInInventory.Add(newItem);
            newItem.SetSlot(uiInventory.GetNearestFreeSlot());
        }
    }

    public void AddItemList(List<ItemEntity> items)
    {
        foreach (ItemEntity addedItem in items)
        {
            AddItem(addedItem);
        }
    }

    public void RemoveItem(ItemEntity item, int amount = -1)
    {
        ItemEntity removedItem = GetItemFromList(item);
        if (amount == -1)
            ItemsInInventory.Remove(removedItem);

            removedItem.Count -= amount;

        if (removedItem.Count <= 0)
            ItemsInInventory.Remove(removedItem);
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
