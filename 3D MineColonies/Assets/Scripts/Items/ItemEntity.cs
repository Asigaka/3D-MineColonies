using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEntity
{
    [SerializeField] private ItemInfo itemInfo;
    [SerializeField] private int count;

    public ItemInfo ItemInfo { get => itemInfo; }
    public int Count { get => count; }

    public ItemEntity(ItemInfo itemInfo, int count)
    {
        this.itemInfo = itemInfo;
        this.count = count;
    }
}
