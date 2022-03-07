using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEntity
{
    [SerializeField] private ItemInfo itemInfo;
    [SerializeField] private int count;
    [SerializeField] private ItemSlot itemSlot;

    public ItemInfo ItemInfo { get => itemInfo; }
    public int Count { get => count; set => count = value; }
    public ItemSlot ItemSlot { get => itemSlot; }

    public ItemEntity(ItemInfo itemInfo, int count)
    {
        this.itemInfo = itemInfo;
        this.count = count;
    }

    public void SetSlot(ItemSlot slot)
    {
        itemSlot = slot;
        itemSlot.SetItem(this);
    }
}
