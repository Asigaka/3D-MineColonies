using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventoryManager : MonoBehaviour
{
    [SerializeField] private Transform inventoryContent;
    [SerializeField] private int maxSlotsInInventory;
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private List<ItemSlot> slots;
    [SerializeField] private Button backBtn;

    [Space(5)]
    [SerializeField] private GameObject containerBG;
    [SerializeField] private Transform containerContent;

    [Space(5)]
    [SerializeField] private TextMeshProUGUI selectedItemName;
    [SerializeField] private GameObject selectedItemBG;
    [SerializeField] private Button takeBtn;
    [SerializeField] private ItemEntity selectedItem;

    private PlayerInventory playerInventory;
    private ContainersManager containersManager;

    public static UIInventoryManager Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        backBtn.onClick.AddListener(CloseInventory);
        takeBtn.onClick.AddListener(OnTakeBtnClock);
        CloseContainer();
        ClearSelectedItem();
        containersManager = ContainersManager.Instance;
        playerInventory = PlayerInventory.Instance;
    }

    private void CloseInventory()
    {
        UIManager.Instance.Toogle(UIType.HUD);
        CloseContainer();
        containersManager.CloseContainer();
        ClearSelectedItem();
    }

    public void SpawnInventory()
    {
        for (int i = 0; i < maxSlotsInInventory; i++)
        {
            ItemSlot newSlot = Instantiate(itemSlot, inventoryContent).GetComponent<ItemSlot>();
            newSlot.ClearSlot();
            slots.Add(newSlot);
        }
    }

    public ItemSlot GetNearestFreeSlot()
    {
        foreach (ItemSlot slot in slots)
        {
            if (slot.ItemInSlot == null)
            {
                return slot;
            }
        }

        Debug.Log("Invetory is full!");
        return null;
    }

    public void OpenContainer()
    {
        UpdateContainer();
        containerBG.SetActive(true);
        UIManager.Instance.Toogle(UIType.Inventory);
    }

    public void CloseContainer()
    {
        ClearContainer();
        containerBG.SetActive(false);
    }

    public void UpdateContainer()
    {
        ClearContainer();
        SpawnContainer();
    }

    private void ClearContainer()
    {
        for (int i = 0; i < containerContent.childCount; i++)
            Destroy(containerContent.GetChild(i).gameObject);
    }

    private void SpawnContainer()
    {
        Container conatiner = containersManager.SelectedContainer;
        List<ItemSlot> containerSlots = new List<ItemSlot>();

        for (int i = 0; i < conatiner.MaxSlots; i++)
        {
            ItemSlot slot = Instantiate(itemSlot, containerContent).GetComponent<ItemSlot>();
            slot.ClearSlot();
            containerSlots.Add(slot);
        }

        for (int j = 0; j < conatiner.ItemsInContainer.Count; j++)
        {
            containerSlots[j].SetItem(conatiner.ItemsInContainer[j]);
        }
    }

    private void OnTakeBtnClock()
    {
        if (selectedItem.ItemLocation == ItemLocation.InInventory)
        {
            containersManager.AddItem(selectedItem);
            playerInventory.RemoveItem(selectedItem);
        }
        else
        {
            playerInventory.AddItem(selectedItem);
            containersManager.RemoveItem(selectedItem);
        }
        ClearSelectedItem();
        UpdateContainer();
    }

    public void FillSelectedItem(ItemEntity item)
    {
        takeBtn.gameObject.SetActive(containersManager.SelectedContainer != null);

        if (item != null)
        {
            selectedItemBG.SetActive(true);
            selectedItemName.text = item.ItemInfo.ItemName;
            selectedItem = item;
        }
        else
        {
            ClearSelectedItem();
        }
    }

    private void ClearSelectedItem()
    {
        selectedItem = null;
        selectedItemBG.SetActive(false);
    }
}
