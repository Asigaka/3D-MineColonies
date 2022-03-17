using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainersManager : MonoBehaviour
{
    [SerializeField] private Container selectedContainer;

    public Container SelectedContainer { get => selectedContainer; }

    public static ContainersManager Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    public void OpenContainer(Container container)
    {
        selectedContainer = container;
        UIInventoryManager.Instance.OpenContainer(selectedContainer);
    }

    public void CloseContainer()
    {
        selectedContainer = null;
    }

    public void AddItem(ItemEntity item)
    {
        ItemEntity newItem = item;
        newItem.ItemLocation = ItemLocation.InContainer;

        if (selectedContainer.ItemsInContainer.Contains(GetItemByInfo(newItem.ItemInfo)))
        {
            ItemEntity itemInInventory = GetItemByInfo(newItem.ItemInfo);
            itemInInventory.Count += newItem.Count;
        }
        else
        {
            selectedContainer.ItemsInContainer.Add(newItem);
        }
    }

    public void AddItem(ItemEntity item, Container container)
    {
        ItemEntity newItem = item;
        newItem.ItemLocation = ItemLocation.InContainer;

        if (container.ItemsInContainer.Contains(GetItemByInfo(newItem.ItemInfo)))
        {
            ItemEntity itemInInventory = GetItemByInfo(newItem.ItemInfo);
            itemInInventory.Count += newItem.Count;
        }
        else
        {
            container.ItemsInContainer.Add(newItem);
        }
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
        selectedContainer.ItemsInContainer.Remove(removedItem);
    }

    public void RemoveItem(ItemEntity item, int amount)
    {
        ItemEntity removedItem = GetItemFromList(item);
        removedItem.Count -= amount;

        if (removedItem.Count <= 0)
        {
            selectedContainer.ItemsInContainer.Remove(removedItem);
        }
    }

    public ItemEntity GetItemFromList(ItemEntity item)
    {
        return selectedContainer.ItemsInContainer[selectedContainer.ItemsInContainer.IndexOf(item)];
    }

    public ItemEntity GetItemByInfo(ItemInfo itemInfo)
    {
        foreach (ItemEntity item in selectedContainer.ItemsInContainer)
        {
            if (item.ItemInfo == itemInfo)
            {
                return item;
            }
        }

        return null;
    }
}
