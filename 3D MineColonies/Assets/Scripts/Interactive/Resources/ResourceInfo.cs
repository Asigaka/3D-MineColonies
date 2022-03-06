using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Content/Resource")]
public class ResourceInfo : ScriptableObject
{
    [SerializeField] private string resourceName;
    [SerializeField] private int miningProgress;
    [SerializeField] private List<ItemForSpawn> itemsBeforeMining;

    public string ResourceName { get => resourceName; }
    public int MiningProgress { get => miningProgress; }
    public List<ItemForSpawn> ItemsBeforeMining { get => itemsBeforeMining; }
}
