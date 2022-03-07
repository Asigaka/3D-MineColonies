using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHUDManager : MonoBehaviour
{
    [SerializeField] private Button inventoryBtn;
    [SerializeField] private Button interactiveBtn;

    private PlayerInteractive playerInteractive;

    public static UIHUDManager Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        interactiveBtn.onClick.AddListener(OnInteractiveClick);
        inventoryBtn.onClick.AddListener(OnInventoryClick);
        playerInteractive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractive>();
        InteractiveBtnActive(false);
    }

    public void OnInteractiveClick()
    {
        playerInteractive.OnInteractiveClick();
    }

    public void OnInventoryClick()
    {
        UIManager.Instance.Toogle(UIType.Inventory);
    }

    public void InteractiveBtnActive(bool state)
    {
        interactiveBtn.gameObject.SetActive(state);
    }
}
