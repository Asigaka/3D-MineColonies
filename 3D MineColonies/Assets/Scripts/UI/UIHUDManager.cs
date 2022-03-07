using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHUDManager : MonoBehaviour
{
    [SerializeField] private Button inventoryBtn;
    [SerializeField] private Button interactiveBtn;
    [SerializeField] private Button buildModeBtn;

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
        buildModeBtn.onClick.AddListener(OnBuildModeClick);
        playerInteractive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractive>();
        InteractiveBtnActive(false);
    }

    private void OnInteractiveClick()
    {
        playerInteractive.OnInteractiveClick();
    }

    private void OnInventoryClick()
    {
        UIManager.Instance.Toogle(UIType.Inventory);
    }

    private void OnBuildModeClick()
    {
        UIManager.Instance.Toogle(UIType.Build);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCamera>().SwitchCameraMode();
    }

    public void InteractiveBtnActive(bool state)
    {
        interactiveBtn.gameObject.SetActive(state);
    }
}
