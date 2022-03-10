using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerHandler : AInteractive
{
    [SerializeField] private int maxSlots;
    [SerializeField] private Container container;
    [SerializeField] private List<ItemForSpawn> itemForSpawns;

    private PlayerInventory playerInventory;

    public override void Initialize()
    {
        base.Initialize();
        container = new Container(itemForSpawns, maxSlots);
        container.FillContainer();
        playerInventory = PlayerInventory.Instance;
    }

    public override void Interactive()
    {
        base.Interactive();
        ContainersManager.Instance.OpenContainer(container);
    }
}
