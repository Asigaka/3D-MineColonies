using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType { HUD, Inventory, Build}
public class UIManager : MonoBehaviour
{
    [SerializeField] private List<UIObject> uIObjects;
    [SerializeField] private UIInventoryManager inventoryManager;
    [SerializeField] private UIType startType = UIType.HUD;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        Toogle(startType);
    }

    public void Toogle(UIType type)
    {
        switch (type)
        {
            case UIType.HUD:
                GameStateController.Instance.ChangeState(GameState.ActionMode);
                break;
            case UIType.Inventory:
                GameStateController.Instance.ChangeState(GameState.ActionMode);
                break;
            case UIType.Build:
                GameStateController.Instance.ChangeState(GameState.BuildMode);
                break;
        }

        foreach (UIObject uIObject in uIObjects)
        {
            uIObject.gameObject.SetActive(uIObject.Type == type);
        }
    }
}
