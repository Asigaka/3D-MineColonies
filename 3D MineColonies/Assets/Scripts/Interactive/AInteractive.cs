using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public abstract class AInteractive : MonoBehaviour
{
    private UnityEvent onAfterStart;

    private Outline outline;

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

    }

    public virtual void ShowInteractive()
    {
        outline.enabled = true;
        UIPlayerInteractives.Instance.InteractiveBtnActive(true);
    }

    public virtual void HideInteractive()
    {
        outline.enabled = false;
        UIPlayerInteractives.Instance.InteractiveBtnActive(false);
    }

    public virtual void Interactive()
    {

    }
}
