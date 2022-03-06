using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Container
{
    [SerializeField] private List<ItemEntity> itemsInContainer;

    private List<ItemForSpawn> itemsForSpawn;

    public List<ItemForSpawn> ItemsForSpawn { get => itemsForSpawn; private set => itemsForSpawn = value; }
    public List<ItemEntity> ItemsInContainer { get => itemsInContainer; private set => itemsInContainer = value; }

    public Container(List<ItemForSpawn> itemsForSpawn)
    {
        this.ItemsForSpawn = itemsForSpawn;
        itemsInContainer = new List<ItemEntity>();
    }

    public void FillContainer()
    {
        if (itemsInContainer.Count == 0)
        {
            foreach (ItemForSpawn spawnItem in ItemsForSpawn)
            {
                int itemCount = Random.Range(spawnItem.MinAmount, spawnItem.MaxAmount);

                if (itemCount > 0)
                {
                    ItemEntity newItem = new ItemEntity(spawnItem.ItemInfo, itemCount);
                    itemsInContainer.Add(newItem);
                }
            }
        }
    }
}
