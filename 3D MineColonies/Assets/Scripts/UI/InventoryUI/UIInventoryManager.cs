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
    [SerializeField] private Button backBtn;

    [Space(5)]
    [SerializeField] private GameObject containerBG;
    [SerializeField] private Transform containerContent;

    [Space(5)]
    [SerializeField] private TextMeshProUGUI selectedItemName;
    [SerializeField] private GameObject selectedItemBG;
    [SerializeField] private Button takeBtn;
    [SerializeField] private ItemEntity selectedItem;

    private ContainersManager containersManager;
    private PlayerInventory playerInventory;
    private Container selectedContainer;

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
        playerInventory = PlayerInventory.Instance;
        containersManager = ContainersManager.Instance;
    }

    public void UpdateInventory()
    {
        ClearInventory();
        SpawnInventory();
    }

    private void ClearInventory()
    {
        for (int i = 0; i < inventoryContent.childCount; i++)
            Destroy(inventoryContent.GetChild(i).gameObject);
    }

    private void CloseInventory()
    {
        UIManager.Instance.Toogle(UIType.HUD);
        CloseContainer();
        selectedContainer = null;
        ClearSelectedItem();
    }

    public void SpawnInventory()
    {
        List<ItemSlot> slotsList = new List<ItemSlot>();

        for (int i = 0; i < maxSlotsInInventory; i++)
        {
            ItemSlot newSlot = Instantiate(itemSlot, inventoryContent).GetComponent<ItemSlot>();
            newSlot.gameObject.name = "Slot" + i;
            newSlot.ClearSlot();
            slotsList.Add(newSlot);
        }

        for (int i = 0; i < playerInventory.ItemsInInventory.Count; i++)
        {
            slotsList[i].SetItem(playerInventory.ItemsInInventory[i]);
        }
    }

    public void OpenContainer(Container container)
    {
        selectedContainer = container;
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
        List<ItemSlot> containerSlots = new List<ItemSlot>();

        for (int i = 0; i < selectedContainer.MaxSlots; i++)
        {
            ItemSlot slot = Instantiate(itemSlot, containerContent).GetComponent<ItemSlot>();
            slot.ClearSlot();
            containerSlots.Add(slot);
        }

        for (int j = 0; j < selectedContainer.ItemsInContainer.Count; j++)
        {
            containerSlots[j].SetItem(selectedContainer.ItemsInContainer[j]);
        }
    }

    private void OnTakeBtnClock()
    {
        if (selectedItem.ItemLocation == ItemLocation.InInventory && !containersManager.SelectedContainer.IsFull())
        {
            containersManager.AddItem(selectedItem);
            playerInventory.RemoveItem(selectedItem);
        }
        else if (selectedItem.ItemLocation == ItemLocation.InContainer && !playerInventory.IsFull())
        {
            playerInventory.AddItem(selectedItem);
            containersManager.RemoveItem(selectedItem);
        }
        ClearSelectedItem();
        UpdateContainer();
        UpdateInventory();
    }

    public void FillSelectedItem(ItemEntity item)
    {
        takeBtn.gameObject.SetActive(selectedContainer != null);

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
