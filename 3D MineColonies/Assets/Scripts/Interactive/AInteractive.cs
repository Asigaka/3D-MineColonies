using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public abstract class AInteractive : MonoBehaviour
{
    private Outline outline;
    private bool initialized;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 7;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.black;

        HideInteractive();
        Initialize();
    }

    public virtual void Initialize()
    {
        initialized = true;
    }

    public virtual void ShowInteractive()
    {
        if (initialized)
        {
            outline.enabled = true;
            UIHUDManager.Instance.InteractiveBtnActive(true);
        }
    }

    public virtual void HideInteractive()
    {
        outline.enabled = false;
        UIHUDManager.Instance.InteractiveBtnActive(false);
    }

    public virtual void Interactive()
    {

    }
}
