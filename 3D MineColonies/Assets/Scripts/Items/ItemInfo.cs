using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Item")]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private string itemName;
}
