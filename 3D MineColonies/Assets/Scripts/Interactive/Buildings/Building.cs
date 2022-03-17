using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    [SerializeField] private BuildingInfo buildingInfo;
    [SerializeField] private ContainerHandler productionContainer;

    private BuildingsManager manager;
    [SerializeField] private float currentProgress;

    public float CurrentProgress { get => currentProgress; }

    private void Start()
    {
        manager = BuildingsManager.Instance;
    }

    private void Update()
    {
        ProductionTimer();
    }

    private void OnMouseDown()
    {
        manager.SelectBuilding(this);
    }

    private void OnMouseUp()
    {
        manager.ClearBuilding(this);
    }

    private void ProductionTimer()
    {
        if (buildingInfo.ProductItems.Count > 0)
        {
            if (currentProgress >= 100)
            {
                foreach (ItemForSpawn product in buildingInfo.ProductItems)
                {
                    int count = Random.Range(product.MinAmount, product.MaxAmount);
                    ItemEntity item = new ItemEntity(product.ItemInfo, count, ItemLocation.InContainer);
                    ContainersManager.Instance.AddItem(item, productionContainer.Container);
                }

                currentProgress = 0;
            }
            else
            {
                currentProgress += Time.deltaTime * buildingInfo.ProgressGainMultiplier;
            }
        }
    }
}
