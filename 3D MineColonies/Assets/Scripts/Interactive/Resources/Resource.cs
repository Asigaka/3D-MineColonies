using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : AInteractive
{
    [SerializeField] private ResourceInfo resourceInfo;

    [SerializeField] private Container container;
    private int currentProgress;

    public override void Interactive()
    {
        base.Interactive();
        OpenResourceContainer();
    }

    public override void Initialize()
    {
        base.Initialize();
        container = new Container(resourceInfo.ItemsBeforeMining);
        container.FillContainer();
    }

    private void OpenResourceContainer()
    {
        
    }
}
