using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemForSpawn 
{
    [SerializeField] private ItemInfo itemInfo;
    [SerializeField] private int minAmount;
    [SerializeField] private int maxAmount;

    public ItemInfo ItemInfo { get => itemInfo; }
    public int MinAmount { get => minAmount; }
    public int MaxAmount { get => maxAmount; }
}
