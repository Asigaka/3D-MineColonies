using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : AInteractive
{
    [SerializeField] private ResourceInfo resourceInfo;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private bool destroyWhenInteractive;

    private Container container;
    private PlayerMovement playerMovement;
    private int currentProgress;

    public override void ShowInteractive()
    {
        if (!container.IsEmpty())
        {
            base.ShowInteractive();

            if (currentProgress != 0 && progressBar)
                progressBar.gameObject.SetActive(true);
        }
    }

    public override void HideInteractive()
    {
        base.HideInteractive();

        if (progressBar)
            progressBar.gameObject.SetActive(false);
    }

    public override void Interactive()
    {
        if (!playerMovement.IsMiningResoures)
        {
            base.Interactive();

            if (resourceInfo.MiningProgress != 0)
            {
                StartCoroutine(StartMineResource());
            }
            else
            {
                EndMineResource();
            }
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        container = new Container(resourceInfo.ItemsBeforeMining, -1);
        container.FillContainer();

        if (progressBar)
            progressBar.ChangeMaxValue(resourceInfo.MiningProgress);
    }

    public IEnumerator StartMineResource()
    {
        playerMovement.IsMiningResoures = true;

        while (true)
        {
            yield return new WaitForSeconds(1);
            currentProgress += 10;

            if (progressBar)
                progressBar.ChangeValue(currentProgress);

            if (currentProgress >= resourceInfo.MiningProgress)
            {
                EndMineResource();
                break;
            }
        }
    }

    public void EndMineResource()
    {
        OpenResourceContainer();
        playerMovement.IsMiningResoures = false;

        if (destroyWhenInteractive)
            Destroy(gameObject);
    }

    private void OpenResourceContainer()
    {
        container.TakeAllItemsToInventory();
    }
}
