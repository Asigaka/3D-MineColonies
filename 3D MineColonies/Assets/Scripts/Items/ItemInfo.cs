using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Item")]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemName;

    public Sprite ItemSprite { get => itemSprite; }
    public string ItemName { get => itemName; }
}
