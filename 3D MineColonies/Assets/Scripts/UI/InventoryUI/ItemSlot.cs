using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI slotCount;

    [Space(7)]
    [SerializeField] private ItemEntity itemInSlot;

    public ItemEntity ItemInSlot { get => itemInSlot; }

    public void SetItem(ItemEntity item)
    {
        itemInSlot = item;
        slotImage.sprite = itemInSlot.ItemInfo.ItemSprite;
        slotCount.text = itemInSlot.Count.ToString();
    }

    public void UpdateSlot()
    {
        if (itemInSlot != null)
        {
            slotImage.sprite = itemInSlot.ItemInfo.ItemSprite;
            slotCount.text = itemInSlot.Count.ToString();
        }
    }

    public void ClearSlot()
    {
        itemInSlot = null;
        slotImage.sprite = null;
        slotCount.text = "";
    }

    public void OnClick()
    {
        UIInventoryManager.Instance.FillSelectedItem(itemInSlot);
    }
}
