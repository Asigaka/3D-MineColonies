using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEntity
{
    [SerializeField] private ItemInfo itemInfo;
    [SerializeField] private int count;
    [SerializeField] private ItemLocation itemLocation;

    public ItemInfo ItemInfo { get => itemInfo; }
    public int Count { get => count; set => count = value; }
    public ItemLocation ItemLocation { get => itemLocation; set => itemLocation = value; }

    public ItemEntity(ItemInfo itemInfo, int count, ItemLocation itemLocation)
    {
        this.itemInfo = itemInfo;
        this.count = count;
        this.itemLocation = itemLocation;
    }
}
