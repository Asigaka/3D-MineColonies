using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Container
{
    [SerializeField] private List<ItemEntity> itemsInContainer;

    private List<ItemForSpawn> itemsForSpawn;
    private PlayerInventory playerInventory;
    private int maxSlots;

    public List<ItemForSpawn> ItemsForSpawn { get => itemsForSpawn; }
    public List<ItemEntity> ItemsInContainer { get => itemsInContainer; }
    public int MaxSlots { get => maxSlots; }

    public bool IsEmpty() => !(itemsInContainer.Count > 0);

    public Container(int maxSlots)
    {
        this.maxSlots = maxSlots;
        itemsInContainer = new List<ItemEntity>();
        playerInventory = PlayerInventory.Instance;
    }

    public Container(List<ItemForSpawn> itemsForSpawn, int maxSlots)
    {
        this.itemsForSpawn = itemsForSpawn;
        this.maxSlots = maxSlots;
        itemsInContainer = new List<ItemEntity>();
        playerInventory = PlayerInventory.Instance;
    }

    public void FillContainer()
    {
        if (itemsInContainer.Count == 0)
        {
            foreach (ItemForSpawn spawnItem in itemsForSpawn)
            {
                int itemCount = Random.Range(spawnItem.MinAmount, spawnItem.MaxAmount);

                if (itemCount > 0)
                {
                    ItemEntity newItem = new ItemEntity(spawnItem.ItemInfo, itemCount, ItemLocation.InContainer);
                    itemsInContainer.Add(newItem);
                }
            }
        }
    }

    public void TakeAllItemsToInventory()
    {
        playerInventory.AddItemList(itemsInContainer);
        itemsInContainer.Clear();
    }
}
