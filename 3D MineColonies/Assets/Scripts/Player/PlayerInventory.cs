using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ItemEntity> itemsInInventory;

    public void AddItem(ItemEntity item)
    {
        if (itemsInInventory.Contains(GetItemByInfo(item.ItemInfo)))
        {
            GetItemByInfo(item.ItemInfo).Count += item.Count;
        }
        else
        {
            itemsInInventory.Add(item);
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
            itemsInInventory.Remove(removedItem);

            removedItem.Count -= amount;

        if (removedItem.Count <= 0)
            itemsInInventory.Remove(removedItem);
    }

    public ItemEntity GetItemFromList(ItemEntity item)
    {
        return itemsInInventory[itemsInInventory.IndexOf(item)];
    }

    public ItemEntity GetItemByInfo(ItemInfo itemInfo)
    {
        foreach (ItemEntity item in itemsInInventory)
        {
            if (item.ItemInfo == itemInfo)
            {
                return item;
            }
        }

        return null;
    }
}
