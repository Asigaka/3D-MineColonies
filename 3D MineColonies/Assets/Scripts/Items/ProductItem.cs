using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProductItem
{
    [SerializeField] private ItemInfo item;
    [SerializeField] private float secondsToSpawnItem;
    [SerializeField] private float currentTime;

    public ItemInfo Item { get => item; }
    public float SecondsToSpawnItem { get => secondsToSpawnItem; }
    public float CurrentTime { get => currentTime; set => currentTime = value; }
}
