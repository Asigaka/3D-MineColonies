using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NeededItem
{
    [SerializeField] private ItemInfo item;
    [SerializeField] private int count;

    public ItemInfo Item { get => item; }
    public int Count { get => count; }
}
