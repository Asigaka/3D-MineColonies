using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour
{
    [SerializeField] private Transform bagContent;
    [SerializeField] private Transform barContent;
    [SerializeField] private int maxSlotsInBag;
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private List<ItemSlot> slots;
    [SerializeField] private Button backBtn;

    private PlayerInventory playerInventory;

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

        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void CloseInventory()
    {
        UIManager.Instance.Toogle(UIType.HUD);
    }

    public void SpawnInventory()
    {
        for (int i = 0; i < maxSlotsInBag; i++)
        {
            ItemSlot newSlot = Instantiate(itemSlot, bagContent).GetComponent<ItemSlot>();
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
}
